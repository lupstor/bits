namespace ControlDeDocumentos.Documento
{
    partial class Aprobacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Aprobacion));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkElabora = new System.Windows.Forms.CheckBox();
            this.chkRevisa = new System.Windows.Forms.CheckBox();
            this.chkAprueba = new System.Windows.Forms.CheckBox();
            this.chkAutoriza = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.picCancel = new System.Windows.Forms.PictureBox();
            this.picOk = new System.Windows.Forms.PictureBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOk)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(52, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(52, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre";
            // 
            // chkElabora
            // 
            this.chkElabora.AutoSize = true;
            this.chkElabora.Location = new System.Drawing.Point(56, 164);
            this.chkElabora.Name = "chkElabora";
            this.chkElabora.Size = new System.Drawing.Size(62, 17);
            this.chkElabora.TabIndex = 2;
            this.chkElabora.Text = "Elabora";
            this.chkElabora.UseVisualStyleBackColor = true;
            this.chkElabora.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkElabora_KeyDown);
            // 
            // chkRevisa
            // 
            this.chkRevisa.AutoSize = true;
            this.chkRevisa.Location = new System.Drawing.Point(138, 164);
            this.chkRevisa.Name = "chkRevisa";
            this.chkRevisa.Size = new System.Drawing.Size(59, 17);
            this.chkRevisa.TabIndex = 3;
            this.chkRevisa.Text = "Revisa";
            this.chkRevisa.UseVisualStyleBackColor = true;
            this.chkRevisa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkRevisa_KeyDown);
            // 
            // chkAprueba
            // 
            this.chkAprueba.AutoSize = true;
            this.chkAprueba.Location = new System.Drawing.Point(221, 164);
            this.chkAprueba.Name = "chkAprueba";
            this.chkAprueba.Size = new System.Drawing.Size(66, 17);
            this.chkAprueba.TabIndex = 4;
            this.chkAprueba.Text = "Aprueba";
            this.chkAprueba.UseVisualStyleBackColor = true;
            this.chkAprueba.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkAprueba_KeyDown);
            // 
            // chkAutoriza
            // 
            this.chkAutoriza.AutoSize = true;
            this.chkAutoriza.Location = new System.Drawing.Point(304, 164);
            this.chkAutoriza.Name = "chkAutoriza";
            this.chkAutoriza.Size = new System.Drawing.Size(64, 17);
            this.chkAutoriza.TabIndex = 5;
            this.chkAutoriza.Text = "Autoriza";
            this.chkAutoriza.UseVisualStyleBackColor = true;
            this.chkAutoriza.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkAutoriza_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(272, 222);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Cancelar";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(176, 222);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Confirmar";
            // 
            // picCancel
            // 
            this.picCancel.Image = global::ControlDeDocumentos.Properties.Resources.cancel;
            this.picCancel.Location = new System.Drawing.Point(326, 213);
            this.picCancel.Name = "picCancel";
            this.picCancel.Size = new System.Drawing.Size(29, 27);
            this.picCancel.TabIndex = 24;
            this.picCancel.TabStop = false;
            this.picCancel.Click += new System.EventHandler(this.picCancel_Click);
            // 
            // picOk
            // 
            this.picOk.Image = global::ControlDeDocumentos.Properties.Resources.ok;
            this.picOk.Location = new System.Drawing.Point(235, 213);
            this.picOk.Name = "picOk";
            this.picOk.Size = new System.Drawing.Size(29, 27);
            this.picOk.TabIndex = 23;
            this.picOk.TabStop = false;
            this.picOk.Click += new System.EventHandler(this.picOk_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(50, 30);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(290, 29);
            this.lblTitulo.TabIndex = 27;
            this.lblTitulo.Text = "Modificación De Acciones";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.Navy;
            this.lblNombre.Location = new System.Drawing.Point(112, 112);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(200, 16);
            this.lblNombre.TabIndex = 28;
            this.lblNombre.Text = "------------------------------------------------";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.Navy;
            this.lblUsuario.Location = new System.Drawing.Point(112, 84);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(68, 16);
            this.lblUsuario.TabIndex = 29;
            this.lblUsuario.Text = "---------------";
            // 
            // Aprobacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(457, 270);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.picCancel);
            this.Controls.Add(this.picOk);
            this.Controls.Add(this.chkAutoriza);
            this.Controls.Add(this.chkAprueba);
            this.Controls.Add(this.chkRevisa);
            this.Controls.Add(this.chkElabora);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Aprobacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aprobacion";
            this.Load += new System.EventHandler(this.Aprobacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOk)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkElabora;
        private System.Windows.Forms.CheckBox chkRevisa;
        private System.Windows.Forms.CheckBox chkAprueba;
        private System.Windows.Forms.CheckBox chkAutoriza;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox picCancel;
        private System.Windows.Forms.PictureBox picOk;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblUsuario;
    }
}