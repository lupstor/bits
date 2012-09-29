using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ControlDeDocumentos.Documento
{
    public partial class ADocumento : Form
    {

        private String rol;
        private List<script.DetalleLog> listDetalleLog;
        private String usuario;
        private DataGridView grd;
        private Boolean status,statusAll;
        private script.ResponseSql response;
        private DataSet ds;
        private String queryDoc;
        private readonly String SELECT_DOCUMENTO = "select  D.idDocumento AS 'Id', "
                                             + "D.edicion AS 'Edición', "
                                             + "TipoDocumento.descripcion AS 'Tipo', "
                                             + "Area.descripcion AS 'Area',Seccion.descripcion AS 'Sección', "
                                             + "Subseccion.descripcion AS 'Sub-Sección', "
                                             + "D.correlativo AS 'Correlativo', "
                                             + "D.nombre AS 'Nombre', "
                                             + "D.estado AS 'Estado', "
                                             + "(select descripcion from  Nivel where idNivel =  D.idNivel) AS 'Nivel', "
                                             + "(select nombre from Usuario where idUsuario =  D.elaboradoPor) AS 'Elaborado Por' , "
                                             + "D.fechaElaborado AS 'Fecha de Elaboración', "
                                             + "(select nombre from Usuario where idUsuario =  D.revisadoPor) AS 'Revisado Por' , "
                                             + "D.fechaRevisado AS 'Fecha de Revisión', "
                                             + "(select nombre from Usuario where idUsuario =  D.aprobadoPor) AS 'Aprobado Por' , "
                                             + "D.fechaAprobado AS 'Fecha de Aprobación', "
                                             + "(select nombre from Usuario where idUsuario =  D.autorizadoPor) AS 'Autorizado Por' , "
                                             + "D.fechaAutorizado AS 'Fecha de Autorización', "
                                             + "D.vigencia AS 'Vigencia', "
                                             + "D.fecha AS 'Fecha De Vigencia', "
                                             + "D.ejemplar AS 'Ejemplar', "
                                             + "D.procedimientoAnt AS 'Procedimiento Anterior', "
                                             + "D.link AS 'Link' "
                                             + "from Documento D "
                                             + "INNER JOIN TipoDocumento on  D.idTipo = TipoDocumento.idTipoDocumento "
                                             + "INNER JOIN Area on  D.idArea = Area.idArea "
                                             + "INNER JOIN Seccion on  D.idSeccion = Seccion.idSeccion "
                                             + "INNER JOIN SubSeccion on  D.idSubSeccion = SubSeccion.idSubseccion and  D.idSeccion = SubSeccion.idSeccion ";


        private readonly String SELECT__DOCUMENTO_RESTRICTED = "select  D.idDocumento AS 'Id', "
                                            + "D.edicion AS 'Edición', "
                                            + "TipoDocumento.descripcion AS 'Tipo', "
                                            + "Area.descripcion AS 'Area',Seccion.descripcion AS 'Sección', "
                                            + "Subseccion.descripcion AS 'Sub-Sección', "
                                            + "D.correlativo AS 'Correlativo', "
                                            + "D.nombre AS 'Nombre', "
                                            + "D.estado AS 'Estado', "
                                            + "(select descripcion from  Nivel where idNivel =  D.idNivel) AS 'Nivel', "
                                            + "(select nombre from Usuario where idUsuario =  D.elaboradoPor) AS 'Elaborado Por' , "
                                            + "D.fechaElaborado AS 'Fecha de Elaboración', "
                                            + "(select nombre from Usuario where idUsuario =  D.revisadoPor) AS 'Revisado Por' , "
                                            + "D.fechaRevisado AS 'Fecha de Revisión', "
                                            + "(select nombre from Usuario where idUsuario =  D.aprobadoPor) AS 'Aprobado Por' , "
                                            + "D.fechaAprobado AS 'Fecha de Aprobación', "
                                            + "(select nombre from Usuario where idUsuario =  D.autorizadoPor) AS 'Autorizado Por' , "
                                            + "D.fechaAutorizado AS 'Fecha de Autorización', "
                                            + "D.vigencia AS 'Vigencia', "
                                            + "D.fecha AS 'Fecha De Vigencia', "
                                            + "D.ejemplar AS 'Ejemplar', "
                                            + "D.procedimientoAnt AS 'Procedimiento Anterior', "
                                            + "D.link AS 'Link' "
                                            + "from Documento D "
                                            + "INNER JOIN TipoDocumento on  D.idTipo = TipoDocumento.idTipoDocumento "
                                            + "INNER JOIN Area on  D.idArea = Area.idArea "
                                            + "INNER JOIN Seccion on  D.idSeccion = Seccion.idSeccion "
                                            + "INNER JOIN SubSeccion on  D.idSubSeccion = SubSeccion.idSubseccion and  D.idSeccion = SubSeccion.idSeccion "
                                            + "where D.edicion = (select max(Doc.edicion) from Documento Doc where Doc.idDocumento = D.idDocumento) ";


        private readonly String ORDER_BY_DOC = "order by D.idTipo,D.idArea,D.idSeccion,D.idSubseccion,D.correlativo,D.edicion";
        
        public ADocumento(String id, String rl, DataGridView dg)

        {
            this.usuario = id;
            this.rol = rl;
            this.grd = dg;
            InitializeComponent();
        }

     

        private void ADocumento_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet ds;
                ds = DataManager.selTab("select idTipoDocumento, idTipoDocumento +' - ' + descripcion from TipoDocumento ", "Tipo");
                DataManager.fillComboEs(cmbTipo, ds);
                ds = DataManager.selTab("select idArea,idArea +' - ' + descripcion from Area ", "Area");
                DataManager.fillComboEs(cmbArea, ds);
                ds = DataManager.selTab("select idSeccion,idSeccion +' - ' + descripcion from Seccion ", "Seccion");
                DataManager.fillComboEs(cmbSeccion, ds);
                ds = DataManager.selTab("select idNivel,idNivel +' - ' + descripcion from Nivel ", "Nivel");
                DataManager.fillComboEs(cmbNivel, ds);

                ds = DataManager.selTab("select idUsuario,nombre from Usuario where elabora = 'Si'", "Usuario");
                DataManager.fillComboEs(cmbElaborado, ds);
                ds = DataManager.selTab("select idUsuario,nombre from Usuario where revisa = 'Si'", "Usuario");
                DataManager.fillComboEs(cmbRevisado, ds);
                ds = DataManager.selTab("select idUsuario,nombre from Usuario where aprueba = 'Si'", "Usuario");
                DataManager.fillComboEs(cmbAprobado, ds);
                ds = DataManager.selTab("select idUsuario,nombre from Usuario where autoriza = 'Si'", "Usuario");
                DataManager.fillComboEs(cmbAutorizado, ds);

                cmbEstado.DataSource = null;
                cmbEstado.Items.Add("<Seleccionar>");
                cmbEstado.Items.Add("En Creacion");
                cmbEstado.Items.Add("Vigente");
          
                cmbEstado.SelectedIndex = 0;
                if(rol.Equals("sysadmin")){
                    spinCorrelativo.Visible = true;
                }
             

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error De Aplicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public int minValue() {

            return 0;       
        }

        private void picCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void cmbSeccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            DataSet ds;
            ds = DataManager.selTab("select idSubSeccion,Convert(Varchar,idSubSeccion) + ' - ' + descripcion from SubSeccion where idSeccion = '" + cmbSeccion.SelectedValue + "'", "SubSeccion");
            DataManager.fillComboEs(cmbSubseccion, ds);
        }

    
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            validaCodigo();
            if (status) {
                getCode();
            }

        }

        public string getCode() {
            int correlativo = getCorr();
            String codeDoc = cmbTipo.SelectedValue + "-" + cmbArea.SelectedValue + "/" + cmbSeccion.SelectedValue + "." + maskField(cmbSubseccion.SelectedValue.ToString()) + "." +  maskField(correlativo.ToString());
            lblCodigo.Text = codeDoc;
            lblCorrelativo.Text =  maskField(correlativo.ToString());
            spinCorrelativo.Value = correlativo;
            return codeDoc;
        }

        public String maskField(String value) {
            if (value.Length == 1)
            {
                return "0" + value;
            }
            else {
                return value;
            }
        }


        public int getLastEdition()
        {

            String edition = "";
            int max = 0;
            DataSet ds = DataManager.selTab("select MAX(edicion) from Documento where idTipo = '" + cmbTipo.SelectedValue + "' and idArea = '" + cmbArea.SelectedValue + "' and idSeccion = '" + cmbSeccion.SelectedValue + "' and idSubSeccion = " + cmbSubseccion.SelectedValue + " and correlativo = " + getCorr().ToString(), "Documento");
            foreach (DataRow row in ds.Tables["Documento"].Rows)
            {
                edition = row[0].ToString();
            }
            try
            {
                max = Convert.ToInt32(edition);
                return max;
            }
            catch
            {
                return 0;
            }
        }


        public int getCorr()
        {

            String corr = "";
            int max = 0;
            DataSet ds = DataManager.selTab("select MAX(correlativo) from Documento where idTipo = '" + cmbTipo.SelectedValue + "' and idArea = '" + cmbArea.SelectedValue + "' and idSeccion = '" + cmbSeccion.SelectedValue + "' and idSubSeccion = " + cmbSubseccion.SelectedValue, "Documento");
            foreach (DataRow row in ds.Tables["Documento"].Rows)
            {
                corr = row[0].ToString();
            }
            try
            {
                max = Convert.ToInt32(corr);
                return max + 1;
            }
            catch
            {
                return 1;
            }

        }

        public void validaCodigo() {
            errorProv.SetError(this.cmbTipo, "");
            errorProv.SetError(this.cmbArea, "");
            errorProv.SetError(this.cmbSeccion, "");
            errorProv.SetError(this.cmbSubseccion, "");
            status = true;
            if (cmbTipo.SelectedIndex == 0)
            {
                errorProv.SetError(this.cmbTipo, "Ingresar Tipo");
                status = false;
            }
            if (cmbArea.SelectedIndex == 0)
            {
                errorProv.SetError(this.cmbArea, "Ingresar Area");
                status = false;
            }
            if (cmbSeccion.SelectedIndex == 0)
            {
                errorProv.SetError(this.cmbSeccion, "Ingresar Seccion");
                status = false;
            }
            if (cmbSubseccion.SelectedIndex == 0)
            {
                errorProv.SetError(this.cmbSubseccion, "Ingresar Sub-Sección");
                status = false;
            }
        }

        public void validaAlta()
        {
            errorProv.SetError(this.cmbTipo, "");
            errorProv.SetError(this.cmbArea, "");
            errorProv.SetError(this.cmbSeccion, "");
            errorProv.SetError(this.cmbSubseccion, "");
            errorProv.SetError(this.cmbEstado, "");
            errorProv.SetError(this.txtNombre, "");
            errorProv.SetError(this.cmbElaborado, "");
            errorProv.SetError(this.spinEdicion, "");
            errorProv.SetError(this.cmbRevisado, "");
            errorProv.SetError(this.cmbAprobado, "");
            errorProv.SetError(this.cmbAutorizado, "");
            errorProv.SetError(this.btnExaminar, "");

            statusAll = true;
            if (cmbTipo.SelectedIndex == 0)
            {
                errorProv.SetError(this.cmbTipo, "Ingresar Tipo");
                statusAll = false;
            }
            if (cmbArea.SelectedIndex == 0)
            {
                errorProv.SetError(this.cmbArea, "Ingresar Area");
                statusAll = false;
            }
            if (cmbSeccion.SelectedIndex == 0)
            {
                errorProv.SetError(this.cmbSeccion, "Ingresar Seccion");
                statusAll = false;
            }
            if (cmbSubseccion.SelectedIndex == 0)
            {
                errorProv.SetError(this.cmbSubseccion, "Ingresar Sub-Sección");
                statusAll = false;
            }

            if(txtNombre.Text.Trim().Length == 0){
                errorProv.SetError(this.txtNombre, "Ingresa Nombre");
                statusAll = false;
            }

            if(cmbEstado.SelectedIndex == 0){
                errorProv.SetError(this.cmbEstado, "Ingresar Estado");
                statusAll = false;
            }

            if (cmbElaborado.SelectedIndex == 0)
            {
                errorProv.SetError(this.cmbElaborado, "Ingresar Usuario que Elabora el documento");
                statusAll = false;
            }

            if (cmbEstado.SelectedItem.ToString().Equals("Vigente"))
            {
                if (cmbRevisado.SelectedIndex == 0)
                {
                    errorProv.SetError(this.cmbRevisado, "Ingresar Usuario que Revisa el documento");
                    statusAll = false;
                }
                if (cmbAprobado.SelectedIndex == 0)
                {
                    errorProv.SetError(this.cmbAprobado, "Ingresar Usuario que Aprueba el documento");
                    statusAll = false;
                }
                if (cmbAutorizado.SelectedIndex == 0)
                {
                    errorProv.SetError(this.cmbAutorizado, "Ingresar Usuario que Autoriza el documento");
                    statusAll = false;
                }
                if (lblLink.Text.Trim().Length == 0)
                {
                    errorProv.SetError(this.btnExaminar, "Ingresar Link De Documento");
                    statusAll = false;
                }
            }

            
            
            if (cmbTipo.SelectedIndex > 0 && cmbArea.SelectedIndex > 0 && cmbSeccion.SelectedIndex > 0 && cmbSubseccion.SelectedIndex > 0) {
                int lastEditon = getLastEdition();
                 if(lastEditon >= spinEdicion.Value){
                     errorProv.SetError(this.spinEdicion, "Edición debe ser mayor a la ultima ingresada, ultima ingresada # " +lastEditon.ToString());
                     statusAll = false;
                 }
            }
        }

        private void picOk_Click(object sender, EventArgs e)
        {
        
            statusAll = true;
           
            validaAlta();
            if(statusAll){
                //Inserta Documento
                int correl =0;
                String codeDoc = "";
             
                if(rol.Equals("sysadmin")){
                    codeDoc = cmbTipo.SelectedValue + "-" + cmbArea.SelectedValue + "/" + cmbSeccion.SelectedValue + "." +maskField(cmbSubseccion.SelectedValue.ToString()) + "." + maskField(spinCorrelativo.Value.ToString());
                    lblCodigo.Text =maskField(codeDoc);
                }else{
                     codeDoc = getCode();
                     correl = getCorr();
                }
                  

                String query;
                if(rol.Equals("sysadmin")){
                  query = "INSERT INTO Documento VALUES("
                                  + "'" + codeDoc + "',"
                                  + "" + spinEdicion.Value + ","
                                  + "'" + cmbTipo.SelectedValue + "',"
                                  + "'" + cmbArea.SelectedValue + "',"
                                  + "'" + cmbSeccion.SelectedValue + "',"
                                  + "" + cmbSubseccion.SelectedValue + ","
                                  + "" + spinCorrelativo.Value + "," 
                                  + "'" + cmbNivel.SelectedValue + "',"
                                  + "'" + txtNombre.Text.Trim() + "',"
                                  + "'" + cmbEstado.SelectedItem.ToString() + "',"
                                  + "'" + cmbElaborado.SelectedValue + "',"
                                  + "CONVERT(DATETIME,'" + dateElaborado.Value.Date.ToShortDateString().ToString() + "', 105),"
                                  + "'" + cmbRevisado.SelectedValue + "',"
                                  + getDate(cmbRevisado.SelectedIndex, dateRevisado.Value.Date.ToShortDateString().ToString()) + ","
                                  + "'" + cmbAprobado.SelectedValue + "',"
                                  + getDate(cmbAprobado.SelectedIndex, dateAprobado.Value.Date.ToShortDateString().ToString()) + ","
                                  + "'" + cmbAutorizado.SelectedValue + "',"
                                  + getDate(cmbAutorizado.SelectedIndex, dateAutorizado.Value.Date.ToShortDateString().ToString()) + ","
                                  + "" + spinVigencia.Value + ","
                                  + "" + spinEjemplar.Value + ","
                                  + "'" + txtProcAnterior.Text.Trim() + "',"
                                  + "CONVERT(DATETIME,'" + dateVigencia.Value.Date.ToShortDateString().ToString() + "', 105),"
                                  + "'" + lblLink.Text.Trim() + "')";
                }else{
                    query = "INSERT INTO Documento VALUES("
                                + "'" + codeDoc + "',"
                                + "" + spinEdicion.Value + ","
                                + "'" + cmbTipo.SelectedValue + "',"
                                + "'" + cmbArea.SelectedValue + "',"
                                + "'" + cmbSeccion.SelectedValue + "',"
                                + "" + cmbSubseccion.SelectedValue + ","
                                + "" + correl + ","
                                + "'" + cmbNivel.SelectedValue + "',"
                                + "'" + txtNombre.Text.Trim() + "',"
                                + "'" + cmbEstado.SelectedItem.ToString() + "',"
                                + "'" + cmbElaborado.SelectedValue + "',"
                                + "CONVERT(DATETIME,'" + dateElaborado.Value.Date.ToShortDateString().ToString() + "', 105),"
                                + "'" + cmbRevisado.SelectedValue + "',"
                                + getDate(cmbRevisado.SelectedIndex, dateRevisado.Value.Date.ToShortDateString().ToString()) + ","
                                + "'" + cmbAprobado.SelectedValue + "',"
                                + getDate(cmbAprobado.SelectedIndex, dateAprobado.Value.Date.ToShortDateString().ToString()) + ","
                                + "'" + cmbAutorizado.SelectedValue + "',"
                                + getDate(cmbAutorizado.SelectedIndex, dateAutorizado.Value.Date.ToShortDateString().ToString()) + ","
                                + "" + spinVigencia.Value + ","
                                + "" + spinEjemplar.Value + ","
                                + "'" + txtProcAnterior.Text.Trim() + "',"
                                + "CONVERT(DATETIME,'" + dateVigencia.Value.Date.ToShortDateString().ToString() + "', 105),"
                                + "'" + lblLink.Text.Trim() + "')";
                }

                response = DataManager.insert(query);
                if (response.Code != 0)
                {
                    MessageBox.Show(response.Message, "Error Sql", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                    
                }
                //Graba Log
                listDetalleLog = new List<script.DetalleLog>();
                listDetalleLog.Add(new script.DetalleLog("idDocumento", "", codeDoc));
                listDetalleLog.Add(new script.DetalleLog("edicion", "", spinEdicion.Value.ToString()));
                DataManager.saveLog("Documento", "INSERT", usuario, listDetalleLog);

                //Inserta Anexos
                String queryAnexo;
                for (int i = 0; i < grdAnexo.Rows.Count; i++)
                {
                    queryAnexo = "INSERT INTO Anexo VALUES("
                             + "'" + codeDoc + "',"
                             + "" + spinEdicion.Value + ","
                             + "" + grdAnexo.Rows[i].Cells[0].Value + ","
                             + "'" + grdAnexo.Rows[i].Cells[1].Value + "',"
                             + "'" + grdAnexo.Rows[i].Cells[2].Value + "',"
                             + "'" + grdAnexo.Rows[i].Cells[3].Value + "',"
                             + "'" + grdAnexo.Rows[i].Cells[4].Value + "',"
                             + "'" + grdAnexo.Rows[i].Cells[5].Value + "',"
                             + "'" + grdAnexo.Rows[i].Cells[6].Value + "')";
                    response = DataManager.insert(queryAnexo);
                    if (response.Code != 0)
                    {
                        MessageBox.Show(response.Message, "Error Sql", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }
                     
                }

                //Inserta Registros
                String queryRegistro;
                for (int i = 0; i < grdRegistro.Rows.Count; i++)
                {
                    queryRegistro = "INSERT INTO Registro VALUES("
                             + "'" + codeDoc + "',"
                             + "" + spinEdicion.Value + ","
                             + "" + grdRegistro.Rows[i].Cells[0].Value + ","
                             + "'" + grdRegistro.Rows[i].Cells[1].Value + "',"
                             + "'" + grdRegistro.Rows[i].Cells[2].Value + "',"
                             + "'" + grdRegistro.Rows[i].Cells[3].Value + "',"
                             + "'" + grdRegistro.Rows[i].Cells[4].Value + "',"
                             + "'" + grdRegistro.Rows[i].Cells[5].Value + "',"
                             + "'" + grdRegistro.Rows[i].Cells[6].Value + "')";
                    response = DataManager.insert(queryRegistro);
                    if (response.Code != 0)
                    {
                        MessageBox.Show(response.Message, "Error Sql", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }

                }

                MessageBox.Show("Alta de Documento Exitosa", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cleanControls();
                lblCodigo.Text = "-------------------";
                cmbTipo.Focus();
                setGrdw();
                
            }
        }

        public void cleanControls() {
            lblCodigo.Text = "";
            lblCorrelativo.Text = "";
            spinEdicion.Value = 1;
            cmbTipo.SelectedIndex = 0;
            cmbArea.SelectedIndex = 0;
            cmbSeccion.SelectedIndex = 0;
            cmbSubseccion.SelectedIndex = 0;
            cmbNivel.SelectedIndex = 0;
            txtNombre.Text = "";
            cmbEstado.SelectedIndex = 0;
            cmbElaborado.SelectedIndex = 0;
            cmbRevisado.SelectedIndex = 0;
            cmbAprobado.SelectedIndex = 0;
            cmbAutorizado.SelectedIndex = 0;
            spinVigencia.Value = 1;
            spinEjemplar.Value = 0;
            txtProcAnterior.Text = "";
            dateVigencia.Value = DateTime.Now.Date;
            lblLink.Text = "";
            grdAnexo.Rows.Clear();
            grdRegistro.Rows.Clear();
            spinCorrelativo.Value = 1;
            
        }


        public String getDate(int index,String fecha) {
            if (index != 0)
            {
                return "CONVERT(DATETIME,'" + fecha + "', 105)";
            }
            else {
                return "NULL";
            }
        }


        public void setGrdw()
        {
            if (rol.Equals("superusuario"))
            {
                queryDoc = SELECT__DOCUMENTO_RESTRICTED
                         + "and (D.estado = 'Vigente' or D.estado = 'En Creacion') "
                         + ORDER_BY_DOC;
            }
            else if (rol.Equals("regular"))
            {
                queryDoc = SELECT__DOCUMENTO_RESTRICTED
                           + "and (D.estado = 'Vigente' or D.estado = 'En Creacion') and D.elaboradoPor = '" + usuario + "' "
                           + ORDER_BY_DOC;
            }
            else if (rol.Equals("sysadmin"))
            {
                queryDoc = SELECT_DOCUMENTO
                           + ORDER_BY_DOC;
            }


            ds = DataManager.selTab(queryDoc, "Documento");
            grd.DataSource = ds;
            grd.DataMember = "Documento";
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                lblLink.Text = openFileDialog1.FileName;
              
            }
        }

        private void addAnexo_Click(object sender, EventArgs e)
        {
            RegistroAnexo nuevo = new RegistroAnexo("A",grdAnexo,"Alta");
            nuevo.ShowDialog();
        }

        private void addRegistro_Click(object sender, EventArgs e)
        {
            RegistroAnexo nuevo = new RegistroAnexo("R", grdRegistro,"Alta");
            nuevo.ShowDialog();
        }

        private void delAnexo_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdAnexo.Rows.Count > 0)
                {
                  
                    grdAnexo.Rows[grdAnexo.CurrentCellAddress.Y].Cells[2].Value = "";
                    grdAnexo.Rows[grdAnexo.CurrentCellAddress.Y].Cells[3].Value = "";
                    grdAnexo.Rows[grdAnexo.CurrentCellAddress.Y].Cells[4].Value = "";
                    grdAnexo.Rows[grdAnexo.CurrentCellAddress.Y].Cells[5].Value = "";
                    grdAnexo.Rows[grdAnexo.CurrentCellAddress.Y].Cells[6].Value = "";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error De Aplicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void delRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdRegistro.Rows.Count > 0)
                {
                    grdRegistro.Rows[grdRegistro.CurrentCellAddress.Y].Cells[2].Value = "";
                    grdRegistro.Rows[grdRegistro.CurrentCellAddress.Y].Cells[3].Value = "";
                    grdRegistro.Rows[grdRegistro.CurrentCellAddress.Y].Cells[4].Value = "";
                    grdRegistro.Rows[grdRegistro.CurrentCellAddress.Y].Cells[5].Value = "";
                    grdRegistro.Rows[grdRegistro.CurrentCellAddress.Y].Cells[6].Value = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error De Aplicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modRegistro_Click(object sender, EventArgs e)
        {
            if (grdRegistro.Rows.Count > 0)
            {
                RegistroAnexo nuevo = new RegistroAnexo("R", grdRegistro, "Modificacion");
                nuevo.ShowDialog();
            }
        }

        private void modAnexo_Click(object sender, EventArgs e)
        {
            if (grdAnexo.Rows.Count > 0)
            {
                RegistroAnexo nuevo = new RegistroAnexo("A", grdAnexo, "Modificacion");
                nuevo.ShowDialog();
            }
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

  

        private void spinCorrelativo_ValueChanged(object sender, EventArgs e)
        {
            String codeDoc = cmbTipo.SelectedValue + "-" + cmbArea.SelectedValue + "/" + cmbSeccion.SelectedValue + "." + maskField(cmbSubseccion.SelectedValue.ToString()) + "." + maskField(spinCorrelativo.Value.ToString());
            lblCodigo.Text = codeDoc;
        }

        
        
    }
}
