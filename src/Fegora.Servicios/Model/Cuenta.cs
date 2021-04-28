using System;
using System.Collections.Generic;

namespace Fegora.Servicios.Model
{	
	[Serializable]
	public partial class Cuenta
	{
		public CuentaTypes.Canal Canal { get; set; }
		public System.Byte[] CertificadoPfx { get; set; }
		
		public CuentaTypes.Certificador Certificador { get; set; }
		
		public System.String ClaveCertificadoPfx { get; set; }
		
		public List<CuentaTypes.DatoAdicional> DatosAdicionales { get; set; }
				
		public System.String DireccionCorreoElectronico { get; set; }
				
		public System.String DireccionWeb { get; set; }
				
		public System.Boolean EmiteFacturas { get; set; }
				
		public List<CuentaTypes.Establecimiento> Establecimientos { get; set; }
				
		public System.Boolean EstaEnAmbienteDePruebas { get; set; }
				
		public System.String Id { get; set; }
				
		public Nullable<System.Int16> IdCanal { get; set; }
				
		public System.String IdCertificador { get; set; }		
		
		public CuentaTypes.InformacionFiscal InformacionFiscal { get; set; }		
		
		public System.String LogoUri { get; set; }		
		
		public System.String MonedaPorDefecto { get; set; }
				
		public List<CuentaTypes.PlantillasMensajeCorreoElectronico> PlantillasMensajeCorreoElectronico { get; set; }
				
		public List<CuentaTypes.PlantillasPdf> PlantillasPdf { get; set; }
				
		public System.String Slogan { get; set; }
				
		public System.String Telefonos { get; set; }
				
		public System.String TipoDocumentoPorDefecto { get; set; }
				
		public System.String TipoProductoPorDefecto { get; set; }
				
		public System.String UnidadMedidaPorDefecto { get; set; }
				
		public List<CuentaTypes.UsuarioDeCuenta> Usuarios { get; set; }
	}

	namespace CuentaTypes
	{		
		[Serializable]		
		public partial class Canal
		{						
			public System.Int16 Id { get; set; }
						
			public System.String LogoUri { get; set; }
						
			public System.String Nombre { get; set; }
						
			public System.String NombreCorto { get; set; }
		}

		
		[Serializable]		
		public partial class Certificador
		{			
			public System.String Id { get; set; }
		}

		
		[Serializable]		
		public partial class DatoAdicional
		{						
			public System.String Nombre { get; set; }
						
			public System.String Valor { get; set; }
		}
		
		[Serializable]		
		public partial class Establecimiento
		{						
			public System.String CodigoPostal { get; set; }
						
			public System.String Departamento { get; set; }
						
			public System.String Direccion { get; set; }
						
			public System.String Id { get; set; }
						
			public System.String Municipio { get; set; }
						
			public System.String Nombre { get; set; }
						
			public System.String Pais { get; set; }
		}

		
		[Serializable]		
		public partial class InformacionFiscal
		{						
			public System.String AfiliacionIsr { get; set; }
						
			public System.String AfiliacionIsrResolucionSat { get; set; }
						
			public System.String AfiliacionIva { get; set; }
						
			public System.String CodigoEstablecimiento { get; set; }
						
			public InformacionFiscalTypes.DireccionCuenta Direccion { get; set; }
						
			public System.String DireccionCorreoElectronico { get; set; }
						
			public System.Boolean EsExentoIva { get; set; }
						
			public System.Boolean EsRetenedorIva { get; set; }
						
			public System.String Id { get; set; }
						
			public System.String MotivoExencionIva { get; set; }
						
			public System.String Nombre { get; set; }
						
			public System.String NombreComercial { get; set; }
		}

		namespace InformacionFiscalTypes
		{
			
			[Serializable]			
			public partial class DireccionCuenta
			{								
				public System.String CodigoPostal { get; set; }
								
				public System.String Departamento { get; set; }
								
				public System.String Direccion { get; set; }
								
				public System.String Municipio { get; set; }
								
				public System.String Pais { get; set; }
			}
		}

		
		[Serializable]		
		public partial class PlantillasMensajeCorreoElectronico
		{						
			public System.Guid Id { get; set; }
						
			public System.String IdPlantillaProveedor { get; set; }			
			
			public System.Byte Prioridad { get; set; }
						
			public System.String TextoAsunto { get; set; }
						
			public System.String TextoEncabezado { get; set; }
						
			public System.String TextoPie { get; set; }
		}

		
		[Serializable]		
		public partial class PlantillasPdf
		{
			public System.String ArchivoUri { get; set; }
						
			public System.String CondicionAdicional { get; set; }
			
			public System.Guid Id { get; set; }
						
			public System.String Nombre { get; set; }
						
			public System.Byte Prioridad { get; set; }
						
			public System.String TiposDte { get; set; }
		}

		
		[Serializable]		
		public partial class UsuarioDeCuenta
		{						
			public System.String Apellidos { get; set; }
						
			public System.String Nombres { get; set; }
						
			public List<UsuarioDeCuentaTypes.Rol> Roles { get; set; }
						
			public System.String Username { get; set; }
		}

		namespace UsuarioDeCuentaTypes
		{			
			[Serializable]			
			public partial class Rol
			{								
				public System.String Id { get; set; }
								
				public System.String Nombre { get; set; }
			}
		}
	}

}
