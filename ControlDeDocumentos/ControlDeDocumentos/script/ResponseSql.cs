using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlDeDocumentos.script
{
    class ResponseSql
    {

        private int code;
        private String message;



        public ResponseSql(int cod, String mess)
        {
            this.code = cod;
            this.message = mess;
        }

        public int Code
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
                return message;
            }
            set
            {
                message = value;
            }
        }
    }
}
