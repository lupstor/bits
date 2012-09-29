namespace ControlDeDocumentos
{
    partial class Inicio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msCerrar = new System.Windows.Forms.ToolStripMenuItem();
            this.msSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.msModulos = new System.Windows.Forms.ToolStripMenuItem();
            this.msUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.msTipos = new System.Windows.Forms.ToolStripMenuItem();
            this.msAreas = new System.Windows.Forms.ToolStripMenuItem();
            this.msSecciones = new System.Windows.Forms.ToolStripMenuItem();
            this.msNiveles = new System.Windows.Forms.ToolStripMenuItem();
            this.msAprobacion = new System.Windows.Forms.ToolStripMenuItem();
            this.msDocumentos = new System.Windows.Forms.ToolStripMenuItem();
            this.msLog = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errLogin = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLogueado = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusRol = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inicioToolStripMenuItem,
            this.msModulos,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(940, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // inicioToolStripMenuItem
            // 
            this.inicioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msCerrar,
            this.msSalir});
            this.inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            this.inicioToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.inicioToolStripMenuItem.Text = "Inicio";
            // 
            // msCerrar
            // 
            this.msCerrar.Name = "msCerrar";
            this.msCerrar.Size = new System.Drawing.Size(139, 22);
            this.msCerrar.Text = "Cerra Sesión";
            this.msCerrar.Click += new System.EventHandler(this.msCerrar_Click);
            // 
            // msSalir
            // 
            this.msSalir.Name = "msSalir";
            this.msSalir.Size = new System.Drawing.Size(139, 22);
            this.msSalir.Text = "Salir";
            this.msSalir.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // msModulos
            // 
            this.msModulos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msUsuarios,
            this.msTipos,
            this.msAreas,
            this.msSecciones,
            this.msNiveles,
            this.msAprobacion,
            this.msDocumentos,
            this.msLog});
            this.msModulos.Name = "msModulos";
            this.msModulos.Size = new System.Drawing.Size(66, 20);
            this.msModulos.Text = "Modulos";
            // 
            // msUsuarios
            // 
            this.msUsuarios.Name = "msUsuarios";
            this.msUsuarios.Size = new System.Drawing.Size(186, 22);
            this.msUsuarios.Text = "Usuarios";
            this.msUsuarios.Click += new System.EventHandler(this.msUsuarios_Click);
            // 
            // msTipos
            // 
            this.msTipos.Name = "msTipos";
            this.msTipos.Size = new System.Drawing.Size(186, 22);
            this.msTipos.Text = "Tipos De Documento";
            this.msTipos.Click += new System.EventHandler(this.msTipos_Click);
            // 
            // msAreas
            // 
            this.msAreas.Name = "msAreas";
            this.msAreas.Size = new System.Drawing.Size(186, 22);
            this.msAreas.Text = "Areas";
            this.msAreas.Click += new System.EventHandler(this.msAreas_Click);
            // 
            // msSecciones
            // 
            this.msSecciones.Name = "msSecciones";
            this.msSecciones.Size = new System.Drawing.Size(186, 22);
            this.msSecciones.Text = "Secciones";
            this.msSecciones.Click += new System.EventHandler(this.msSecciones_Click);
            // 
            // msNiveles
            // 
            this.msNiveles.Name = "msNiveles";
            this.msNiveles.Size = new System.Drawing.Size(186, 22);
            this.msNiveles.Text = "Niveles";
            this.msNiveles.Click += new System.EventHandler(this.msNiveles_Click);
            // 
            // msAprobacion
            // 
            this.msAprobacion.Name = "msAprobacion";
            this.msAprobacion.Size = new System.Drawing.Size(186, 22);
            this.msAprobacion.Text = "Aprobación De Doc.";
            this.msAprobacion.Click += new System.EventHandler(this.msAprobacion_Click);
            // 
            // msDocumentos
            // 
            this.msDocumentos.Name = "msDocumentos";
            this.msDocumentos.Size = new System.Drawing.Size(186, 22);
            this.msDocumentos.Text = "Documentos";
            this.msDocumentos.Click += new System.EventHandler(this.msDocumentos_Click);
            // 
            // msLog
            // 
            this.msLog.Name = "msLog";
            this.msLog.Size = new System.Drawing.Size(186, 22);
            this.msLog.Text = "Log";
            this.msLog.Click += new System.EventHandler(this.msLog_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaDeToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.acercaDeToolStripMenuItem.Text = "Acerca De..";
            // 
            // errLogin
            // 
            this.errLogin.ContainerControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::ControlDeDocumentos.Properties.Resources.LogoQualipharm;
            this.pictureBox1.Location = new System.Drawing.Point(668, 384);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(260, 77);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.GhostWhite;
            this.statusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLogueado,
            this.statusUsuario,
            this.toolStripStatusLabel3,
            this.statusRol});
            this.statusStrip1.Location = new System.Drawing.Point(0, 473);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(940, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLogueado
            // 
            this.statusLogueado.BackColor = System.Drawing.Color.Transparent;
            this.statusLogueado.Name = "statusLogueado";
            this.statusLogueado.Size = new System.Drawing.Size(99, 17);
            this.statusLogueado.Text = "Logueado Como:";
            this.statusLogueado.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // statusUsuario
            // 
            this.statusUsuario.BackColor = System.Drawing.Color.Transparent;
            this.statusUsuario.Name = "statusUsuario";
            this.statusUsuario.Size = new System.Drawing.Size(77, 17);
            this.statusUsuario.Text = "--------------";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(30, 17);
            this.toolStripStatusLabel3.Text = "RoL:";
            // 
            // statusRol
            // 
            this.statusRol.BackColor = System.Drawing.Color.Transparent;
            this.statusRol.Name = "statusRol";
            this.statusRol.Size = new System.Drawing.Size(77, 17);
            this.statusRol.Text = "--------------";
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(940, 495);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control De Documentos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inicioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem msCerrar;
        private System.Windows.Forms.ToolStripMenuItem msSalir;
        private System.Windows.Forms.ToolStripMenuItem msModulos;
        private System.Windows.Forms.ToolStripMenuItem msUsuarios;
        private System.Windows.Forms.ToolStripMenuItem msTipos;
        private System.Windows.Forms.ToolStripMenuItem msAreas;
        private System.Windows.Forms.ToolStripMenuItem msSecciones;
        private System.Windows.Forms.ToolStripMenuItem msNiveles;
        private System.Windows.Forms.ToolStripMenuItem msAprobacion;
        private System.Windows.Forms.ToolStripMenuItem msDocumentos;
        private System.Windows.Forms.ToolStripMenuItem msLog;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ErrorProvider errLogin;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLogueado;
        private System.Windows.Forms.ToolStripStatusLabel statusUsuario;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel statusRol;


    }
}