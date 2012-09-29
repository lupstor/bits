using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlDeDocumentos.script
{
    public class UserDat
    {

        private String code;
        private String description;
        private String elabora;
        private String revisa;
        private String aprueba;
        private String autoriza;




        public UserDat()
        {
          
            
        }

        public String Code
        {
            get
            {
                return code;
            }
            set
            {
                code = value;               
            }
        }

        public String Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }
        public String Elabora
        {
            get
            {
                return elabora;
            }
            set
            {
                elabora = value;
            }
        }

        public String Revisa
        {
            get
            {
                return revisa;
            }
            set
            {
                revisa = value;
            }
        }

        public String Aprueba
        {
            get
            {
                return aprueba;
            }
            set
            {
                aprueba = value;
            }
        }

        public String Autoriza
        {
            get
            {
                return autoriza;
            }
            set
            {
                autoriza = value;
            }
        }
    }
}
