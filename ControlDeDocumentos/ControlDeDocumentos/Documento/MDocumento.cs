using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlDeDocumentos.Documento
{
    public partial class MDocumento : Form
    {
        private String query;
        private DataGridView grd;
        private DataSet ds;
        private Boolean  statusAll;
        private script.ResponseSql response;
        private String codigoDocumento;
        private String edicionDocumento;
        private String usuario;
        private String rol;
        private String queryDoc;
        private String operacion;
        private List<script.DetalleLog> listDetalleLog;
        private readonly String SELECT_DOCUMENTO = "select  D.idDocumento AS 'Id', "
                                            + "D.edicion AS 'Edición', "
                                            + "TipoDocumento.descripcion AS 'Tipo', "
                                            + "Area.descripcion AS 'Area',Seccion.descripcion AS 'Sección', "
                                            + "Subseccion.descripcion AS 'Sub-Sección', "
                                            + "D.correlativo AS 'Correlativo', "
                                            + "D.nombre AS 'Nombre', "
                                            + "D.estado AS 'Estado', "
                                            + "(select descripcion from  Nivel where idNivel =  D.idNivel) AS 'Nivel', "
                                            + "(select nombre from Usuario where idUsuario =  D.elaboradoPor) AS 'Elaborado Por' , "
                                            + "D.fechaElaborado AS 'Fecha de Elaboración', "
                                            + "(select nombre from Usuario where idUsuario =  D.revisadoPor) AS 'Revisado Por' , "
                                            + "D.fechaRevisado AS 'Fecha de Revisión', "
                                            + "(select nombre from Usuario where idUsuario =  D.aprobadoPor) AS 'Aprobado Por' , "
                                            + "D.fechaAprobado AS 'Fecha de Aprobación', "
                                            + "(select nombre from Usuario where idUsuario =  D.autorizadoPor) AS 'Autorizado Por' , "
                                            + "D.fechaAutorizado AS 'Fecha de Autorización', "
                                            + "D.vigencia AS 'Vigencia', "
                                            + "D.fecha AS 'Fecha De Vigencia', "
                                            + "D.ejemplar AS 'Ejemplar', "
                                            + "D.procedimientoAnt AS 'Procedimiento Anterior', "
                                            + "D.link AS 'Link' "
                                            + "from Documento D "
                                            + "INNER JOIN TipoDocumento on  D.idTipo = TipoDocumento.idTipoDocumento "
                                            + "INNER JOIN Area on  D.idArea = Area.idArea "
                                            + "INNER JOIN Seccion on  D.idSeccion = Seccion.idSeccion "
                                            + "INNER JOIN SubSeccion on  D.idSubSeccion = SubSeccion.idSubseccion and  D.idSeccion = SubSeccion.idSeccion ";


        private readonly String SELECT__DOCUMENTO_RESTRICTED = "select  D.idDocumento AS 'Id', "
                                            + "D.edicion AS 'Edición', "
                                            + "TipoDocumento.descripcion AS 'Tipo', "
                                            + "Area.descripcion AS 'Area',Seccion.descripcion AS 'Sección', "
                                            + "Subseccion.descripcion AS 'Sub-Sección', "
                                            + "D.correlativo AS 'Correlativo', "
                                            + "D.nombre AS 'Nombre', "
                                            + "D.estado AS 'Estado', "
                                            + "(select descripcion from  Nivel where idNivel =  D.idNivel) AS 'Nivel', "
                                            + "(select nombre from Usuario where idUsuario =  D.elaboradoPor) AS 'Elaborado Por' , "
                                            + "D.fechaElaborado AS 'Fecha de Elaboración', "
                                            + "(select nombre from Usuario where idUsuario =  D.revisadoPor) AS 'Revisado Por' , "
                                            + "D.fechaRevisado AS 'Fecha de Revisión', "
                                            + "(select nombre from Usuario where idUsuario =  D.aprobadoPor) AS 'Aprobado Por' , "
                                            + "D.fechaAprobado AS 'Fecha de Aprobación', "
                                            + "(select nombre from Usuario where idUsuario =  D.autorizadoPor) AS 'Autorizado Por' , "
                                            + "D.fechaAutorizado AS 'Fecha de Autorización', "
                                            + "D.vigencia AS 'Vigencia', "
                                            + "D.fecha AS 'Fecha De Vigencia', "
                                            + "D.ejemplar AS 'Ejemplar', "
                                            + "D.procedimientoAnt AS 'Procedimiento Anterior', "
                                            + "D.link AS 'Link' "
                                            + "from Documento D "
                                            + "INNER JOIN TipoDocumento on  D.idTipo = TipoDocumento.idTipoDocumento "
                                            + "INNER JOIN Area on  D.idArea = Area.idArea "
                                            + "INNER JOIN Seccion on  D.idSeccion = Seccion.idSeccion "
                                            + "INNER JOIN SubSeccion on  D.idSubSeccion = SubSeccion.idSubseccion and  D.idSeccion = SubSeccion.idSeccion "
                                            + "where D.edicion = (select max(Doc.edicion) from Documento Doc where Doc.idDocumento = D.idDocumento) ";


        private readonly String ORDER_BY_DOC = "order by D.idDocumento,D.edicion,D.idTipo,D.idArea,D.idSeccion,D.idSubseccion,D.correlativo";

        public MDocumento(String p1, String p2,String p3,String p4, DataGridView p5, String p6)
        {
            codigoDocumento = p1;
            edicionDocumento = p2;
            usuario = p3;
            rol = p4;
            grd = p5;
            operacion = p6;
            InitializeComponent();
        }

        public void setGrdw()
        {
            if (rol.Equals("superusuario"))
            {
                queryDoc = SELECT__DOCUMENTO_RESTRICTED
                         + "and (D.estado = 'Vigente' or D.estado = 'En Creacion') "
                         + ORDER_BY_DOC;
            }
            else if (rol.Equals("regular"))
            {
                queryDoc = SELECT__DOCUMENTO_RESTRICTED
                           + "and (D.estado = 'Vigente' or D.estado = 'En Creacion') and D.elaboradoPor = '" + usuario + "' "
                           + ORDER_BY_DOC;
            }
            else if (rol.Equals("sysadmin"))
            {
                queryDoc = SELECT_DOCUMENTO
                           + ORDER_BY_DOC;
            }


            ds = DataManager.selTab(queryDoc, "Documento");
            grd.DataSource = ds;
            grd.DataMember = "Documento";
        }

        private void MDocumento_Load(object sender, EventArgs e)
        {
            try{
            
            spinEdicion.Minimum = Convert.ToInt32(edicionDocumento);
            lblCodigo.Text = codigoDocumento;
            DataSet ds = DataManager.selTab("Select * from Documento where idDocumento = '" + codigoDocumento + "' and edicion = " +edicionDocumento, "Documento");
            foreach (DataRow row in ds.Tables["Documento"].Rows)
            {


                ds = DataManager.selTab("select idTipoDocumento,descripcion from TipoDocumento ", "Tipo");
                DataManager.fillComboEs(cmbTipo, ds);
                DataManager.indexCombo(cmbTipo, row[2].ToString());
                ds = DataManager.selTab("select idArea,descripcion from Area ", "Area");
                DataManager.fillComboEs(cmbArea, ds);
                DataManager.indexCombo(cmbArea, row[3].ToString());
                ds = DataManager.selTab("select idSeccion,descripcion from Seccion ", "Seccion");
                DataManager.fillComboEs(cmbSeccion, ds);
                DataManager.indexCombo(cmbSeccion, row[4].ToString());
                ds = DataManager.selTab("select idSubSeccion,descripcion from SubSeccion where idSeccion = '" + row[4].ToString() + "'", "SubSeccion");
                DataManager.fillComboEs(cmbSubseccion, ds);
                DataManager.indexCombo(cmbSubseccion, row[5].ToString());

                lblCorrelativo.Text = row[6].ToString();
                ds = DataManager.selTab("select idNivel,descripcion from Nivel ", "Nivel");
                DataManager.fillComboEs(cmbNivel, ds);
                DataManager.indexCombo(cmbNivel, row[7].ToString());

                txtNombre.Text = row[8].ToString();
                cmbEstado.DataSource = null;
                cmbEstado.Items.Add("<Seleccionar>");
        
                if (row[9].ToString().Equals("En Creacion"))
                {
                    cmbEstado.Items.Add("En Creacion");
                    cmbEstado.Items.Add("Vigente");
                }
                else {
                    cmbEstado.Items.Add("En Creacion");
                    cmbEstado.Items.Add("Vigente");
                    cmbEstado.Items.Add("Caducado");
                    cmbEstado.Items.Add("Obsoleto");
                }
                DataManager.indexComboNor(cmbEstado, row[9].ToString());
                ds = DataManager.selTab("select idUsuario,nombre from Usuario where elabora = 'Si'", "Usuario");
                DataManager.fillComboEs(cmbElaborado, ds);
                DataManager.indexCombo(cmbElaborado, row[10].ToString());
                ds = DataManager.selTab("select idUsuario,nombre from Usuario where revisa = 'Si'", "Usuario");
                DataManager.fillComboEs(cmbRevisado, ds);
                DataManager.indexCombo(cmbRevisado, row[12].ToString());
                ds = DataManager.selTab("select idUsuario,nombre from Usuario where aprueba = 'Si'", "Usuario");
                DataManager.fillComboEs(cmbAprobado, ds);
                DataManager.indexCombo(cmbAprobado, row[14].ToString());
                ds = DataManager.selTab("select idUsuario,nombre from Usuario where autoriza = 'Si'", "Usuario");
                DataManager.fillComboEs(cmbAutorizado, ds);
                DataManager.indexCombo(cmbAutorizado, row[16].ToString());

                dateElaborado.Value = getValDate(row[11].ToString());
                dateRevisado.Value = getValDate(row[13].ToString());
                dateAprobado.Value = getValDate(row[15].ToString());
                dateAutorizado.Value = getValDate(row[17].ToString());

                spinVigencia.Value = Convert.ToInt32(row[18].ToString());
                spinEjemplar.Value = Convert.ToInt32(row[19].ToString());
                txtProcAnterior.Text = row[20].ToString() ;
                dateVigencia.Value = Convert.ToDateTime(row[21].ToString());
                lblLink.Text = row[22].ToString();

                listDetalleLog = new List<script.DetalleLog>();
                listDetalleLog.Add(new script.DetalleLog("idDocumento", codigoDocumento, codigoDocumento));
                listDetalleLog.Add(new script.DetalleLog("edicion", edicionDocumento, ""));
                listDetalleLog.Add(new script.DetalleLog("idNivel", row[7].ToString(), ""));
                listDetalleLog.Add(new script.DetalleLog("nombre", row[8].ToString(), ""));
                listDetalleLog.Add(new script.DetalleLog("estado", row[9].ToString(), ""));
                listDetalleLog.Add(new script.DetalleLog("elaboradoPor", row[10].ToString(), ""));
                listDetalleLog.Add(new script.DetalleLog("fechaElaborado", row[11].ToString(), ""));
                listDetalleLog.Add(new script.DetalleLog("revisadoPor", row[12].ToString(), ""));
                listDetalleLog.Add(new script.DetalleLog("fechaRevisado", row[13].ToString(), ""));
                listDetalleLog.Add(new script.DetalleLog("aprobadoPor", row[14].ToString(), ""));
                listDetalleLog.Add(new script.DetalleLog("fechaAprobado", row[15].ToString(), ""));
                listDetalleLog.Add(new script.DetalleLog("autorizadoPor", row[16].ToString(), ""));
                listDetalleLog.Add(new script.DetalleLog("fechaAutorizado", row[17].ToString(), ""));
                listDetalleLog.Add(new script.DetalleLog("vigencia", row[18].ToString(), ""));
                listDetalleLog.Add(new script.DetalleLog("ejemplar", row[19].ToString(), ""));
                listDetalleLog.Add(new script.DetalleLog("procedimientoAnt", row[20].ToString(), ""));
                listDetalleLog.Add(new script.DetalleLog("fecha", row[21].ToString(), ""));
                listDetalleLog.Add(new script.DetalleLog("link", row[22].ToString(), ""));

            }

            ds = DataManager.selTab("Select * from Anexo where idDocumento = '" + codigoDocumento + "' and edicion = " +edicionDocumento, "Anexo");
            foreach (DataRow row in ds.Tables["Anexo"].Rows)
            {
                grdAnexo.Rows.Add(row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString(), row[8].ToString());
            }

            ds = DataManager.selTab("Select * from Registro where idDocumento = '" + codigoDocumento + "' and edicion = " + edicionDocumento, "Registro");
            foreach (DataRow row in ds.Tables["Registro"].Rows)
            {
                grdRegistro.Rows.Add(row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString(), row[8].ToString());
            }

              txtNombre.Focus();

              if (operacion.Equals("Modificacion"))
              {
                  lblTitulo.Text = "Modificación De Documento";
              }
              else {
                  lblTitulo.Text = "Consulta De Documento";
                  picOk.Visible = false;
                  label7.Visible = false;
                  addAnexo.Visible = false;
                  delAnexo.Visible = false;
                  modAnexo.Visible = false;
                  addRegistro.Visible = false;
                  delRegistro.Visible = false;
                  modRegistro.Visible = false;
                  btnExaminar.Visible = false;
                  txtNombre.ReadOnly = true;
                  cmbEstado.Enabled = false;
                  spinEdicion.Enabled = false;
                  dateVigencia.Enabled = false;
                  dateElaborado.Enabled = false;
                  dateRevisado.Enabled = false;
                  dateAprobado.Enabled = false;
                  dateAutorizado.Enabled = false;
                  cmbElaborado.Enabled = false;
                  cmbRevisado.Enabled = false;
                  cmbAprobado.Enabled = false;
                  cmbAutorizado.Enabled = false;
                  spinVigencia.Enabled = false;
                  spinEjemplar.Enabled = false;
                  txtProcAnterior.ReadOnly = true;
                  cmbNivel.Enabled = false;

              }
            }

            

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error De Aplicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public DateTime getValDate(String date) {
            DateTime dt;
            try
            {
                dt =Convert.ToDateTime(date);
                return dt;
            }
            catch {
                return DateTime.Now.Date;
            }
        
        }

        private void picOk_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result;
                validaModificacion();
                if (statusAll)
                {

                    if (spinEdicion.Value > Convert.ToInt32(edicionDocumento))
                    {
                        result = MessageBox.Show("Esta Seguro de Modificara el  Documento: " + Environment.NewLine + " " + codigoDocumento + Environment.NewLine + " Se actualizara de versión", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            cmbEstado.SelectedIndex = 1;
                            insertDocumento();
                        }
                    }
                    else
                    {
                        result = MessageBox.Show("Esta Seguro Modificar el  Documento: " + Environment.NewLine + " " + codigoDocumento, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            query = "DELETE FROM Anexo Where idDocumento = '" + codigoDocumento + "' and edicion = " + edicionDocumento;
                            response = DataManager.delete(query);

                            if (response.Code != 0)
                            {
                                MessageBox.Show(response.Message, "Error Sql", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            query = "DELETE FROM Registro Where idDocumento = '" + codigoDocumento + "' and edicion = " + edicionDocumento;
                            response = DataManager.delete(query);
                            if (response.Code != 0)
                            {
                                MessageBox.Show(response.Message, "Error Sql", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            query = "DELETE FROM Documento Where idDocumento = '" + codigoDocumento + "' and edicion = " + edicionDocumento;
                            response = DataManager.delete(query);
                            if (response.Code != 0)
                            {
                                MessageBox.Show(response.Message, "Error Sql", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            insertDocumento();
                        }
                    }
                }
            }catch(Exception ex){
                MessageBox.Show(ex.Message, "Error De Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void insertDocumento() {

            String codeDoc = codigoDocumento;
           
            String fecAct = DateTime.Now.ToString();
            String query = "INSERT INTO Documento VALUES("
                                    + "'" + codeDoc + "',"
                                    + "" + spinEdicion.Value + ","
                                    + "'" + cmbTipo.SelectedValue + "',"
                                    + "'" + cmbArea.SelectedValue + "',"
                                    + "'" + cmbSeccion.SelectedValue + "',"
                                    + "" + cmbSubseccion.SelectedValue + ","
                                    + "" + lblCorrelativo.Text + ","
                                    + "'" + cmbNivel.SelectedValue + "',"
                                    + "'" + txtNombre.Text.Trim() + "',"
                                    + "'" + cmbEstado.SelectedItem.ToString() + "',"
                                    + "'" + cmbElaborado.SelectedValue + "',"
                                    + "CONVERT(DATETIME,'" + dateElaborado.Value.Date.ToShortDateString().ToString() + "', 105),"
                                    + "'" + cmbRevisado.SelectedValue + "',"
                                    + getDate(cmbRevisado.SelectedIndex, dateRevisado.Value.Date.ToShortDateString().ToString()) + ","
                                    + "'" + cmbAprobado.SelectedValue + "',"
                                    + getDate(cmbAprobado.SelectedIndex, dateAprobado.Value.Date.ToShortDateString().ToString()) + ","
                                    + "'" + cmbAutorizado.SelectedValue + "',"
                                    + getDate(cmbAutorizado.SelectedIndex, dateAutorizado.Value.Date.ToShortDateString().ToString()) + ","
                                    + "" + spinVigencia.Value + ","
                                    + "" + spinEjemplar.Value + ","
                                    + "'" + txtProcAnterior.Text.Trim() + "',"
                                    + "CONVERT(DATETIME,'" + dateVigencia.Value.Date.ToShortDateString().ToString() + "', 105),"
                                    + "'" + lblLink.Text.Trim() + "')";

            response = DataManager.insert(query);
            if (response.Code != 0)
            {
                MessageBox.Show(response.Message, "Error Sql", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }


            //Graba Log

            listDetalleLog[1].ValDespues = spinEdicion.Value.ToString();
            listDetalleLog[2].ValDespues = cmbNivel.SelectedValue.ToString();
            listDetalleLog[3].ValDespues = txtNombre.Text.Trim();
            listDetalleLog[4].ValDespues = cmbEstado.SelectedItem.ToString();
            listDetalleLog[5].ValDespues = cmbElaborado.SelectedValue.ToString();
            listDetalleLog[6].ValDespues = dateElaborado.Value.Date.ToString();
            listDetalleLog[7].ValDespues = cmbRevisado.SelectedValue.ToString(); 
            listDetalleLog[8].ValDespues = dateRevisado.Value.Date.ToString(); 
            listDetalleLog[9].ValDespues = cmbAprobado.SelectedValue.ToString(); 
            listDetalleLog[10].ValDespues = dateAprobado.Value.Date.ToString(); 
            listDetalleLog[11].ValDespues = cmbAutorizado.SelectedValue.ToString(); 
            listDetalleLog[12].ValDespues = dateAutorizado.Value.Date.ToString(); 
            listDetalleLog[13].ValDespues = spinVigencia.Value.ToString(); 
            listDetalleLog[14].ValDespues = spinEjemplar.Value.ToString(); 
            listDetalleLog[15].ValDespues = txtProcAnterior.Text.Trim(); 
            listDetalleLog[16].ValDespues = dateVigencia.Value.Date.ToString();
            listDetalleLog[17].ValDespues = lblLink.Text;

            DataManager.saveLog("Documento", "UPDATE", usuario, listDetalleLog);
            //Inserta Anexos
            String queryAnexo;
            for (int i = 0; i < grdAnexo.Rows.Count; i++)
            {
                queryAnexo = "INSERT INTO Anexo VALUES("
                         + "'" + codeDoc + "',"
                         + "" + spinEdicion.Value + ","
                         + "" + grdAnexo.Rows[i].Cells[0].Value + ","
                         + "'" + grdAnexo.Rows[i].Cells[1].Value + "',"
                         + "'" + grdAnexo.Rows[i].Cells[2].Value + "',"
                         + "'" + grdAnexo.Rows[i].Cells[3].Value + "',"
                         + "'" + grdAnexo.Rows[i].Cells[4].Value + "',"
                         + "'" + grdAnexo.Rows[i].Cells[5].Value + "',"
                         + "'" + grdAnexo.Rows[i].Cells[6].Value + "')";
                response = DataManager.insert(queryAnexo);
                if (response.Code != 0)
                {
                    MessageBox.Show(response.Message, "Error Sql", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

            }

            //Inserta Registros
            String queryRegistro;
            for (int i = 0; i < grdRegistro.Rows.Count; i++)
            {
                queryRegistro = "INSERT INTO Registro VALUES("
                         + "'" + codeDoc + "',"
                         + "" + spinEdicion.Value + ","
                         + "" + grdRegistro.Rows[i].Cells[0].Value + ","
                         + "'" + grdRegistro.Rows[i].Cells[1].Value + "',"
                         + "'" + grdRegistro.Rows[i].Cells[2].Value + "',"
                         + "'" + grdRegistro.Rows[i].Cells[3].Value + "',"
                         + "'" + grdRegistro.Rows[i].Cells[4].Value + "',"
                         + "'" + grdRegistro.Rows[i].Cells[5].Value + "',"
                         + "'" + grdRegistro.Rows[i].Cells[6].Value + "')";
                response = DataManager.insert(queryRegistro);
                if (response.Code != 0)
                {
                    MessageBox.Show(response.Message, "Error Sql", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

            }

            MessageBox.Show("Modificación de Documento Exitosa", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
            setGrdw();
            this.Close();
        
        }


        public String getDate(int index, String fecha)
        {
            if (index != 0)
            {
                return "CONVERT(DATETIME,'" + fecha + "', 105)";
            }
            else
            {
                return "NULL";
            }
        }

        public void validaModificacion()
        {

            statusAll = true;
            errorProv.SetError(this.cmbEstado, "");
            errorProv.SetError(this.txtNombre, "");
            errorProv.SetError(this.cmbElaborado, "");
            errorProv.SetError(this.cmbRevisado, "");
            errorProv.SetError(this.cmbAprobado, "");
            errorProv.SetError(this.cmbAutorizado, "");
            errorProv.SetError(this.btnExaminar, "");

            if (txtNombre.Text.Trim().Length == 0)
            {
                errorProv.SetError(this.txtNombre, "Ingresa Nombre");
                statusAll = false;
            }

            if (cmbEstado.SelectedIndex == 0)
            {
                errorProv.SetError(this.cmbEstado, "Ingresar Estado");
                statusAll = false;
            }

            if (cmbElaborado.SelectedIndex == 0)
            {
                errorProv.SetError(this.cmbElaborado, "Ingresar Usuario que Elabora el documento");
                statusAll = false;
            }

            if(cmbEstado.SelectedItem.ToString().Equals("Vigente")){
                if (cmbRevisado.SelectedIndex == 0)
                {
                    errorProv.SetError(this.cmbRevisado, "Ingresar Usuario que Revisa el documento");
                    statusAll = false;
                }
                if (cmbAprobado.SelectedIndex == 0)
                {
                    errorProv.SetError(this.cmbAprobado, "Ingresar Usuario que Aprueba el documento");
                    statusAll = false;
                }
                if (cmbAutorizado.SelectedIndex == 0)
                {
                    errorProv.SetError(this.cmbAutorizado, "Ingresar Usuario que Autoriza el documento");
                    statusAll = false;
                }
                if (lblLink.Text.Trim().Length == 0)
                {
                    errorProv.SetError(this.btnExaminar, "Ingresar Link De Documento");
                    statusAll = false;
                }
            }

        }

        private void picCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                lblLink.Text = openFileDialog1.FileName;

            }
        }

        private void addAnexo_Click(object sender, EventArgs e)
        {
            RegistroAnexo nuevo = new RegistroAnexo("A", grdAnexo, "Alta");
            nuevo.ShowDialog();
        }

        private void modAnexo_Click(object sender, EventArgs e)
        {
            if (grdAnexo.Rows.Count > 0)
            {
                RegistroAnexo nuevo = new RegistroAnexo("A", grdAnexo, "Modificacion");
                nuevo.ShowDialog();
            }
        }

        private void delAnexo_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdAnexo.Rows.Count > 0)
                {           
                    grdAnexo.Rows[grdAnexo.CurrentCellAddress.Y].Cells[2].Value = "";
                    grdAnexo.Rows[grdAnexo.CurrentCellAddress.Y].Cells[3].Value = "";
                    grdAnexo.Rows[grdAnexo.CurrentCellAddress.Y].Cells[4].Value = "";
                    grdAnexo.Rows[grdAnexo.CurrentCellAddress.Y].Cells[5].Value = "";
                    grdAnexo.Rows[grdAnexo.CurrentCellAddress.Y].Cells[6].Value = "";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error De Aplicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addRegistro_Click(object sender, EventArgs e)
        {
            RegistroAnexo nuevo = new RegistroAnexo("R", grdRegistro, "Alta");
            nuevo.ShowDialog();
        }

        private void delRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdRegistro.Rows.Count > 0)
                {
                    grdRegistro.Rows[grdRegistro.CurrentCellAddress.Y].Cells[2].Value = "";
                    grdRegistro.Rows[grdRegistro.CurrentCellAddress.Y].Cells[3].Value = "";
                    grdRegistro.Rows[grdRegistro.CurrentCellAddress.Y].Cells[4].Value = "";
                    grdRegistro.Rows[grdRegistro.CurrentCellAddress.Y].Cells[5].Value = "";
                    grdRegistro.Rows[grdRegistro.CurrentCellAddress.Y].Cells[6].Value = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error De Aplicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modRegistro_Click(object sender, EventArgs e)
        {
            if (grdRegistro.Rows.Count > 0)
            {
                RegistroAnexo nuevo = new RegistroAnexo("R", grdRegistro, "Modificacion");
                nuevo.ShowDialog();
            }
        }

        private void lblLink_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(lblLink.Text);
            }
            catch(Exception ex) {

                MessageBox.Show(ex.Message, "Error Al abrir Archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void grdRegistro_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            RegistroAnexo nuevo = new RegistroAnexo("R", grdRegistro, "Consulta");
            nuevo.ShowDialog();
        }

        private void grdAnexo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            RegistroAnexo nuevo = new RegistroAnexo("A", grdAnexo, "Consulta");
            nuevo.ShowDialog();
        }
    }
}
