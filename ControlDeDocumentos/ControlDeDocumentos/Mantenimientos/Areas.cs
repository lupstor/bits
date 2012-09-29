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
    public partial class Areas : Form
    {

        public DataSet ds;
        private script.ResponseSql response;

        public Areas()
        {
            InitializeComponent();
        }

        private void Areas_Load(object sender, EventArgs e)
        {
            setGrdw();
        }


        public void setGrdw()
        {
            ds = DataManager.selTab("select idArea AS 'Area', descripcion AS 'Descripcion' from Area", "Area");
            grd.DataSource = ds;
            grd.DataMember = "Area";
        }

        private void picBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text.Length > 0 && txtDescripcion.Text.Length > 0)
                {
                    ds = DataManager.selTab("select idArea AS 'Area', descripcion AS 'Descripcion' from Area where idArea like '" + txtCodigo.Text + "%' and descripcion like '%" + txtDescripcion.Text + "%'", "Area");
                    grd.DataSource = ds;
                    grd.DataMember = "Area";
                }
                else if (txtCodigo.Text.Length > 0)
                {
                    ds = DataManager.selTab("select idArea AS 'Area', descripcion AS 'Descripcion' from Area where idArea like '" + txtCodigo.Text + "%'", "Area");
                    grd.DataSource = ds;
                    grd.DataMember = "Area";
                }
                else if (txtDescripcion.Text.Length > 0)
                {
                    ds = DataManager.selTab("select idArea AS 'Area', descripcion AS 'Descripcion' from Area where descripcion like '%" + txtDescripcion.Text + "%'", "Area");
                    grd.DataSource = ds;
                    grd.DataMember = "Area";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error De Aplicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void picEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (grd.Rows.Count > 0)
                {
                        String cod = grd[0, grd.CurrentCellAddress.Y].Value.ToString();
                        DialogResult result;
                        result = MessageBox.Show("Esta Seguro de eliminar el Area: " + cod, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes && cod.Length > 0)
                        {
                            String query = "DELETE FROM Area Where idArea = '" + cod + "'";
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

        private void picRefrescar_Click(object sender, EventArgs e)
        {
            setGrdw();
        }

        private void picAgregar_Click(object sender, EventArgs e)
        {
            Area nuevo = new Area("A", "",grd);
            nuevo.ShowDialog();
        }

        private void picModificar_Click(object sender, EventArgs e)
        {
            if (grd.Rows.Count > 0)
            {
                String cod = grd[0, grd.CurrentCellAddress.Y].Value.ToString();
                Area nuevo = new Area("M", cod,grd);
                nuevo.ShowDialog();
            }
        }




    }
}
