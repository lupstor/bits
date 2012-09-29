namespace ControlDeDocumentos.Documento
{
    partial class RegistroAnexo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistroAnexo));
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.picCancel = new System.Windows.Forms.PictureBox();
            this.picOk = new System.Windows.Forms.PictureBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.radNuevo = new System.Windows.Forms.RadioButton();
            this.radExistente = new System.Windows.Forms.RadioButton();
            this.panExistente = new System.Windows.Forms.Panel();
            this.cmbAnReg = new System.Windows.Forms.ComboBox();
            this.lblAnReg = new System.Windows.Forms.Label();
            this.cmbDocumento = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnExaminar = new System.Windows.Forms.Button();
            this.lblLink = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.errorProv = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.cmbNivel = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOk)).BeginInit();
            this.panExistente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProv)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(369, 451);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Cancelar";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(288, 451);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Grabar";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(37, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(165, 29);
            this.lblTitulo.TabIndex = 27;
            this.lblTitulo.Text = "-------------------";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNombre.Location = new System.Drawing.Point(150, 158);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(303, 20);
            this.txtNombre.TabIndex = 25;
            this.txtNombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNombre_KeyDown);
            // 
            // picCancel
            // 
            this.picCancel.Image = global::ControlDeDocumentos.Properties.Resources.cancel;
            this.picCancel.Location = new System.Drawing.Point(424, 437);
            this.picCancel.Name = "picCancel";
            this.picCancel.Size = new System.Drawing.Size(29, 27);
            this.picCancel.TabIndex = 29;
            this.picCancel.TabStop = false;
            this.picCancel.Click += new System.EventHandler(this.picCancel_Click);
            // 
            // picOk
            // 
            this.picOk.Image = global::ControlDeDocumentos.Properties.Resources.ok;
            this.picOk.Location = new System.Drawing.Point(333, 437);
            this.picOk.Name = "picOk";
            this.picOk.Size = new System.Drawing.Size(29, 27);
            this.picOk.TabIndex = 28;
            this.picOk.TabStop = false;
            this.picOk.Click += new System.EventHandler(this.picOk_Click);
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(39, 204);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(28, 13);
            this.lblTipo.TabIndex = 32;
            this.lblTipo.Text = "Tipo";
            // 
            // radNuevo
            // 
            this.radNuevo.AutoSize = true;
            this.radNuevo.Location = new System.Drawing.Point(150, 204);
            this.radNuevo.Name = "radNuevo";
            this.radNuevo.Size = new System.Drawing.Size(57, 17);
            this.radNuevo.TabIndex = 33;
            this.radNuevo.TabStop = true;
            this.radNuevo.Text = "Nuevo";
            this.radNuevo.UseVisualStyleBackColor = true;
            this.radNuevo.CheckedChanged += new System.EventHandler(this.radNuevo_CheckedChanged);
            this.radNuevo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.radNuevo_KeyDown);
            // 
            // radExistente
            // 
            this.radExistente.AutoSize = true;
            this.radExistente.Location = new System.Drawing.Point(233, 204);
            this.radExistente.Name = "radExistente";
            this.radExistente.Size = new System.Drawing.Size(68, 17);
            this.radExistente.TabIndex = 34;
            this.radExistente.TabStop = true;
            this.radExistente.Text = "Existente";
            this.radExistente.UseVisualStyleBackColor = true;
            this.radExistente.CheckedChanged += new System.EventHandler(this.radExistente_CheckedChanged);
            this.radExistente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.radExistente_KeyDown);
            // 
            // panExistente
            // 
            this.panExistente.Controls.Add(this.cmbAnReg);
            this.panExistente.Controls.Add(this.lblAnReg);
            this.panExistente.Controls.Add(this.cmbDocumento);
            this.panExistente.Controls.Add(this.label6);
            this.panExistente.Location = new System.Drawing.Point(36, 333);
            this.panExistente.Name = "panExistente";
            this.panExistente.Size = new System.Drawing.Size(417, 84);
            this.panExistente.TabIndex = 38;
            this.panExistente.Visible = false;
            // 
            // cmbAnReg
            // 
            this.cmbAnReg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnReg.FormattingEnabled = true;
            this.cmbAnReg.Location = new System.Drawing.Point(108, 47);
            this.cmbAnReg.Name = "cmbAnReg";
            this.cmbAnReg.Size = new System.Drawing.Size(296, 21);
            this.cmbAnReg.TabIndex = 40;
            this.cmbAnReg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbAnReg_KeyDown);
            // 
            // lblAnReg
            // 
            this.lblAnReg.AutoSize = true;
            this.lblAnReg.Location = new System.Drawing.Point(3, 50);
            this.lblAnReg.Name = "lblAnReg";
            this.lblAnReg.Size = new System.Drawing.Size(58, 13);
            this.lblAnReg.TabIndex = 39;
            this.lblAnReg.Text = "-----------------";
            // 
            // cmbDocumento
            // 
            this.cmbDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDocumento.FormattingEnabled = true;
            this.cmbDocumento.Location = new System.Drawing.Point(108, 11);
            this.cmbDocumento.Name = "cmbDocumento";
            this.cmbDocumento.Size = new System.Drawing.Size(296, 21);
            this.cmbDocumento.TabIndex = 38;
            this.cmbDocumento.SelectedIndexChanged += new System.EventHandler(this.cmbDocumento_SelectedIndexChanged);
            this.cmbDocumento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbDocumento_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Documento";
            // 
            // btnExaminar
            // 
            this.btnExaminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExaminar.Location = new System.Drawing.Point(377, 243);
            this.btnExaminar.Name = "btnExaminar";
            this.btnExaminar.Size = new System.Drawing.Size(76, 23);
            this.btnExaminar.TabIndex = 39;
            this.btnExaminar.Text = "Examinar..";
            this.btnExaminar.UseVisualStyleBackColor = true;
            this.btnExaminar.Click += new System.EventHandler(this.btnExaminar_Click);
            this.btnExaminar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnExaminar_KeyDown);
            // 
            // lblLink
            // 
            this.lblLink.AutoSize = true;
            this.lblLink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLink.ForeColor = System.Drawing.Color.Blue;
            this.lblLink.Location = new System.Drawing.Point(147, 253);
            this.lblLink.MaximumSize = new System.Drawing.Size(200, 0);
            this.lblLink.Name = "lblLink";
            this.lblLink.Size = new System.Drawing.Size(0, 13);
            this.lblLink.TabIndex = 42;
            this.lblLink.Click += new System.EventHandler(this.lblLink_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "Link";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // errorProv
            // 
            this.errorProv.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Código";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(147, 64);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(28, 13);
            this.lblCodigo.TabIndex = 40;
            this.lblCodigo.Text = "-------";
            // 
            // cmbNivel
            // 
            this.cmbNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNivel.FormattingEnabled = true;
            this.cmbNivel.Location = new System.Drawing.Point(150, 111);
            this.cmbNivel.Name = "cmbNivel";
            this.cmbNivel.Size = new System.Drawing.Size(157, 21);
            this.cmbNivel.TabIndex = 46;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 45;
            this.label3.Text = "Nivel";
            // 
            // RegistroAnexo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(481, 487);
            this.Controls.Add(this.cmbNivel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblLink);
            this.Controls.Add(this.btnExaminar);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panExistente);
            this.Controls.Add(this.radExistente);
            this.Controls.Add(this.radNuevo);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.picCancel);
            this.Controls.Add(this.picOk);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNombre);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegistroAnexo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegistroAnexo";
            this.Load += new System.EventHandler(this.RegistroAnexo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOk)).EndInit();
            this.panExistente.ResumeLayout(false);
            this.panExistente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox picCancel;
        private System.Windows.Forms.PictureBox picOk;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.RadioButton radNuevo;
        private System.Windows.Forms.RadioButton radExistente;
        private System.Windows.Forms.Panel panExistente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbDocumento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblLink;
        private System.Windows.Forms.Button btnExaminar;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ErrorProvider errorProv;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbAnReg;
        private System.Windows.Forms.Label lblAnReg;
        private System.Windows.Forms.ComboBox cmbNivel;
        private System.Windows.Forms.Label label3;
    }
}