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
    public partial class Secciones : Form
    {

        public DataSet ds;
        private script.ResponseSql response;

        public Secciones()
        {
            InitializeComponent();
        }

        public void setGrdw()
        {
            ds = DataManager.selTab("select idSeccion AS 'Seccion', descripcion AS 'Descripcion' from Seccion", "Seccion");
            grd.DataSource = ds;
            grd.DataMember = "Seccion";
        }
        private void picBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text.Length > 0 && txtDescripcion.Text.Length > 0)
                {
                    ds = DataManager.selTab("select idSeccion AS 'Seccion', descripcion AS 'Descripcion' from Seccion where idSeccion like '" + txtCodigo.Text + "%' and descripcion like '%" + txtDescripcion.Text + "%'", "Seccion");
                    grd.DataSource = ds;
                    grd.DataMember = "Seccion";
                }
                else if (txtCodigo.Text.Length > 0)
                {
                    ds = DataManager.selTab("select idSeccion AS 'Seccion', descripcion AS 'Descripcion' from Seccion where idSeccion like '" + txtCodigo.Text + "%'", "Seccion");
                    grd.DataSource = ds;
                    grd.DataMember = "Seccion";
                }
                else if (txtDescripcion.Text.Length > 0)
                {
                    ds = DataManager.selTab("select idSeccion AS 'Seccion', descripcion AS 'Descripcion' from Seccion where descripcion like '%" + txtDescripcion.Text + "%'", "Seccion");
                    grd.DataSource = ds;
                    grd.DataMember = "Seccion";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error De Aplicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void picAgregar_Click(object sender, EventArgs e)
        {
            Seccion nuevo = new Seccion("A", "", grd);
            nuevo.ShowDialog();
        }

        private void picEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (grd.Rows.Count > 0)
                {
                    String cod = grd[0, grd.CurrentCellAddress.Y].Value.ToString();
                    DialogResult result;
                    result = MessageBox.Show("Esta Seguro de eliminar la Seccion: " + cod, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes && cod.Length > 0)
                    {
                        String query = "DELETE FROM Seccion Where idSeccion = '" + cod + "'";
                        response = DataManager.delete(query);

                        if (response.Code == 0)
                        {
                            setGrdw();
                        }
                        else
                        {
                            MessageBox.Show(response.Message, "Error Sql", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error De Aplicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void picModificar_Click(object sender, EventArgs e)
        {
            if (grd.Rows.Count > 0)
            {
                String cod = grd[0, grd.CurrentCellAddress.Y].Value.ToString();
                Seccion nuevo = new Seccion("M", cod, grd);
                nuevo.ShowDialog();
            }
        }

        private void picRefrescar_Click(object sender, EventArgs e)
        {
            setGrdw();
        }

        private void Secciones_Load(object sender, EventArgs e)
        {
            setGrdw();
        }

        private void btnSubsecciones_Click(object sender, EventArgs e)
        {
            if (grd.Rows.Count > 0)
            {
                String cod = grd[0, grd.CurrentCellAddress.Y].Value.ToString();
                String des = grd[1, grd.CurrentCellAddress.Y].Value.ToString();
                Subsecciones nuevo = new Subsecciones(new script.Section(cod,des));
                nuevo.ShowDialog();
            }
        }

       
    }
}
