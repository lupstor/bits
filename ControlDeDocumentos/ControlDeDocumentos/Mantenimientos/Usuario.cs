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
    public partial class Usuario : Form
    {
        private String operacion;
        private Boolean status;
        private String query;
        private String codigo;
        private String userRol;
        private script.ResponseSql response;
        DataGridView grd;
        DataSet ds;
        public Usuario(String op,String cod, DataGridView gr)
        {
             this.grd = gr;
             this.operacion = op;
             this.codigo = cod;
             InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Usuario_Load(object sender, EventArgs e)
        {

            if (operacion.Equals("A"))
            {
                lblTitulo.Text = "Alta de Usuario";
                List<script.Combo> lista = new List<script.Combo>();
                lista.Add(new script.Combo("<Seleccionar>", "<Seleccionar>"));
                lista.Add(new script.Combo("superusuario", "Super Usuario"));
                lista.Add(new script.Combo("regular", "Regular"));
                cmbRol.DataSource = lista;
                cmbRol.ValueMember = "code";
                cmbRol.DisplayMember = "description";
                cmbRol.SelectedIndex = 0;
            }
            else
            {

                lblTitulo.Text = "Modificiacón de Usuario";
                txtUsuario.Text = codigo;
                txtUsuario.Enabled = false;
                txtPassword.Enabled = false;
                txtCPassword.Enabled = false;
                chkPassword.Visible = true;

                
                DataSet ds = DataManager.selTab("Select * from Usuario Where idUsuario = '" + codigo + "'", "Usuario");
                foreach (DataRow row in ds.Tables["Usuario"].Rows)
                {

                    txtNombre.Text = row[2].ToString();
                    txtCargo.Text = row[3].ToString();
                    userRol = row[4].ToString();

                    List<script.Combo> lista = new List<script.Combo>();
                    lista.Add(new script.Combo("<Seleccionar>", "<Seleccionar>"));
                    lista.Add(new script.Combo("superusuario", "Super Usuario"));
                    lista.Add(new script.Combo("regular", "Regular"));
                    cmbRol.DataSource = lista;
                    cmbRol.ValueMember = "code";
                    cmbRol.DisplayMember = "description";
                
                   if (userRol.Equals("superusuario"))
                    {
                        cmbRol.SelectedIndex = 1;
                    }
                    else if (userRol.Equals("regular"))
                    {
                        cmbRol.SelectedIndex = 2;
                    }else  if (userRol.Equals("sysadmin"))
                    {
                        cmbRol.Enabled = false;
                    }
                    txtNombre.Focus();
                }
            }
            
           
        }

        private void picCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
        private void picOk_Click(object sender, EventArgs e)
        {
            ok();
        }

        public void cleanControls() {
            txtUsuario.Text = "";
            txtPassword.Text = "";
            txtCPassword.Text = "";
            txtCargo.Text = "";
            txtNombre.Text = "";
            cmbRol.SelectedIndex = 0;
        }

      

        //Valida datos ingresados
        public void validarDatos() {
            status = true;

            errUsuario.SetError(this.txtUsuario, "");
            errUsuario.SetError(this.txtPassword, "");
            errUsuario.SetError(this.txtCPassword, "");
            errUsuario.SetError(this.txtNombre, "");
            errUsuario.SetError(this.txtCargo, "");
            errUsuario.SetError(this.cmbRol, "");

            if (txtUsuario.Text.Trim().Length == 0)
            {
                errUsuario.SetError(this.txtUsuario, "Ingresar Usuario");
                status = false;
            }

            if (operacion.Equals("A") || chkPassword.Checked)
            {
                if (txtPassword.Text.Trim().Length == 0)
                {
                    errUsuario.SetError(this.txtPassword, "Ingresar Password");
                    status = false;
                }

                if (txtPassword.Text != txtCPassword.Text)
                {
                    errUsuario.SetError(this.txtCPassword, "Password no coincide con aterior");
                    status = false;
                }
            }


            if (txtNombre.Text.Trim().Length == 0)
            {
                errUsuario.SetError(this.txtNombre, "Ingresar Nombre");
                status = false;
            }
            if (txtCargo.Text.Trim().Length == 0)
            {
                errUsuario.SetError(this.txtCargo, "Ingresar Cargo");
                status = false;
            }

            if (operacion.Equals("A"))
            {
                if (cmbRol.SelectedIndex == 0)
                {
                    errUsuario.SetError(this.cmbRol, "Seleccionar un Rol");
                    status = false;
                }
            }
            else {
                if (!userRol.Equals("sysadmin"))
                {
                    if (cmbRol.SelectedIndex == 0)
                    {
                        errUsuario.SetError(this.cmbRol, "Seleccionar un Rol");
                        status = false;
                    }
                }
            }
            
        }

        private void chkPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPassword.Checked)
            {
                txtPassword.Enabled = true;
                txtCPassword.Enabled = true;
            }
            else {
                txtPassword.Text = "";
                txtCPassword.Text = "";
                errUsuario.SetError(this.txtCPassword, "");
                errUsuario.SetError(this.txtPassword, "");
                txtPassword.Enabled = false;
                txtCPassword.Enabled = false;
            }
        }

        public void setGrdw()
        {

            ds = DataManager.selTab("select idUsuario AS 'usuario', nombre, cargo, rol from Usuario", "Usuario");
            grd.DataSource = ds;
            grd.DataMember = "Usuario";
        }

        public void ok() {
            validarDatos();
            if (status)
            {

                if (operacion.Equals("A"))
                {
                    query = "INSERT INTO Usuario VALUES("
                      + "'" + txtUsuario.Text.Trim() + "',"
                      + "pwdencrypt('" + txtPassword.Text + "'),"
                      + "'" + txtNombre.Text.Trim() + "',"
                      + "'" + txtCargo.Text.Trim() + "',"
                      + "'" + cmbRol.SelectedValue + "','No','No','No','No')";
                    response = DataManager.insert(query);
                    if (response.Code == 0)
                    {
                        MessageBox.Show(response.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cleanControls();
                        txtUsuario.Focus();
                        setGrdw();
                    }
                    else
                    {
                        MessageBox.Show(response.Message, "Error Sql", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (operacion.Equals("M"))
                {

                    if (chkPassword.Checked)
                    {
                        query = "UPDATE Usuario SET "
                              + "userPassword = pwdencrypt('" + txtPassword.Text + "'),"
                              + "nombre ='" + txtNombre.Text.Trim() + "',"
                              + "cargo ='" + txtCargo.Text + "'";

                    }
                    else
                    {
                        query = "UPDATE Usuario SET "
                              + "nombre ='" + txtNombre.Text.Trim() + "',"
                              + "cargo ='" + txtCargo.Text + "'";

                    }

                    if (!userRol.Equals("sysadmin"))
                    {
                        query = query + ", rol ='" + cmbRol.SelectedValue + "' where idUsuario = '" + codigo + "'";
                    }
                    else
                    {
                        query = query + " where idUsuario = '" + codigo + "'";
                    }

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

  

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ok();
            }
        }

        private void txtCPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ok();
            }
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ok();
            }
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ok();
            }
        }

        private void txtCargo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ok();
            }
        }

        private void cmbRol_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ok();
            }
        }
    }
}
