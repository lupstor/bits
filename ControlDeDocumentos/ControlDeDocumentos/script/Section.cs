using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlDeDocumentos.script
{
    public class Section
    {
          private String code;
        private String description;



        public Section(String cod, String desc)
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

        public String Message
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
