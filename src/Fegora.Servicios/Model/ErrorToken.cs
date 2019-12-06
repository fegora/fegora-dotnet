using System;
using System.Collections.Generic;
using System.Text;

namespace Fegora.Servicios.Model
{
    [Serializable]
    public class ErrorToken
    {        
        public string error { get; set; }

        public string error_description { get; set; }
    }

}
