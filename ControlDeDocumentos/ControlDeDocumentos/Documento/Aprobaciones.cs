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
    public partial class Aprobaciones : Form
    {

        public DataSet ds;
        private String user;
        public Aprobaciones(String p1)
           
        {
            this.user = p1;
            InitializeComponent();
        }

        private void picModificar_Click(object sender, EventArgs e)
        {
            if (grd.Rows.Count > 0)
            {
                script.UserDat us = new script.UserDat();
                us.Code = grd[0, grd.CurrentCellAddress.Y].Value.ToString();
                us.Description = grd[1, grd.CurrentCellAddress.Y].Value.ToString();
                us.Elabora = grd[3, grd.CurrentCellAddress.Y].Value.ToString();
                us.Revisa = grd[4, grd.CurrentCellAddress.Y].Value.ToString();
                us.Aprueba = grd[5, grd.CurrentCellAddress.Y].Value.ToString();
                us.Autoriza = grd[6, grd.CurrentCellAddress.Y].Value.ToString();
             
                Documento.Aprobacion nuevo = new Documento.Aprobacion(us,grd,user);
                nuevo.ShowDialog();
            }

            
        }

        private void picRefrescar_Click(object sender, EventArgs e)
        {
            setGrdw();
        }

        private void Aprobacion_Load(object sender, EventArgs e)
        {
            setGrdw();
        }


        public void setGrdw()
        {
            ds = DataManager.selTab("select idUsuario AS 'Usuario', nombre AS 'Nombre', rol AS 'Rol',elabora AS 'Elbora',revisa AS 'Revisa',aprueba AS 'Aprueba',autoriza AS 'Autoriza' from Usuario where rol != 'sysadmin'", "Usuario");
            grd.DataSource = ds;
            grd.DataMember = "Usuario";
        }

        private void picBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text.Length > 0 && cmbAccion.SelectedIndex > 0)
                {
                    ds = DataManager.selTab("select idUsuario AS 'Usuario', nombre AS 'Nombre', rol AS 'Rol',elabora AS 'Elbora',revisa AS 'Revisa',aprueba AS 'Aprueba',autoriza AS 'Autoriza' from Usuario where idUsuario like '" + txtCodigo.Text.ToLower() + "%' and " + cmbAccion.SelectedItem.ToString().ToLower() + " = 'Si' and rol != 'sysadmin'", "Usuario");
                    grd.DataSource = ds;
                    grd.DataMember = "Usuario";
                }
                else if (txtCodigo.Text.Length > 0)
                {
                    ds = DataManager.selTab("select idUsuario AS 'Usuario', nombre AS 'Nombre', rol AS 'Rol',elabora AS 'Elbora',revisa AS 'Revisa',aprueba AS 'Aprueba',autoriza AS 'Autoriza' from Usuario where idUsuario like '" + txtCodigo.Text + "%' and rol != 'sysadmin'", "Usuario");
                    grd.DataSource = ds;
                    grd.DataMember = "Usuario";
                }
                else if (cmbAccion.SelectedIndex > 0)
                {
                    ds = DataManager.selTab("select idUsuario AS 'Usuario', nombre AS 'Nombre', rol AS 'Rol',elabora AS 'Elbora',revisa AS 'Revisa',aprueba AS 'Aprueba',autoriza AS 'Autoriza' from Usuario where " + cmbAccion.SelectedItem.ToString().ToLower() + " = 'Si' and rol != 'sysadmin'", "Usuario");
                    grd.DataSource = ds;
                    grd.DataMember = "Usuario";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error De Aplicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
