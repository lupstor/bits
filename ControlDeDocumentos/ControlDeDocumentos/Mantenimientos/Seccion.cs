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
    public partial class Seccion : Form
    {

        private String operacion;
        private Boolean status;
        private String query;
        private String codigo;
        private script.ResponseSql response;
        private DataGridView grd;
        public DataSet ds;

        public Seccion(String op, String cod, DataGridView dtg)
        {
            this.grd = dtg;
            this.operacion = op;
            this.codigo = cod;
            InitializeComponent();
        }

        private void Seccion_Load(object sender, EventArgs e)
        {
            if (operacion.Equals("A"))
            {
                lblTitulo.Text = "Alta de Seccion";

            }
            else
            {

                lblTitulo.Text = "Modificiacón de Seccion";
                txtCodigo.Enabled = false;
                DataSet ds = DataManager.selTab("Select * from Seccion Where idSeccion = '" + codigo + "'", "Seccion");
                foreach (DataRow row in ds.Tables["Seccion"].Rows)
                {
                    txtCodigo.Text = codigo;
                    txtDescripcion.Text = row[1].ToString();

                }
                txtDescripcion.Focus();
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
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
        }

        //Valida datos ingresados
        public void validarDatos()
        {
            status = true;

            errorProv.SetError(this.txtCodigo, "");
            errorProv.SetError(this.txtDescripcion, "");


            if (txtCodigo.Text.Trim().Length == 0)
            {
                errorProv.SetError(this.txtCodigo, "Ingresar Código");
                status = false;
            }

            if (txtDescripcion.Text.Trim().Length == 0)
            {
                errorProv.SetError(this.txtDescripcion, "Ingresar Descripción");
                status = false;
            }
        }

        public void setGrdw()
        {
            ds = DataManager.selTab("select idSeccion AS 'Seccion', descripcion AS 'Descripcion' from Seccion", "Seccion");
            grd.DataSource = ds;
            grd.DataMember = "Seccion";
        }

        public void ok() {

            validarDatos();
            if (status)
            {

                if (operacion.Equals("A"))
                {
                    query = "INSERT INTO Seccion VALUES("
                          + "'" + txtCodigo.Text.Trim() + "',"
                          + "'" + txtDescripcion.Text.Trim() + "')";

                    response = DataManager.insert(query);
                    if (response.Code == 0)
                    {
                        MessageBox.Show(response.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cleanControls();
                        txtCodigo.Focus();
                        setGrdw();
                    }
                    else
                    {
                        MessageBox.Show(response.Message, "Error Sql", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (operacion.Equals("M"))
                {

                    query = "UPDATE Seccion SET "
                          + "descripcion ='" + txtDescripcion.Text.Trim() + "' where idSeccion = '" + codigo + "'";

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

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ok();
            }
        }
    }
}
