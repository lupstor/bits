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
    public partial class Subsecciones : Form
    {

        private DataSet ds;
        private script.ResponseSql response;
        private script.Section seccion;

        public Subsecciones(script.Section Sec)
        {
            this.seccion = Sec;
            InitializeComponent();
        }

        private void Subsecciones_Load(object sender, EventArgs e)
        {
            lblCodigo.Text = seccion.Code;
            lblDescripcion.Text = seccion.Message;
            setGrdw();
        }

        public void setGrdw()
        {
            ds = DataManager.selTab("select idSubSeccion AS 'Sub-Seccion', descripcion AS 'Descripcion' from SubSeccion where idSeccion = '" + seccion.Code + "'", "SubSeccion");
            grd.DataSource = ds;
            grd.DataMember = "SubSeccion";
        }


        private void picBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text.Length > 0 && txtDescripcion.Text.Length > 0)
                {
                    ds = DataManager.selTab("select idSubSeccion AS 'SubSeccion', descripcion AS 'Descripcion' from SubSeccion where idSubSeccion like '" + txtCodigo.Text + "%' and descripcion like '%" + txtDescripcion.Text + "%' and idSeccion = '" + seccion.Code + "'", "SubSeccion");
                    grd.DataSource = ds;
                    grd.DataMember = "SubSeccion";
                }
                else if (txtCodigo.Text.Length > 0)
                {
                    ds = DataManager.selTab("select idSubSeccion AS 'SubSeccion', descripcion AS 'Descripcion' from SubSeccion where idSubSeccion like '" + txtCodigo.Text + "%' and idSeccion = '" + seccion.Code + "'", "SubSeccion");
                    grd.DataSource = ds;
                    grd.DataMember = "SubSeccion";
                }
                else if (txtDescripcion.Text.Length > 0)
                {
                    ds = DataManager.selTab("select idSubSeccion AS 'SubSeccion', descripcion AS 'Descripcion' from SubSeccion where descripcion like '%" + txtDescripcion.Text + "%' and idSeccion = '" + seccion.Code + "'", "SubSeccion");
                    grd.DataSource = ds;
                    grd.DataMember = "SubSeccion";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error De Aplicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void picAgregar_Click(object sender, EventArgs e)
        {
            Subseccion nuevo = new Subseccion("A", "", grd, seccion);
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
                    result = MessageBox.Show("Esta Seguro de eliminar la Sub-Seccion: " + seccion.Code + "-" + cod, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes && cod.Length > 0)
                    {
                           String query = "UPDATE SubSeccion SET descripcion ='' where idSeccion = '" + seccion.Code + "' and idSubSeccion = " + cod;
                        response = DataManager.update(query);

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
                Subseccion nuevo = new Subseccion("M", cod, grd,seccion);
                nuevo.ShowDialog();
            }
        }

        private void picRefrescar_Click(object sender, EventArgs e)
        {
            setGrdw();
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
             if (Char.IsDigit(e.KeyChar))

        {

            e.Handled = false;

       }

        else if (Char.IsControl(e.KeyChar))

       {

           e.Handled = false;

       }

      else if (Char.IsSeparator(e.KeyChar))

       {

           e.Handled = false;

       }

      else

      {

           e.Handled = true;

       }
       }
    }
}
