using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace ControlDeDocumentos.Login
{
    public partial class Login : Form
    {

        private ToolStripStatusLabel rol;
        private ToolStripStatusLabel user;
        private ToolStripMenuItem msUsuarios;
        private ToolStripMenuItem msTipos;
        private ToolStripMenuItem msAreas;
        private ToolStripMenuItem msSecciones;
        private ToolStripMenuItem msNiveles;
        private ToolStripMenuItem msAprobacion;
        private ToolStripMenuItem msDocumentos;
        private ToolStripMenuItem msLog;
        private ToolStripMenuItem msModulos;
        private ToolStripMenuItem msCerrar;
        private Boolean status;


        public Login(ToolStripStatusLabel rl, ToolStripStatusLabel us, ToolStripMenuItem i1, ToolStripMenuItem i2, ToolStripMenuItem i3, ToolStripMenuItem i4, ToolStripMenuItem i5, ToolStripMenuItem i6, ToolStripMenuItem i7, ToolStripMenuItem i8, ToolStripMenuItem i9, ToolStripMenuItem i10)
        {
            rol = rl;
            user = us;
            msUsuarios = i1;
            msTipos = i2;
            msAreas = i3;
            msSecciones = i4;
            msNiveles = i5;
            msAprobacion = i6;
            msDocumentos = i7;
            msLog = i8;
            msModulos = i9;
            msCerrar = i10;
            InitializeComponent();
        }

      
        //Validacion de usuario
        private Boolean valCredentials(String usuario, String pwd)
        {
            try
            {
                DataSet ds = null;

                int statBit = 0;

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "ValUser";
                command.CommandTimeout = 20;

                command.Parameters.AddWithValue("@Usuario", usuario);
                command.Parameters.AddWithValue("@Passwd", pwd);

                SqlParameter countParameter = new SqlParameter("@ExisteCta", 0);
                countParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(countParameter);

                command.Connection = DataManager.cnn();

                command.ExecuteNonQuery();
                if (command.Parameters["@ExisteCta"].Value != DBNull.Value)
                {
                    statBit = int.Parse(command.Parameters["@ExisteCta"].Value.ToString());

                }

                if (statBit == 1)
                {
                    ds = DataManager.selTab("Select rol from Usuario Where idUsuario = '" + usuario + "'", "Usuario");
                    foreach (DataRow row in ds.Tables["Usuario"].Rows)
                    {
                        rol.Text = row[0].ToString();
                    }
                    setMenu(rol.Text);
                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error De Aplicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return false;
        }

        //Setea el menu segun rol de usuario
        public void setMenu(String rol)
        {
            if (rol.Equals("sysadmin"))
            {
                msUsuarios.Visible = true;
                msTipos.Visible = true;
                msAreas.Visible = true;
                msSecciones.Visible = true;
                msNiveles.Visible = true;
                msAprobacion.Visible = true;
                msDocumentos.Visible = true;
                msLog.Visible = true;
                msModulos.Visible = true;


            }
            else if (rol.Equals("superusuario"))
            {
                msUsuarios.Visible = false;
                msTipos.Visible = true;
                msAreas.Visible = true;
                msSecciones.Visible = true;
                msNiveles.Visible = true;
                msAprobacion.Visible = true;
                msDocumentos.Visible = true;
                msLog.Visible = false;
                msModulos.Visible = true;

            }
            else if (rol.Equals("regular"))
            {
                msUsuarios.Visible = false;
                msTipos.Visible = false;
                msAreas.Visible = false;
                msSecciones.Visible = false;
                msNiveles.Visible = false;
                msAprobacion.Visible = false;
                msDocumentos.Visible = true;
                msLog.Visible = false;
                msModulos.Visible = true;

            }
            else
            {
                msModulos.Visible = false;
            }
        }

     
        //Valida credenciales de usuario
        public void validar()
        {
            status = true;
            errLogin.SetError(this.txtUser, "");
            errLogin.SetError(this.txtPassword, "");

            if (txtUser.Text.Length == 0)
            {
                errLogin.SetError(this.txtUser, "Ingresar Usuario");
                status = false;
            }
            if (txtPassword.Text.Length == 0)
            {
                errLogin.SetError(this.txtPassword, "Ingresar Password");
                status = false;
            }
        }

        //Parametros de autenticacion
        public void getLogin()
        {
            if (valCredentials(txtUser.Text.Trim(), txtPassword.Text.Trim()))
            {
                user.Text = txtUser.Text;
                txtUser.Text = "";
                txtPassword.Text = "";
                msCerrar.Enabled = true;
                this.Close();
            }
            else
            {
                txtUser.Text = "";
                txtPassword.Text = "";
                txtUser.Focus();
                MessageBox.Show("Inicio de Sesión Invaldio", "Error Login",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUser.Focus();
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!status)
            {
                e.Cancel = true;
            }
            else {
                e.Cancel = false;
            }
        }

        private void picOk_Click(object sender, EventArgs e)
        {
            validar();
            if (status)
            {
                getLogin();
            }
        }

        private void picCancel_Click(object sender, EventArgs e)
        {
           Environment.Exit(0);
        }

        private void txtUser_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                validar();
                if (status)
                {
                    getLogin();
                }
            }
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                validar();
                if (status)
                {
                    getLogin();
                }
            }
        }

      
    }
}
