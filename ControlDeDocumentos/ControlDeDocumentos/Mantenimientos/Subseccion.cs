using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlDeDocumentos.Mantenimientos
{
    public partial class Subseccion : Form
    {

        private String operacion;
        private Boolean status;
        private String query;
        private String codigo;
        private script.Section seccion;
        private script.ResponseSql response;
        private DataGridView grd;
        private  DataSet ds;
        private int genCode;

        public Subseccion(String op, String cod, DataGridView dtg, script.Section Sec)
        {

            this.grd = dtg;
            this.operacion = op;
            this.codigo = cod;
            this.seccion = Sec;
            InitializeComponent();
        }

        private void Subseccion_Load(object sender, EventArgs e)
        {
            lblCodSeccion.Text = seccion.Code;
            lblDesSeccion.Text = seccion.Message;

            if (operacion.Equals("A"))
            {
                lblTitulo.Text = "Alta de Sub-Sección";
                genCode = getCorr();
                lblCodigo.Text = genCode.ToString();

            }
            else
            {

                lblTitulo.Text = "Modificiacón de Sub-sección";
             
                DataSet ds = DataManager.selTab("Select * from SubSeccion Where idSeccion = '" + seccion.Code + "' And idSubSeccion = " + codigo, "SubSeccion");
                foreach (DataRow row in ds.Tables["SubSeccion"].Rows)
                {
                    lblCodigo.Text = codigo;
                    txtDescripcion.Text = row[2].ToString();

                }
                txtDescripcion.Focus();
            }


        }

        public int getCorr() {

            String corr ="";
            int max = 0;
            DataSet ds = DataManager.selTab("select MAX(idSubSeccion) from SubSeccion where idSeccion = '" + seccion.Code + "'", "SubSeccion");
            foreach (DataRow row in ds.Tables["SubSeccion"].Rows)
            {
                corr = row[0].ToString();
            }
            try
            {
                max = Convert.ToInt32(corr);
                return max + 1;
            }
            catch {
                return 1;
            }
            
        }

        private void picOk_Click(object sender, EventArgs e)
        {
            ok();
        }

        private void picCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void cleanControls()
        {
            genCode = getCorr();
            lblCodigo.Text = genCode.ToString();
            txtDescripcion.Text = "";
        }

        //Valida datos ingresados
        public void validarDatos()
        {
            status = true;

            errorProv.SetError(this.txtDescripcion, "");

            if (txtDescripcion.Text.Trim().Length == 0)
            {
                errorProv.SetError(this.txtDescripcion, "Ingresar Descripción");
                status = false;
            }
        }

        public void setGrdw()
        {
            ds = DataManager.selTab("select idSubSeccion AS 'Sub-Seccion', descripcion AS 'Descripcion' from SubSeccion where idSeccion = '" + seccion.Code + "'", "SubSeccion");
            grd.DataSource = ds;
            grd.DataMember = "SubSeccion";
        }

        public void ok()
        {
            validarDatos();
            if (status)
            {

                if (operacion.Equals("A"))
                {
                    query = "INSERT INTO SubSeccion VALUES("
                          + "'" + seccion.Code + "',"
                          + "" + genCode + ","
                          + "'" + txtDescripcion.Text.Trim() + "')";

                    response = DataManager.insert(query);
                    if (response.Code == 0)
                    {
                        MessageBox.Show(response.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cleanControls();
                        txtDescripcion.Focus();
                        setGrdw();
                    }
                    else
                    {
                        MessageBox.Show(response.Message, "Error Sql", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (operacion.Equals("M"))
                {

                    query = "UPDATE SubSeccion SET "
                        + "descripcion ='" + txtDescripcion.Text.Trim() + "' where idSeccion = '" + seccion.Code + "' and idSubSeccion = " + codigo;

                    response = DataManager.update(query);
                    if (response.Code == 0)
                    {
                        MessageBox.Show(response.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        setGrdw();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(response.Message, "Error Sql", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ok();
            }
        }
    }
}
