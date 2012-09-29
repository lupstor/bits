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
    public partial class RegistroAnexo : Form

    {

        private String tipo;
        private DataGridView grd;
        private Boolean status;
        private DataSet ds;
        private int codigo;
        private String operacion;
     

        public RegistroAnexo(String ti, DataGridView gr, String op)
        {
            this.tipo = ti;
            this.grd = gr;
            this.operacion = op;
       
            InitializeComponent();
        }

        private void RegistroAnexo_Load(object sender, EventArgs e)
        {

            ds = DataManager.selTab("select Doc.idDocumento, Doc.idDocumento +' - '+ Doc.nombre from Documento Doc where estado != 'Caducado' and estado != 'Obsoleto' and edicion = (select max(D.edicion) from Documento D where D.idDocumento = Doc.idDocumento )", "Documento");
            DataManager.fillComboEs(cmbDocumento, ds);
          
            ds = DataManager.selTab("select idNivel,idNivel +' - ' + descripcion from Nivel ", "Nivel");
            DataManager.fillComboEs(cmbNivel, ds);
            
            panExistente.Visible = false;
            if (tipo.Equals("A"))
            {
                lblTitulo.Text = "Anexo";
                this.Text = "Anexo";
                lblAnReg.Text = "Anexo";
            }
            else
            {
                lblTitulo.Text = "Registro";
                this.Text = "Registro";
                lblAnReg.Text = "Registro";
               
            }
            
            if (operacion.Equals("Alta"))
            {
                codigo = grd.Rows.Count + 1;
                lblCodigo.Text = codigo.ToString();
               
            }
            else { 
            
                lblCodigo.Text =   grd.Rows[grd.CurrentCellAddress.Y].Cells[0].Value.ToString();
                txtNombre.Text = grd.Rows[grd.CurrentCellAddress.Y].Cells[2].Value.ToString();
                
                
                String tip = grd.Rows[grd.CurrentCellAddress.Y].Cells[3].Value.ToString();
                if (tip.Equals("Nuevo"))
                {
                    radNuevo.Checked = true;
                }
                else if (tip.Equals("Existente"))
                {
                    radExistente.Checked = true;
                }
                DataManager.indexCombo(cmbNivel, grd.Rows[grd.CurrentCellAddress.Y].Cells[1].Value.ToString());
                DataManager.indexCombo(cmbDocumento, grd.Rows[grd.CurrentCellAddress.Y].Cells[4].Value.ToString());
                
                lblLink.Text = grd.Rows[grd.CurrentCellAddress.Y].Cells[6].Value.ToString();

                if (tipo.Equals("A"))
                {
                    ds = DataManager.selTab("select idAnexo, Convert(Varchar,idAnexo) + ' - '+ nombre from Anexo where idDocumento = '" + cmbDocumento.SelectedValue + "' and edicion = (select max(edicion) from Documento D where D.idDocumento = '" + cmbDocumento.SelectedValue + "')", "Anexo");
                    DataManager.fillComboEs(cmbAnReg, ds);

                }
                else
                {
                    ds = DataManager.selTab("select idRegistro, Convert(Varchar,idRegistro) + ' - '+ nombre from Registro where idDocumento = '" + cmbDocumento.SelectedValue + "' and edicion = (select max(edicion) from Documento D where D.idDocumento = '" + cmbDocumento.SelectedValue + "')", "Registro");
                    DataManager.fillComboEs(cmbAnReg, ds);
                }

                DataManager.indexCombo(cmbAnReg, grd.Rows[grd.CurrentCellAddress.Y].Cells[5].Value.ToString());
            }

            if(operacion.Equals("Consulta")){
                txtNombre.ReadOnly = true;
                radNuevo.Enabled = false;
                radExistente.Enabled = false;
                btnExaminar.Visible = false;
                cmbDocumento.Enabled = false;
                cmbAnReg.Enabled = false;
                picOk.Visible = false;
                label7.Visible = false;
                picOk.Focus();
                cmbNivel.Enabled = false;
            }

       
        }

        private void radNuevo_CheckedChanged(object sender, EventArgs e)
        {
            if(radNuevo.Checked){
                panExistente.Visible = false;
            }
        }

        private void radExistente_CheckedChanged(object sender, EventArgs e)
        {
            if(radExistente.Checked){
                panExistente.Visible = true;
            }
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                lblLink.Text = openFileDialog1.FileName;

            }
        }

        private void picOk_Click(object sender, EventArgs e)
        {
            ok();
        }

        public void ok() {

            validar();
            if (status)
            {


                String tip;
                if (radNuevo.Checked)
                {
                    tip = "Nuevo";
                    cmbDocumento.SelectedIndex = 0;
                }
                else
                {
                    tip = "Existente";
                }

                if (operacion.Equals("Alta"))
                {
                    grd.Rows.Add(codigo.ToString(),cmbNivel.SelectedValue ,txtNombre.Text, tip, cmbDocumento.SelectedValue, cmbAnReg.SelectedValue, lblLink.Text);
                    cleanControls();
                    codigo = grd.Rows.Count + 1;
                    lblCodigo.Text = codigo.ToString();
                    panExistente.Visible = false;
                }
                else
                {
                    grd.Rows[grd.CurrentCellAddress.Y].Cells[1].Value = cmbNivel.SelectedValue;
                    grd.Rows[grd.CurrentCellAddress.Y].Cells[2].Value = txtNombre.Text;
                    grd.Rows[grd.CurrentCellAddress.Y].Cells[3].Value = tip;
                    grd.Rows[grd.CurrentCellAddress.Y].Cells[4].Value = cmbDocumento.SelectedValue;
                    grd.Rows[grd.CurrentCellAddress.Y].Cells[5].Value = cmbAnReg.SelectedValue;
                    grd.Rows[grd.CurrentCellAddress.Y].Cells[6].Value = lblLink.Text;
                    this.Close();
                }

            }
        }

        public void cleanControls() {
            txtNombre.Text = "";
            lblLink.Text = "";
            radNuevo.Checked = false;
            radExistente.Checked = false;
            cmbDocumento.SelectedIndex = 0;
            cmbAnReg.SelectedIndex = 0;
            cmbNivel.SelectedIndex = 0;
        }

        public void validar() {
            status = true;

            errorProv.SetError(this.txtNombre, "");
            errorProv.SetError(this.lblTipo, "");
            errorProv.SetError(this.cmbDocumento, "");
            errorProv.SetError(this.cmbAnReg, "");
            errorProv.SetError(this.cmbNivel, "");

            if (txtNombre.Text.Trim().Length == 0)
            {
                errorProv.SetError(this.txtNombre, "Ingresar Nombre");
                status = false;
            }

            if (!radNuevo.Checked && !radExistente.Checked )
            {
                errorProv.SetError(this.lblTipo, "Seleccionar Tipo");
                status = false;
            }

            if (cmbNivel.SelectedIndex == 0)
            {
                errorProv.SetError(this.cmbNivel, "Seleccionar Nivel");
                status = false;
            }

            if(radExistente.Checked){
                if(cmbDocumento.SelectedIndex == 0){
                    errorProv.SetError(this.cmbDocumento, "Seleccionar Documento");
                    status = false;
                }
                if (cmbAnReg.SelectedIndex == 0)
                {
                    errorProv.SetError(this.cmbAnReg, "Seleccionar");
                    status = false;
                }
            }
        }

        private void picCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblLink_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(lblLink.Text);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error Al abrir Archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tipo.Equals("A"))
            {
                ds = DataManager.selTab("select idAnexo, Convert(Varchar,idAnexo) + ' - '+ nombre from Anexo where idDocumento = '" + cmbDocumento.SelectedValue + "' and edicion = (select max(edicion) from Documento D where D.idDocumento = '" + cmbDocumento.SelectedValue + "')", "Anexo");
                DataManager.fillComboEs(cmbAnReg, ds);               
           
            }
            else {
                ds = DataManager.selTab("select idRegistro, Convert(Varchar,idRegistro) + ' - '+ nombre from Registro where idDocumento = '" + cmbDocumento.SelectedValue + "' and edicion = (select max(edicion) from Documento D where D.idDocumento = '" + cmbDocumento.SelectedValue + "')", "Registro");
                DataManager.fillComboEs(cmbAnReg, ds);             
            }
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ok();
            }
        }

        private void radNuevo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ok();
            }
        }

        private void radExistente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ok();
            }
        }

        private void btnExaminar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ok();
            }
        }

        private void cmbDocumento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ok();
            }
        }

        private void cmbAnReg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ok();
            }
        }

    }
}
