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
    public partial class Usuarios : Form
    {

        public DataSet ds;
        private String user;
        private String rol;
        private script.ResponseSql response;
        public Usuarios(String us, String rl)
        {
            this.user = us;
            this.rol = rl;

            InitializeComponent();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
           setGrdw();
        }

        public void setGrdw()
        {
            
            ds = DataManager.selTab("select idUsuario AS 'usuario', nombre, cargo, rol from Usuario","Usuario");
            grd.DataSource = ds;
            grd.DataMember ="Usuario";
        }

    
        private void picRefrescar_Click(object sender, EventArgs e)
        {
          setGrdw();
        }

        //busqueda en grid
        private void picBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombre.Text.Length > 0 && txtUsuario.Text.Length > 0)
                {
                    ds = DataManager.selTab("select idUsuario AS 'usuario', nombre, cargo, rol from Usuario where idUsuario like '" + txtUsuario.Text + "%' and nombre like '%" + txtNombre.Text + "%'", "Usuario");
                    grd.DataSource = ds;
                    grd.DataMember = "Usuario";
                }
                else if (txtUsuario.Text.Length > 0)
                {

                    ds = DataManager.selTab("select idUsuario AS 'usuario', nombre, cargo, rol from Usuario where idUsuario like '" + txtUsuario.Text + "%'", "Usuario");
                    grd.DataSource = ds;
                    grd.DataMember = "Usuario";
                }
                else if (txtNombre.Text.Length > 0)
                {
                    ds = DataManager.selTab("select idUsuario AS 'usuario', nombre, cargo, rol from Usuario where nombre like '%" + txtNombre.Text + "%'", "Usuario");
                    grd.DataSource = ds;
                    grd.DataMember = "Usuario";
                }
            }catch(Exception ex){
                MessageBox.Show(ex.Message, "Error De Aplicacion",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void picAgregar_Click(object sender, EventArgs e)
        {
            Usuario alta = new Usuario("A","",grd);
            alta.ShowDialog();
        }

        private void picEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (grd.Rows.Count > 0)
                {

                    if (!grd[3, grd.CurrentCellAddress.Y].Value.ToString().Equals("sysadmin"))
                    {
                        String usuario = grd[0, grd.CurrentCellAddress.Y].Value.ToString();
                        DialogResult result;
                        result = MessageBox.Show("Esta Seguro de eliminar al usuario: " + usuario, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes && usuario.Length > 0)
                        {
                            String query = "DELETE FROM Usuario Where idUsuario = '" + usuario + "'";
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
                    else {
                        MessageBox.Show("No se permite eliminar sysadmin", "Error al Borrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if(grd.Rows.Count > 0){
                String usuario = grd[0, grd.CurrentCellAddress.Y].Value.ToString();
                Usuario modificacion = new Usuario("M", usuario,grd);
                modificacion.ShowDialog();
            }
        }    
    }
}
