using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlDeDocumentos.script
{
    class DetalleLog
    {

        private String campo;
        private String valAntes;
        private String valDespues;



        public DetalleLog(String p1, String p2,String p3)
        {
            this.campo = p1;
            this.valAntes = p2;
            this.valDespues = p3;
        }

        public String Campo
        {
            get
            {
                return campo;
            }
            set
            {
                campo = value;               
            }
        }

        public String ValAntes
        {
            get
            {
                return valAntes;
            }
            set
            {
                valAntes = value;
            }
        }

        public String ValDespues
        {
            get
            {
                return valDespues;
            }
            set
            {
                valDespues = value;
            }
        }
    }
}
