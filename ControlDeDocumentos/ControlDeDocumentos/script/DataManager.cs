using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;
using System.Windows.Forms;
using System.Net;

namespace ControlDeDocumentos
{
    class DataManager
    {
        private static SqlConnection cn;



        public static SqlConnection cnn()
        {
            cn = new SqlConnection(script.Encryption.RijndaelSimple.Desencriptar(ConfigurationManager.ConnectionStrings["DOCUMENTOS"].ConnectionString));
            cn.Open();
            return cn;
        }

        public static DataSet selTab(String query, String tabla)
        {
            try
            {
                DataSet ds = new DataSet();
                String sSel = query;
                SqlDataAdapter adaptador = new SqlDataAdapter(sSel, cnn());
                adaptador.Fill(ds, tabla);
                return ds;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error De Aplicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                if (cn != null)
                {
                    cn.Close();
                }
            }
        }

  

        public static script.ResponseSql insert(String query)
        {
            try
            {
                SqlCommand var_comando = new SqlCommand();
                var_comando.Connection = cnn();
                var_comando.CommandText = query;
                var_comando.ExecuteNonQuery();
                return new script.ResponseSql(0, "Alta Exitosa");
            }
            catch (Exception e)
            {
                return new script.ResponseSql(1, e.Message);
            }
            finally
            {
                if (cn != null)
                {
                    cn.Close();
                }
            }
        }

        public static script.ResponseSql delete(String query)
        {
            try
            {
                SqlCommand var_comando = new SqlCommand();
                var_comando.Connection = cnn();
                var_comando.CommandText = query;
                var_comando.ExecuteNonQuery();
                return new script.ResponseSql(0, "Baja Exitosa");
            }
            catch (Exception e)
            {
                return new script.ResponseSql(1, e.Message);
            }
            finally
            {
                if (cn != null)
                {
                    cn.Close();
                }
            }
        }


        public static script.ResponseSql update(String query)
        {
            try
            {
                SqlCommand var_comando = new SqlCommand();
                var_comando.Connection = cnn();
                var_comando.CommandText = query;
                var_comando.ExecuteNonQuery();
                return new script.ResponseSql(0, "Cambio Exitoso");
            }
            catch (Exception e)
            {
                return new script.ResponseSql(1, e.Message);
            }
            finally
            {
                if (cn != null)
                {
                    cn.Close();
                }
            }
        }

        public static ComboBox fillCombo(ComboBox cmb, String member, String value, String query, String tabla) {

            DataSet ds = new DataSet();
            String sSel = query;
            SqlDataAdapter adaptador = new SqlDataAdapter(sSel, cnn());
            adaptador.Fill(ds, tabla);

            cmb.DataSource = ds.Tables[0];
            cmb.DisplayMember =member;
            cmb.ValueMember = value;
            return cmb;
        
        }

        public static void fillComboEs(ComboBox combo, DataSet ds)

        {
                combo.DataSource = null;
                List<script.Combo> lista = new List<script.Combo>();
                lista.Add(new script.Combo("", "<Seleccionar>"));
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    lista.Add(new script.Combo(row[0].ToString(), row[1].ToString()));
                }
                combo.DataSource = lista;
                combo.ValueMember = "code";
                combo.DisplayMember = "description";
                combo.SelectedIndex = 0;

        }



        public static void fillLista(ListBox lista, DataSet ds) {

            lista.DataSource = null;
            List<script.Combo> list = new List<script.Combo>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list.Add(new script.Combo(row[0].ToString(), row[1].ToString()));
         
            }
            lista.DataSource = list;
            lista.ValueMember = "code";
            lista.DisplayMember = "description";
        }

        public static void indexCombo(ComboBox combo, String valor)
        {
            for(int i = 0;i <combo.Items.Count;i++){
                combo.SelectedIndex = i;
                if(valor.Equals(combo.SelectedValue.ToString())){
                     combo.SelectedIndex = i;
                    break;
                }            
            }   
        }

        public static void indexComboNor(ComboBox combo, String valor)
        {
            for (int i = 0; i < combo.Items.Count; i++)
            {
                combo.SelectedIndex = i;
                if (valor.Equals(combo.SelectedItem.ToString()))
                {
                    combo.SelectedIndex = i;
                    break;
                }
            }
        }

        public static void updateEstado()
        {
            try
            {
                SqlCommand var_comando = new SqlCommand();
                var_comando.Connection = cnn();
                var_comando.CommandText = "UPDATE Documento SET estado = 'Caducado' where (select  (((365* year(getdate()))-(365*(year(Doc.fecha))))+ (month(getdate())-month(Doc.fecha))*30+(day(getdate()) - day(Doc.fecha)))/365  from Documento Doc where Documento.idDocumento = Doc.idDocumento and Documento.edicion = Doc.edicion)>=Documento.vigencia and Documento.estado != 'Caducado'";
                var_comando.ExecuteNonQuery();
             }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error De Aplicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (cn != null)
                {
                    cn.Close();
                }
            }
        }

        public static void saveLog(String tableName, String operacion,String usuario, List<script.DetalleLog> detalle)
        {
            try
            {

                DateTime x = DateTime.Now;
                String fecha =x.Day +"/" +x.Month +"/"+x.Year+" "+ x.Hour + ":" + x.Minute + ":" + x.Second;
                String query;
                int correlativo = getCorr("idLog", "LogDoc");
                script.ResponseSql response;

                query = "INSERT INTO LogDoc VALUES("
                              + correlativo + ","
                              + "CONVERT(DATETIME,'" + fecha + "', 105),"
                              + "'" + operacion + "',"
                              + "'" + usuario + "',"
                              + "'" + tableName + "',"
                              + "'" + "Control De Documentos" + "',"
                              + "'" + getIp() + "')";
                
                response =  insert(query);
                
                if (response.Code != 0)
                {
                    MessageBox.Show(response.Message, "Error Sql", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                foreach (script.DetalleLog d in detalle)
                {
                    query = "INSERT INTO DetalleLogDoc VALUES("
                               + correlativo + ","
                               + "'" + d.Campo + "',"
                               + "'" + d.ValAntes + "',"
                               + "'" + d.ValDespues + "')";

                    response = insert(query);
                    if (response.Code != 0)
                    {
                        MessageBox.Show(response.Message, "Error Sql", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error Al grabar log", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (cn != null)
                {
                    cn.Close();
                }
            }
        }

        public static int getCorr(String field, String table)
        {
            String corr = "";
            int max = 0;
            DataSet ds = DataManager.selTab("select MAX("+ field+") from " + table, table);
            foreach (DataRow row in ds.Tables[table].Rows)
            {
                corr = row[0].ToString();
            }
            try
            {
                max = Convert.ToInt32(corr);
                return max + 1;
            }
            catch
            {
                return 1;
            }
        }

        public static string getIp()
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                }
            }
            return localIP;
        }

      

     }


}
