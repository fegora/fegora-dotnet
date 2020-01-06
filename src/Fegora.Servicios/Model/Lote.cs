using System;

namespace Fegora.Servicios.Model
{ 
	[Serializable]
	public partial class Lote
	{
        public string Archivo { get; set; }

        public System.String ArchivoUri { get; set; }
		
		public System.Int32 CantidadOperaciones { get; set; }
		
		public System.Int32 CantidadOperacionesEjecutadas { get; set; }
		
		public System.Int32 CantidadOperacionesError { get; set; }
		
		public System.Int32 CantidadOperacionesPendientesEjecucion { get; set; }
		
		public System.String Estado { get; set; }
		
		public System.DateTime FechaCreacion { get; set; }
		
		public System.String Id { get; set; }
		
		public System.String IdCuenta { get; set; }
		
		public System.String ResultadoArchivoUri { get; set; }
		
		public Nullable<System.DateTime> UltimaFechaEdicion { get; set; }
		
		public System.String UsuarioCreacion { get; set; }
		
		public System.String UsuarioEdicion { get; set; }
	}

}




