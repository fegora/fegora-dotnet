using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Fegora.Servicios.Model
{
    [Serializable]
    public partial class Contribuyente
    {        
        public System.String Id { get; set; }

        public System.String Nombre { get; set; }

        public System.String NombreComercial { get; set; }        
    }
}
