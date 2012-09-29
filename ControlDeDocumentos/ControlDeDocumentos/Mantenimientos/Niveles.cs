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
    public partial class Niveles : Form
    {

        public DataSet ds;
        private script.ResponseSql response;

        public Niveles()
        {
            InitializeComponent();
        }

        private void Niveles_Load(object sender, EventArgs e)
        {
            setGrdw();
        }

        public void setGrdw()
        {
            ds = DataManager.selTab("select idNivel AS 'Nivel', descripcion AS 'Descripcion', prioridad AS 'Prioridad' from Nivel", "Nivel");
            grd.DataSource = ds;
            grd.DataMember = "Nivel";
        }

        private void picAgregar_Click(object sender, EventArgs e)
        {
            Nivel nuevo = new Nivel("A", "", grd);
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
                    result = MessageBox.Show("Esta Seguro de eliminar el Nivel: " + cod, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes && cod.Length > 0)
                    {
                        String query = "DELETE FROM Nivel Where idNivel = '" + cod + "'";
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
                Nivel nuevo = new Nivel("M", cod, grd);
                nuevo.ShowDialog();
            }
        }

        private void picRefrescar_Click(object sender, EventArgs e)
        {
            setGrdw();
           
        }

        private void picBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text.Length > 0 && txtDescripcion.Text.Length > 0)
                {
                    ds = DataManager.selTab("select idNivel AS 'Nivel', descripcion AS 'Descripcion', prioridad AS 'Prioridad' from Nivel where idNivel like '" + txtCodigo.Text + "%' and descripcion like '%" + txtDescripcion.Text + "%'", "Nivel");
                    grd.DataSource = ds;
                    grd.DataMember = "Nivel";
                }
                else if (txtCodigo.Text.Length > 0)
                {
                    ds = DataManager.selTab("select idNivel AS 'Nivel', descripcion AS 'Descripcion', prioridad AS 'Prioridad' from Nivel where idNivel like '" + txtCodigo.Text + "%'", "Nivel");
                    grd.DataSource = ds;
                    grd.DataMember = "Nivel";
                }
                else if (txtDescripcion.Text.Length > 0)
                {
                    ds = DataManager.selTab("select idNivel AS 'Nivel', descripcion AS 'Descripcion', prioridad AS 'Prioridad' from Nivel where descripcion like '%" + txtDescripcion.Text + "%'", "Nivel");
                    grd.DataSource = ds;
                    grd.DataMember = "Nivel";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error De Aplicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
