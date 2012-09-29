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
    public partial class DetalleLog : Form
    {

        private String codLog;
        private DataSet ds;
        public DetalleLog(String p1)
            
        {
            this.codLog = p1;
            InitializeComponent();
        }

        private void DetalleLog_Load(object sender, EventArgs e)
        {
            setGrdw();
        }

        public void setGrdw()
        {
            ds = DataManager.selTab("select campo AS 'Campo', valAntes AS 'Valor Antes', valDespues 'Valor Despues' from DetalleLogDoc where idLog =  " + codLog, "DetalleLogDoc");
            grd.DataSource = ds;
            grd.DataMember = "DetalleLogDoc";
        }
    }
}
