using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Fegora.Servicios.Model
{
    [Serializable]
    public partial class Dte
    {
        public List<DteTypes.AbonosPactado> AbonosPactados { get; set; }

        public Nullable<System.Boolean> Anulado { get; set; }

        public System.String ArchivoPdfUri { get; set; }
        
        public System.String ArchivoXmlUri { get; set; }
        
        public DteTypes.Certificador Certificador { get; set; }
        
        public List<DteTypes.DatoAdicional> DatosAdicionales { get; set; }
        
        public DteTypes.DatosAnulacion DatosAnulacion { get; set; }
        
        public DteTypes.DatosExportacion DatosExportacion { get; set; }
        
        public DteTypes.DteOriginal DteOriginal { get; set; }
        
        public System.String DteUri { get; set; }
        
        public DteTypes.Emisor Emisor { get; set; }
        
        public Nullable<System.Boolean> EsExentoIva { get; set; }
        
        public Nullable<System.Boolean> EsExportacion { get; set; }
        
        public System.Boolean? EstaEnAmbienteDePruebas { get; set; }
        
        public System.DateTime FechaCertificacion { get; set; }
        
        public Nullable<System.DateTime> FechaEmision { get; set; }
        
        [JsonProperty("id")]
        public System.String Id { get; set; }
        
        public System.String IdCuenta { get; set; }
        
        public System.String IdDteOriginal { get; set; }
        
        public List<DteTypes.Item> Items { get; set; }
        
        public Moneda? Moneda { get; set; }
        
        public System.String MotivoAjuste { get; set; }
        
        public System.String MotivoExencionIva { get; set; }
        
        public System.Int64 Numero { get; set; }
        
        public Nullable<System.Int32> NumeroAcceso { get; set; }
        
        public System.String Observaciones { get; set; }
        
        public DteTypes.Receptor Receptor { get; set; }
        
        public DteTypes.RetencionesFacturaEspecial RetencionesFacturaEspecial { get; set; }
        
        public System.String Serie { get; set; }
        
        public TipoDte? Tipo { get; set; }
        
        public System.Decimal Total { get; set; }
    }

    namespace DteTypes
    {
        [Serializable]
        public partial class DireccionEntidad
        {

            public System.String CodigoPostal { get; set; }

            public System.String Departamento { get; set; }

            public System.String Direccion { get; set; }

            public System.String Municipio { get; set; }

            public Pais? Pais { get; set; }
        }

        [Serializable]        
        public partial class AbonosPactado
        {
            
            public Nullable<System.DateTime> Fecha { get; set; }
            
            public Nullable<System.Decimal> Monto { get; set; }
            
            public Nullable<System.Int32> Numero { get; set; }
        }
     
        [Serializable]        
        public partial class Certificador
        {            
            public DireccionEntidad Direccion { get; set; }
            
            public System.String DireccionCorreoElectronico { get; set; }
            
            public System.String Id { get; set; }
            
            public System.String Nombre { get; set; }
            
            public System.String NombreComercial { get; set; }
        }
    
        [Serializable]        
        public partial class DatoAdicional
        {
            
            public System.String Etiqueta { get; set; }
            
            public System.String Nombre { get; set; }
            
            public System.String Valor { get; set; }
            
            public Nullable<System.Boolean> Visible { get; set; }
        }

        [Serializable]        
        public partial class DatosAnulacion
        {            
            public System.String ArchivoXmlUri { get; set; }
            
            public Certificador Certificador { get; set; }
            
            public Nullable<System.DateTime> FechaAnulacion { get; set; }
            
            public Nullable<System.DateTime> FechaCertificacion { get; set; }
            
            public System.String MotivoAnulacion { get; set; }
        }

        [Serializable]        
        public partial class DatosExportacion
        {            
            public System.String CodigoComprador { get; set; }
            
            public System.String CodigoConsignatario { get; set; }
            
            public System.String CodigoExportador { get; set; }
            
            public System.String DireccionComprador { get; set; }
            
            public System.String DireccionConsignatario { get; set; }
            
            public System.String Incoterm { get; set; }
            
            public System.String NombreComprador { get; set; }
            
            public System.String NombreConsignatario { get; set; }
            
            public System.String NombreExportador { get; set; }
            
            public System.String OtraReferencia { get; set; }
        }

        [Serializable]        
        public partial class DteOriginal
        {            
            public System.DateTime FechaCertificacion { get; set; }
            
            public Nullable<System.DateTime> FechaEmision { get; set; }
            
            public System.String Id { get; set; }
            
            public System.Int64 Numero { get; set; }
            
            public System.String Serie { get; set; }
            
            public TipoDte Tipo { get; set; }
            
            public System.Decimal Total { get; set; }

            public System.Boolean EsRegimenAntiguo { get; set; }
        }

        [Serializable]        
        public partial class Emisor
        {            
            public System.String AfiliacionIsr { get; set; }
            
            public System.String AfiliacionIsrResolucionSat { get; set; }
            
            public System.String AfiliacionIva { get; set; }
            
            public System.String CodigoEstablecimiento { get; set; }
            
            public DireccionEntidad Direccion { get; set; }
            
            public System.String DireccionCorreoElectronico { get; set; }
            
            public System.Boolean EsExentoIva { get; set; }
            
            public System.Boolean EsRetenedorIva { get; set; }
            
            public System.String Id { get; set; }
            
            public System.String MotivoExencionIva { get; set; }
            
            public System.String Nombre { get; set; }
            
            public System.String NombreComercial { get; set; }
        }

        [Serializable]        
        public partial class Item
        {            
            public Nullable<System.Decimal> Cantidad { get; set; }
            
            public List<DatoAdicional> DatosAdicionales { get; set; }
            
            public System.String Descripcion { get; set; }
            
            public Nullable<System.Decimal> Descuento { get; set; }
            
            public List<ItemTypes.Impuesto> Impuestos { get; set; }
            
            public System.Decimal Precio { get; set; }
            
            public System.Decimal PrecioUnitario { get; set; }
            
            public TipoItem? Tipo { get; set; }
            
            public System.Decimal Total { get; set; }
            
            public System.String UnidadMedida { get; set; }
        }

        namespace ItemTypes
        {
            [Serializable]            
            public partial class Impuesto
            {                
                public System.Byte CodigoUnidadGravable { get; set; }
                
                public System.Decimal MontoGravable { get; set; }
                
                public System.Decimal MontoImpuesto { get; set; }
                
                public System.String NombreCorto { get; set; }
            }
        }
        
        [Serializable]        
        public partial class Receptor
        {
            public DteTypes.DireccionEntidad Direccion { get; set; }
            
            public System.String DireccionCorreoElectronico { get; set; }
            
            public System.String Id { get; set; }
            
            public System.String Nombre { get; set; }
            
            public System.String NombreComercial { get; set; }
        }

        [Serializable]        
        public partial class RetencionesFacturaEspecial
        {            
            public System.Decimal RetencionIsr { get; set; }
            
            public System.Decimal RetencionIva { get; set; }
            
            public System.Decimal TotalMenosRetenciones { get; set; }
        }
    }

}