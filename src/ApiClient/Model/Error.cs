using System;
using System.Collections.Generic;
using System.Text;

namespace Fegora.Servicios.Model
{
    [Serializable]
    public class Error
    {
        public Severidad Severidad { get; set; }

        public string Codigo { get; set; }

        public string Mensaje { get; set; }

        public string MasInformacion { get; set; }
    }

    [Serializable]
    public enum Severidad
    {
        Sugerencia, Advertencia, Error, Fatal
    }
}
