using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlDeDocumentos.script
{
    class Combo
    {

        private String code;
        private String description;



        public Combo(String cod, String desc)
        {
            this.code = cod;
            this.description = desc;
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
    }
}
