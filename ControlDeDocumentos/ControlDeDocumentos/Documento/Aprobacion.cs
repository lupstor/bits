using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlDeDocumentos.Documento
{
    public partial class Aprobacion : Form
    {

        private script.UserDat usuario;
        private DataGridView grd;
        private DataSet ds;
        private script.ResponseSql response;
        private List<script.DetalleLog> listDetalleLog;
        private String user;
        
        public Aprobacion( script.UserDat us, DataGridView gr,String p1)

        {
            this.usuario = us;
            this.grd = gr;
            this.user = p1;
            InitializeComponent();
        }

        private void picCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Aprobacion_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = usuario.Code;
            lblNombre.Text = usuario.Description;

            if(usuario.Elabora.Equals("Si")){
                chkElabora.Checked = true;
            }
            if (usuario.Revisa.Equals("Si"))
            {
                chkRevisa.Checked = true;
            }
            if (usuario.Aprueba.Equals("Si"))
            {
                chkAprueba.Checked = true;
            }
            if (usuario.Autoriza.Equals("Si"))
            {
                chkAutoriza.Checked = true;
            }

            listDetalleLog = new List<script.DetalleLog>();
            listDetalleLog.Add(new script.DetalleLog("idUsuario", usuario.Code, usuario.Code));
            listDetalleLog.Add(new script.DetalleLog("elabora", usuario.Elabora, ""));
            listDetalleLog.Add(new script.DetalleLog("revisa", usuario.Revisa, ""));
            listDetalleLog.Add(new script.DetalleLog("aprueba", usuario.Aprueba, ""));
            listDetalleLog.Add(new script.DetalleLog("autoriza", usuario.Autoriza, ""));
        }

        private void picOk_Click(object sender, EventArgs e)
        {

            ok();
        }

        public void setGrdw()
        {
            ds = DataManager.selTab("select idUsuario AS 'Usuario', nombre AS 'Nombre', rol AS 'Rol',elabora AS 'Elbora',revisa AS 'Revisa',aprueba AS 'Aprueba',autoriza AS 'Autoriza' from Usuario where rol != 'sysadmin'", "Usuario");
            grd.DataSource = ds;
            grd.DataMember = "Usuario";
        }

        public void ok() {
            String el = "No", re = "No", ap = "No", au = "No";
            if (chkElabora.Checked)
            {
                el = "Si";
            }
            if (chkRevisa.Checked)
            {
                re = "Si";
            }
            if (chkAprueba.Checked)
            {
                ap = "Si";
            }

            if (chkAutoriza.Checked)
            {
                au = "Si";
            }

            String query = "UPDATE Usuario SET "
                           + "elabora = '" + el + "',"
                           + "revisa ='" + re + "',"
                           + "aprueba ='" + ap + "',"
                            + "autoriza ='" + au + "' where idUsuario = '" + usuario.Code + "'";

            response = DataManager.update(query);
            if (response.Code == 0)
            {
                MessageBox.Show(response.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Graba log
                listDetalleLog[1].ValDespues = el;
                listDetalleLog[2].ValDespues = re;
                listDetalleLog[3].ValDespues = ap;
                listDetalleLog[4].ValDespues = au;
                DataManager.saveLog("Usuario", "UPDATE", user, listDetalleLog);
                //Actualiza grid
                setGrdw();
                this.Close();
            }
            else
            {
                MessageBox.Show(response.Message, "Error Sql", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkElabora_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ok();
            }
        }

        private void chkRevisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ok();
            }
        }

        private void chkAprueba_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ok();
            }
        }

        private void chkAutoriza_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ok();
            }

        }

       
    }
}
