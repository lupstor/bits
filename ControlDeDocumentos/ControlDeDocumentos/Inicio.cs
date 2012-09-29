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


namespace ControlDeDocumentos
{
    public partial class Inicio : Form
    {

        private String rol;
        private String user;
        
        
        public Inicio()
        {
            InitializeComponent();
        }


  
        private void Inicio_Load(object sender, EventArgs e)
        {
            //  Inicializacion de Menu
            statusUsuario.Text = "--------------";
            statusRol.Text = "--------------";
            msCerrar.Enabled = false;
            msModulos.Visible = false;
            Login.Login nuevo = new Login.Login(statusRol,statusUsuario,msUsuarios,msTipos,msAreas,msSecciones,msNiveles,msAprobacion,msDocumentos,msLog,msModulos,msCerrar);
            nuevo.ShowDialog();
            user = statusUsuario.Text;
            rol = statusRol.Text;
           
        }

        //Salir de Aplicacion
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    
        //Cerrar Sesion
        private void msCerrar_Click(object sender, EventArgs e)
        {
            
            msModulos.Visible = false;
            msCerrar.Enabled = false;
            statusUsuario.Text = "--------------";
            statusRol.Text = "--------------";
            Login.Login nuevo = new Login.Login(statusRol, statusUsuario, msUsuarios, msTipos, msAreas, msSecciones, msNiveles, msAprobacion, msDocumentos, msLog, msModulos, msCerrar);
            nuevo.ShowDialog();
            user = statusUsuario.Text;
            rol = statusRol.Text;
        }


          private void msUsuarios_Click(object sender, EventArgs e)
        {
            Mantenimientos.Usuarios usuarios = new Mantenimientos.Usuarios(user,rol);
            usuarios.ShowDialog();
        }

        private void msAreas_Click(object sender, EventArgs e)
        {
            Mantenimientos.Areas areas = new Mantenimientos.Areas();
            areas.ShowDialog();
        }

        private void msTipos_Click(object sender, EventArgs e)
        {
            Mantenimientos.Tipos tipos = new Mantenimientos.Tipos();
            tipos.ShowDialog();
        }

        private void msSecciones_Click(object sender, EventArgs e)
        {
            Mantenimientos.Secciones secciones = new Mantenimientos.Secciones();
            secciones.ShowDialog();
        }

        private void msNiveles_Click(object sender, EventArgs e)
        {
            Mantenimientos.Niveles niveles = new Mantenimientos.Niveles();
            niveles.ShowDialog();
        }

        private void msAprobacion_Click(object sender, EventArgs e)
        {
            Documento.Aprobaciones aprovacion = new Documento.Aprobaciones(user);
            aprovacion.ShowDialog();
        }

        private void msDocumentos_Click(object sender, EventArgs e)
        {
            DataManager.updateEstado();
            Documento.Documentos documentos = new Documento.Documentos(rol,  user);
            documentos.ShowDialog();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void msLog_Click(object sender, EventArgs e)
        {
            Mantenimientos.Log nuevo = new Mantenimientos.Log();
            nuevo.ShowDialog();
        }
        
    }
}
