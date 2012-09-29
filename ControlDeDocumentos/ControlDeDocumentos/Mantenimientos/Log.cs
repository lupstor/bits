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
    public partial class Log : Form
    {

        DataSet ds;
        public Log()
        {
            InitializeComponent();
        }

        private void Log_Load(object sender, EventArgs e)
        {
            setGrdw();
        }


        public void setGrdw()
        {
            ds = DataManager.selTab("select idLog AS 'ID', fecha AS 'Fecha y Hora', operacion AS 'Operación',usuario AS 'Usuario',tabla AS 'Tabla', aplicacion AS 'Aplicacion', ip AS 'Ip' from LogDoc", "LogDoc");
            grd.DataSource = ds;
            grd.DataMember = "LogDoc";
        }

        private void picBuscar_Click(object sender, EventArgs e)
        {
            String fechaFin = dateFin.Value.ToShortDateString() +" " +"23:59:59";
            ds = DataManager.selTab("select idLog AS 'ID', fecha AS 'Fecha y Hora', operacion AS 'Operación',usuario AS 'Usuario',tabla AS 'Tabla', aplicacion AS 'Aplicacion', ip AS 'Ip' from LogDoc where fecha between " + "CONVERT(DATETIME,'" + dateInicio.Value.Date.ToShortDateString().ToString() + "', 105) and " + "CONVERT(DATETIME,'" + fechaFin + "', 105)", "LogDoc");
            grd.DataSource = ds;
            grd.DataMember = "LogDoc";
        }

        private void grd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grd.Rows.Count > 0)
            {
                String cod = grd[0, grd.CurrentCellAddress.Y].Value.ToString();
                DetalleLog nuevo = new DetalleLog(cod);
                nuevo.ShowDialog();
            }
        }
    }
}
