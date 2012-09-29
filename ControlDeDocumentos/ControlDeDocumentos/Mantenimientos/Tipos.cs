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
    public partial class Tipos : Form
    {

        public DataSet ds;
        private script.ResponseSql response;
        public Tipos()
        {
            InitializeComponent();
        }

        private void Tipos_Load(object sender, EventArgs e)
        {
            setGrdw();
        }

        public void setGrdw()
        {
            ds = DataManager.selTab("select idTipoDocumento AS 'Tipo De Documento', descripcion AS 'Descripcion' from TipoDocumento", "TipoDocumento");
            grd.DataSource = ds;
            grd.DataMember = "TipoDocumento";
        }

        private void picBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text.Length > 0 && txtDescripcion.Text.Length > 0)
                {
                    ds = DataManager.selTab("select idTipoDocumento AS 'Tipo De Documento', descripcion AS 'Descripcion' from TipoDocumento where idTipoDocumento like '" + txtCodigo.Text + "%' and descripcion like '%" + txtDescripcion.Text + "%'", "TipoDocumento");
                    grd.DataSource = ds;
                    grd.DataMember = "TipoDocumento";
                }
                else if (txtCodigo.Text.Length > 0)
                {
                    ds = DataManager.selTab("select idTipoDocumento AS 'Tipo De Documento', descripcion AS 'Descripcion' from TipoDocumento where idTipoDocumento like '" + txtCodigo.Text + "%'", "TipoDocumento");
                    grd.DataSource = ds;
                    grd.DataMember = "TipoDocumento";
                }
                else if (txtDescripcion.Text.Length > 0)
                {
                    ds = DataManager.selTab("select idTipoDocumento AS 'Tipo De Documento', descripcion AS 'Descripcion' from TipoDocumento where descripcion like '%" + txtDescripcion.Text + "%'", "TipoDocumento");
                    grd.DataSource = ds;
                    grd.DataMember = "TipoDocumento";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error De Aplicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
       

        private void picAgregar_Click(object sender, EventArgs e)
        {
            Tipo nuevo = new Tipo("A", "", grd);
            nuevo.ShowDialog();
        }

     
        private void picEliminar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (grd.Rows.Count > 0)
                {
                    String cod = grd[0, grd.CurrentCellAddress.Y].Value.ToString();
                    DialogResult result;
                    result = MessageBox.Show("Esta Seguro de eliminar el Tipo: " + cod, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes && cod.Length > 0)
                    {
                        String query = "DELETE FROM TipoDocumento Where idTipoDocumento = '" + cod + "'";
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

        private void picModificar_Click_1(object sender, EventArgs e)
        {
            if (grd.Rows.Count > 0)
            {
                String cod = grd[0, grd.CurrentCellAddress.Y].Value.ToString();
                Tipo nuevo = new Tipo("M", cod, grd);
                nuevo.ShowDialog();
            }
        }

        private void picRefrescar_Click_1(object sender, EventArgs e)
        {
            setGrdw();
        }

    }
}
