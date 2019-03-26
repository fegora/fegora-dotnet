using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Fegora.Servicios.Model
{
    /// <summary> Document class which is derived from the entity 'Dte'.</summary>
    [Serializable]
    public partial class Dte
    {
        /// <summary>Gets or sets the AbonosPactados field. </summary>
        
        public List<DteTypes.AbonosPactado> AbonosPactados { get; set; }
        /// <summary>Gets or sets the Anulado field. Derived from Entity Model Field 'Dte.Anulado'</summary>
        
        public Nullable<System.Boolean> Anulado { get; set; }
        /// <summary>Gets or sets the ArchivoPdfUri field. Derived from Entity Model Field 'Dte.ArchivoPdfUri'</summary>
        
        public System.String ArchivoPdfUri { get; set; }
        /// <summary>Gets or sets the ArchivoXmlUri field. Derived from Entity Model Field 'Dte.ArchivoXmlUri'</summary>
        
        public System.String ArchivoXmlUri { get; set; }
        /// <summary>Gets or sets the Certificador field. </summary>
        
        public DteTypes.Certificador Certificador { get; set; }
        /// <summary>Gets or sets the DatoAdicionales field. </summary>
        
        public List<DteTypes.DatoAdicional> DatoAdicionales { get; set; }
        /// <summary>Gets or sets the DatosAnulacion field. </summary>
        
        public DteTypes.DatosAnulacion DatosAnulacion { get; set; }
        /// <summary>Gets or sets the DatosExportacion field. </summary>
        
        public DteTypes.DatosExportacion DatosExportacion { get; set; }
        /// <summary>Gets or sets the DteOriginal field. </summary>
        
        public DteTypes.DteOriginal DteOriginal { get; set; }
        /// <summary>Gets or sets the DteUri field. Derived from Entity Model Field 'Dte.DteUri'</summary>
        
        public System.String DteUri { get; set; }
        /// <summary>Gets or sets the Emisor field. </summary>
        
        public DteTypes.Emisor Emisor { get; set; }
        /// <summary>Gets or sets the EsExentoIva field. Derived from Entity Model Field 'Dte.EsExentoIva'</summary>
        
        public Nullable<System.Boolean> EsExentoIva { get; set; }
        /// <summary>Gets or sets the EsExportacion field. Derived from Entity Model Field 'Dte.EsExportacion'</summary>
        
        public Nullable<System.Boolean> EsExportacion { get; set; }
        /// <summary>Gets or sets the EstaEnAmbienteDePruebas field. Derived from Entity Model Field 'Dte.EstaEnAmbienteDePruebas'</summary>
        
        public System.Boolean? EstaEnAmbienteDePruebas { get; set; }
        /// <summary>Gets or sets the FechaCertificacion field. Derived from Entity Model Field 'Dte.FechaCertificacion'</summary>
        
        public System.DateTime FechaCertificacion { get; set; }
        /// <summary>Gets or sets the FechaEmision field. Derived from Entity Model Field 'Dte.FechaEmision'</summary>
        
        public Nullable<System.DateTime> FechaEmision { get; set; }
        /// <summary>Gets or sets the Id field. Derived from Entity Model Field 'Dte.Id'</summary>
        
        [Newtonsoft.Json.JsonProperty("id")]
        public System.String Id { get; set; }
        /// <summary>Gets or sets the IdCuenta field. Derived from Entity Model Field 'Dte.IdCuenta (FK)'</summary>
        
        public System.String IdCuenta { get; set; }
        /// <summary>Gets or sets the IdDteOriginal field. Derived from Entity Model Field 'Dte.IdDteOriginal (FK)'</summary>
        
        public System.String IdDteOriginal { get; set; }
        /// <summary>Gets or sets the Items field. </summary>
        
        public List<DteTypes.Item> Items { get; set; }
        /// <summary>Gets or sets the Moneda field. Derived from Entity Model Field 'Dte.Moneda'</summary>
        
        public Moneda? Moneda { get; set; }
        /// <summary>Gets or sets the MotivoAjuste field. Derived from Entity Model Field 'Dte.MotivoAjuste'</summary>
        
        public System.String MotivoAjuste { get; set; }
        /// <summary>Gets or sets the MotivoExencionIva field. Derived from Entity Model Field 'Dte.MotivoExencionIva'</summary>
        
        public System.String MotivoExencionIva { get; set; }
        /// <summary>Gets or sets the Numero field. Derived from Entity Model Field 'Dte.Numero'</summary>
        
        public System.Int64 Numero { get; set; }
        /// <summary>Gets or sets the NumeroAcceso field. Derived from Entity Model Field 'Dte.NumeroAcceso'</summary>
        
        public Nullable<System.Int32> NumeroAcceso { get; set; }
        /// <summary>Gets or sets the Observaciones field. Derived from Entity Model Field 'Dte.Observaciones'</summary>
        
        public System.String Observaciones { get; set; }
        /// <summary>Gets or sets the Receptor field. </summary>
        
        public DteTypes.Receptor Receptor { get; set; }
        /// <summary>Gets or sets the RetencionesFacturaEspecial field. </summary>
        
        public DteTypes.RetencionesFacturaEspecial RetencionesFacturaEspecial { get; set; }
        /// <summary>Gets or sets the Serie field. Derived from Entity Model Field 'Dte.Serie'</summary>
        
        public System.String Serie { get; set; }
        /// <summary>Gets or sets the Tipo field. Derived from Entity Model Field 'Dte.Tipo'</summary>
        
        public TipoDte? Tipo { get; set; }
        /// <summary>Gets or sets the Total field. Derived from Entity Model Field 'Dte.Total'</summary>
        
        public System.Decimal Total { get; set; }
    }

    namespace DteTypes
    {
        /// <summary> Document class which is derived from the entity 'AbonoPactado (AbonosPactados)'.</summary>
        [Serializable]
        
        public partial class AbonosPactado
        {
            /// <summary>Gets or sets the Fecha field. Derived from Entity Model Field 'AbonoPactado.Fecha'</summary>
            
            public Nullable<System.DateTime> Fecha { get; set; }
            /// <summary>Gets or sets the Monto field. Derived from Entity Model Field 'AbonoPactado.Monto'</summary>
            
            public Nullable<System.Decimal> Monto { get; set; }
            /// <summary>Gets or sets the Numero field. Derived from Entity Model Field 'AbonoPactado.Numero'</summary>
            
            public Nullable<System.Int32> Numero { get; set; }
        }

        /// <summary> Document class which is derived from the value-type 'EntidadFiscal (Certificador)'.</summary>
        [Serializable]
        
        public partial class Certificador
        {
            /// <summary>Gets or sets the Direccion field. </summary>
            
            public CertificadorTypes.DireccionCertificador Direccion { get; set; }
            /// <summary>Gets or sets the DireccionCorreoElectronico field. Derived from Entity Model Field 'EntidadFiscal.DireccionCorreoElectronico'</summary>
            
            public System.String DireccionCorreoElectronico { get; set; }
            /// <summary>Gets or sets the Id field. Derived from Entity Model Field 'EntidadFiscal.Id'</summary>
            
            public System.String Id { get; set; }
            /// <summary>Gets or sets the Nombre field. Derived from Entity Model Field 'EntidadFiscal.Nombre'</summary>
            
            public System.String Nombre { get; set; }
            /// <summary>Gets or sets the NombreComercial field. Derived from Entity Model Field 'EntidadFiscal.NombreComercial'</summary>
            
            public System.String NombreComercial { get; set; }
        }

        namespace CertificadorTypes
        {
            /// <summary> Document class which is derived from the value-type 'Direccion (Certificador.Direccion)'.</summary>
            [Serializable]
            
            public partial class DireccionCertificador
            {
                /// <summary>Gets or sets the CodigoPostal field. Derived from Entity Model Field 'Direccion.CodigoPostal'</summary>
                
                public System.String CodigoPostal { get; set; }
                /// <summary>Gets or sets the Departamento field. Derived from Entity Model Field 'Direccion.Departamento'</summary>
                
                public System.String Departamento { get; set; }
                /// <summary>Gets or sets the Direccion field. Derived from Entity Model Field 'Direccion.Direccion'</summary>
                
                public System.String Direccion { get; set; }
                /// <summary>Gets or sets the Municipio field. Derived from Entity Model Field 'Direccion.Municipio'</summary>
                
                public System.String Municipio { get; set; }
                /// <summary>Gets or sets the Pais field. Derived from Entity Model Field 'Direccion.Pais'</summary>
                
                public Pais? Pais { get; set; }
            }
        }

        /// <summary> Document class which is derived from the entity 'DteDatoAdicional (DatoAdicionales)'.</summary>
        [Serializable]
        
        public partial class DatoAdicional
        {
            /// <summary>Gets or sets the Etiqueta field. Derived from Entity Model Field 'DteDatoAdicional.Etiqueta'</summary>
            
            public System.String Etiqueta { get; set; }
            /// <summary>Gets or sets the Nombre field. Derived from Entity Model Field 'DteDatoAdicional.Nombre'</summary>
            
            public System.String Nombre { get; set; }
            /// <summary>Gets or sets the Valor field. Derived from Entity Model Field 'DteDatoAdicional.Valor'</summary>
            
            public System.String Valor { get; set; }
            /// <summary>Gets or sets the Visible field. Derived from Entity Model Field 'DteDatoAdicional.Visible'</summary>
            
            public Nullable<System.Boolean> Visible { get; set; }
        }

        /// <summary> Document class which is derived from the value-type 'InformacionAnulacion (DatosAnulacion)'.</summary>
        [Serializable]
        
        public partial class DatosAnulacion
        {
            /// <summary>Gets or sets the ArchivoXmlUri field. Derived from Entity Model Field 'InformacionAnulacion.ArchivoXmlUri'</summary>
            
            public System.String ArchivoXmlUri { get; set; }
            /// <summary>Gets or sets the Certificador field. </summary>
            
            public DatosAnulacionTypes.Certificador Certificador { get; set; }
            /// <summary>Gets or sets the FechaAnulacion field. Derived from Entity Model Field 'InformacionAnulacion.FechaAnulacion'</summary>
            
            public Nullable<System.DateTime> FechaAnulacion { get; set; }
            /// <summary>Gets or sets the FechaCertificacion field. Derived from Entity Model Field 'InformacionAnulacion.FechaCertificacion'</summary>
            
            public Nullable<System.DateTime> FechaCertificacion { get; set; }
            /// <summary>Gets or sets the MotivoAnulacion field. Derived from Entity Model Field 'InformacionAnulacion.MotivoAnulacion'</summary>
            
            public System.String MotivoAnulacion { get; set; }
        }

        namespace DatosAnulacionTypes
        {
            /// <summary> Document class which is derived from the value-type 'EntidadFiscal (DatosAnulacion.Certificador)'.</summary>
            [Serializable]
            
            public partial class Certificador
            {
                /// <summary>Gets or sets the Direccion field. </summary>
                
                public CertificadorTypes.DireccionCertificador Direccion { get; set; }
                /// <summary>Gets or sets the DireccionCorreoElectronico field. Derived from Entity Model Field 'EntidadFiscal.DireccionCorreoElectronico'</summary>
                
                public System.String DireccionCorreoElectronico { get; set; }
                /// <summary>Gets or sets the Id field. Derived from Entity Model Field 'EntidadFiscal.Id'</summary>
                
                public System.String Id { get; set; }
                /// <summary>Gets or sets the Nombre field. Derived from Entity Model Field 'EntidadFiscal.Nombre'</summary>
                
                public System.String Nombre { get; set; }
                /// <summary>Gets or sets the NombreComercial field. Derived from Entity Model Field 'EntidadFiscal.NombreComercial'</summary>
                
                public System.String NombreComercial { get; set; }
            }

            namespace CertificadorTypes
            {
                /// <summary> Document class which is derived from the value-type 'Direccion (DatosAnulacion.Certificador.Direccion)'.</summary>
                [Serializable]
                
                public partial class DireccionCertificador
                {
                    /// <summary>Gets or sets the CodigoPostal field. Derived from Entity Model Field 'Direccion.CodigoPostal'</summary>
                    
                    public System.String CodigoPostal { get; set; }
                    /// <summary>Gets or sets the Departamento field. Derived from Entity Model Field 'Direccion.Departamento'</summary>
                    
                    public System.String Departamento { get; set; }
                    /// <summary>Gets or sets the Direccion field. Derived from Entity Model Field 'Direccion.Direccion'</summary>
                    
                    public System.String Direccion { get; set; }
                    /// <summary>Gets or sets the Municipio field. Derived from Entity Model Field 'Direccion.Municipio'</summary>
                    
                    public System.String Municipio { get; set; }
                    /// <summary>Gets or sets the Pais field. Derived from Entity Model Field 'Direccion.Pais'</summary>
                    
                    public Pais Pais { get; set; }
                }
            }
        }

        /// <summary> Document class which is derived from the value-type 'InformacionExportacion (DatosExportacion)'.</summary>
        [Serializable]
        
        public partial class DatosExportacion
        {
            /// <summary>Gets or sets the CodigoComprador field. Derived from Entity Model Field 'InformacionExportacion.CodigoComprador'</summary>
            
            public System.String CodigoComprador { get; set; }
            /// <summary>Gets or sets the CodigoConsignatario field. Derived from Entity Model Field 'InformacionExportacion.CodigoConsignatario'</summary>
            
            public System.String CodigoConsignatario { get; set; }
            /// <summary>Gets or sets the CodigoExportador field. Derived from Entity Model Field 'InformacionExportacion.CodigoExportador'</summary>
            
            public System.String CodigoExportador { get; set; }
            /// <summary>Gets or sets the DireccionComprador field. Derived from Entity Model Field 'InformacionExportacion.DireccionComprador'</summary>
            
            public System.String DireccionComprador { get; set; }
            /// <summary>Gets or sets the DireccionConsignatario field. Derived from Entity Model Field 'InformacionExportacion.DireccionConsignatario'</summary>
            
            public System.String DireccionConsignatario { get; set; }
            /// <summary>Gets or sets the Incoterm field. Derived from Entity Model Field 'InformacionExportacion.Incoterm'</summary>
            
            public System.String Incoterm { get; set; }
            /// <summary>Gets or sets the NombreComprador field. Derived from Entity Model Field 'InformacionExportacion.NombreComprador'</summary>
            
            public System.String NombreComprador { get; set; }
            /// <summary>Gets or sets the NombreConsignatario field. Derived from Entity Model Field 'InformacionExportacion.NombreConsignatario'</summary>
            
            public System.String NombreConsignatario { get; set; }
            /// <summary>Gets or sets the NombreExportador field. Derived from Entity Model Field 'InformacionExportacion.NombreExportador'</summary>
            
            public System.String NombreExportador { get; set; }
            /// <summary>Gets or sets the OtraReferencia field. Derived from Entity Model Field 'InformacionExportacion.OtraReferencia'</summary>
            
            public System.String OtraReferencia { get; set; }
        }

        /// <summary> Document class which is derived from the entity 'Dte (DteOriginal)'.</summary>
        [Serializable]
        
        public partial class DteOriginal
        {
            /// <summary>Gets or sets the FechaCertificacion field. Derived from Entity Model Field 'Dte.FechaCertificacion'</summary>
            
            public System.DateTime FechaCertificacion { get; set; }
            /// <summary>Gets or sets the FechaEmision field. Derived from Entity Model Field 'Dte.FechaEmision'</summary>
            
            public Nullable<System.DateTime> FechaEmision { get; set; }
            /// <summary>Gets or sets the Id field. Derived from Entity Model Field 'Dte.Id'</summary>
            
            public System.String Id { get; set; }
            /// <summary>Gets or sets the Numero field. Derived from Entity Model Field 'Dte.Numero'</summary>
            
            public System.Int64 Numero { get; set; }
            /// <summary>Gets or sets the Serie field. Derived from Entity Model Field 'Dte.Serie'</summary>
            
            public System.String Serie { get; set; }
            /// <summary>Gets or sets the Tipo field. Derived from Entity Model Field 'Dte.Tipo'</summary>
            
            public TipoDte Tipo { get; set; }
            /// <summary>Gets or sets the Total field. Derived from Entity Model Field 'Dte.Total'</summary>
            
            public System.Decimal Total { get; set; }
        }

        /// <summary> Document class which is derived from the value-type 'EntidadFiscal (Emisor)'.</summary>
        [Serializable]
        
        public partial class Emisor
        {
            /// <summary>Gets or sets the AfiliacionIsr field. Derived from Entity Model Field 'EntidadFiscal.AfiliacionIsr'</summary>
            
            public System.String AfiliacionIsr { get; set; }
            /// <summary>Gets or sets the AfiliacionIsrResolucionSat field. Derived from Entity Model Field 'EntidadFiscal.AfiliacionIsrResolucionSat'</summary>
            
            public System.String AfiliacionIsrResolucionSat { get; set; }
            /// <summary>Gets or sets the AfiliacionIva field. Derived from Entity Model Field 'EntidadFiscal.AfiliacionIva'</summary>
            
            public System.String AfiliacionIva { get; set; }
            /// <summary>Gets or sets the CodigoEstablecimiento field. Derived from Entity Model Field 'EntidadFiscal.CodigoEstablecimiento'</summary>
            
            public System.String CodigoEstablecimiento { get; set; }
            /// <summary>Gets or sets the Direccion field. </summary>
            
            public EmisorTypes.DireccionEmisor Direccion { get; set; }
            /// <summary>Gets or sets the DireccionCorreoElectronico field. Derived from Entity Model Field 'EntidadFiscal.DireccionCorreoElectronico'</summary>
            
            public System.String DireccionCorreoElectronico { get; set; }
            /// <summary>Gets or sets the EsExentoIva field. Derived from Entity Model Field 'EntidadFiscal.EsExentoIva'</summary>
            
            public System.Boolean EsExentoIva { get; set; }
            /// <summary>Gets or sets the EsRetenedorIva field. Derived from Entity Model Field 'EntidadFiscal.EsRetenedorIva'</summary>
            
            public System.Boolean EsRetenedorIva { get; set; }
            /// <summary>Gets or sets the Id field. Derived from Entity Model Field 'EntidadFiscal.Id'</summary>
            
            public System.String Id { get; set; }
            /// <summary>Gets or sets the MotivoExencionIva field. Derived from Entity Model Field 'EntidadFiscal.MotivoExencionIva'</summary>
            
            public System.String MotivoExencionIva { get; set; }
            /// <summary>Gets or sets the Nombre field. Derived from Entity Model Field 'EntidadFiscal.Nombre'</summary>
            
            public System.String Nombre { get; set; }
            /// <summary>Gets or sets the NombreComercial field. Derived from Entity Model Field 'EntidadFiscal.NombreComercial'</summary>
            
            public System.String NombreComercial { get; set; }
        }

        namespace EmisorTypes
        {
            /// <summary> Document class which is derived from the value-type 'Direccion (Emisor.Direccion)'.</summary>
            [Serializable]
            
            public partial class DireccionEmisor
            {
                /// <summary>Gets or sets the CodigoPostal field. Derived from Entity Model Field 'Direccion.CodigoPostal'</summary>
                
                public System.String CodigoPostal { get; set; }
                /// <summary>Gets or sets the Departamento field. Derived from Entity Model Field 'Direccion.Departamento'</summary>
                
                public System.String Departamento { get; set; }
                /// <summary>Gets or sets the Direccion field. Derived from Entity Model Field 'Direccion.Direccion'</summary>
                
                public System.String Direccion { get; set; }
                /// <summary>Gets or sets the Municipio field. Derived from Entity Model Field 'Direccion.Municipio'</summary>
                
                public System.String Municipio { get; set; }
                /// <summary>Gets or sets the Pais field. Derived from Entity Model Field 'Direccion.Pais'</summary>
                
                public Pais Pais { get; set; }
            }
        }

        /// <summary> Document class which is derived from the entity 'Item (Items)'.</summary>
        [Serializable]
        
        public partial class Item
        {
            /// <summary>Gets or sets the Cantidad field. Derived from Entity Model Field 'Item.Cantidad'</summary>
            
            public Nullable<System.Decimal> Cantidad { get; set; }
            /// <summary>Gets or sets the DatoAdicionales field. </summary>
            
            public List<ItemTypes.DatoAdicional> DatoAdicionales { get; set; }
            /// <summary>Gets or sets the Descripcion field. Derived from Entity Model Field 'Item.Descripcion'</summary>
            
            public System.String Descripcion { get; set; }
            /// <summary>Gets or sets the Descuento field. Derived from Entity Model Field 'Item.Descuento'</summary>
            
            public Nullable<System.Decimal> Descuento { get; set; }
            /// <summary>Gets or sets the Impuestos field. </summary>
            
            public List<ItemTypes.Impuesto> Impuestos { get; set; }
            /// <summary>Gets or sets the Precio field. Derived from Entity Model Field 'Item.Precio'</summary>
            
            public System.Decimal Precio { get; set; }
            /// <summary>Gets or sets the PrecioUnitario field. Derived from Entity Model Field 'Producto.PrecioUnitario (Items.Producto)'</summary>
            
            public System.Decimal PrecioUnitario { get; set; }
            /// <summary>Gets or sets the Tipo field. Derived from Entity Model Field 'Producto.TipoProducto (Items.Producto)'</summary>

            public TipoItem? Tipo { get; set; }
            /// <summary>Gets or sets the Total field. Derived from Entity Model Field 'Item.Total'</summary>
            
            public System.Decimal Total { get; set; }
            /// <summary>Gets or sets the UnidadMedida field. Derived from Entity Model Field 'Producto.UnidadMedida (Items.Producto)'</summary>
            
            public System.String UnidadMedida { get; set; }
        }

        namespace ItemTypes
        {
            /// <summary> Document class which is derived from the entity 'ItemDatoAdicional (Items.DatoAdicionales)'.</summary>
            [Serializable]
            
            public partial class DatoAdicional
            {
                /// <summary>Gets or sets the Etiqueta field. Derived from Entity Model Field 'ItemDatoAdicional.Etiqueta'</summary>
                
                public System.String Etiqueta { get; set; }
                /// <summary>Gets or sets the Nombre field. Derived from Entity Model Field 'ItemDatoAdicional.Nombre'</summary>
                
                public System.String Nombre { get; set; }
                /// <summary>Gets or sets the Valor field. Derived from Entity Model Field 'ItemDatoAdicional.Valor'</summary>
                
                public System.String Valor { get; set; }
                /// <summary>Gets or sets the Visible field. Derived from Entity Model Field 'ItemDatoAdicional.Visible'</summary>
                
                public Nullable<System.Boolean> Visible { get; set; }
            }

            /// <summary> Document class which is derived from the entity 'ItemImpuesto (Items.Impuestos)'.</summary>
            [Serializable]
            
            public partial class Impuesto
            {
                /// <summary>Gets or sets the CodigoUnidadGravable field. Derived from Entity Model Field 'ItemImpuesto.CodigoUnidadGravable'</summary>
                
                public System.Byte CodigoUnidadGravable { get; set; }
                /// <summary>Gets or sets the MontoGravable field. Derived from Entity Model Field 'ItemImpuesto.MontoGravable'</summary>
                
                public System.Decimal MontoGravable { get; set; }
                /// <summary>Gets or sets the MontoImpuesto field. Derived from Entity Model Field 'ItemImpuesto.MontoImpuesto'</summary>
                
                public System.Decimal MontoImpuesto { get; set; }
                /// <summary>Gets or sets the NombreCorto field. Derived from Entity Model Field 'ItemImpuesto.NombreCorto'</summary>
                
                public System.String NombreCorto { get; set; }
            }
        }

        /// <summary> Document class which is derived from the value-type 'EntidadFiscal (Receptor)'.</summary>
        [Serializable]
        
        public partial class Receptor
        {
            /// <summary>Gets or sets the Direccion field. </summary>
            
            public ReceptorTypes.DireccionReceptor Direccion { get; set; }
            /// <summary>Gets or sets the DireccionCorreoElectronico field. Derived from Entity Model Field 'EntidadFiscal.DireccionCorreoElectronico'</summary>
            
            public System.String DireccionCorreoElectronico { get; set; }
            /// <summary>Gets or sets the Id field. Derived from Entity Model Field 'EntidadFiscal.Id'</summary>
            
            public System.String Id { get; set; }
            /// <summary>Gets or sets the Nombre field. Derived from Entity Model Field 'EntidadFiscal.Nombre'</summary>
            
            public System.String Nombre { get; set; }
            /// <summary>Gets or sets the NombreComercial field. Derived from Entity Model Field 'EntidadFiscal.NombreComercial'</summary>
            
            public System.String NombreComercial { get; set; }
        }

        namespace ReceptorTypes
        {
            /// <summary> Document class which is derived from the value-type 'Direccion (Receptor.Direccion)'.</summary>
            [Serializable]
            
            public partial class DireccionReceptor
            {
                /// <summary>Gets or sets the CodigoPostal field. Derived from Entity Model Field 'Direccion.CodigoPostal'</summary>
                
                public System.String CodigoPostal { get; set; }
                /// <summary>Gets or sets the Departamento field. Derived from Entity Model Field 'Direccion.Departamento'</summary>
                
                public System.String Departamento { get; set; }
                /// <summary>Gets or sets the Direccion field. Derived from Entity Model Field 'Direccion.Direccion'</summary>
                
                public System.String Direccion { get; set; }
                /// <summary>Gets or sets the Municipio field. Derived from Entity Model Field 'Direccion.Municipio'</summary>
                
                public System.String Municipio { get; set; }
                /// <summary>Gets or sets the Pais field. Derived from Entity Model Field 'Direccion.Pais'</summary>
                
                public Pais? Pais { get; set; }
            }
        }

        /// <summary> Document class which is derived from the value-type 'RetencionesAdicionales (RetencionesFacturaEspecial)'.</summary>
        [Serializable]
        
        public partial class RetencionesFacturaEspecial
        {
            /// <summary>Gets or sets the RetencionIsr field. Derived from Entity Model Field 'RetencionesAdicionales.RetencionIsr'</summary>
            
            public System.Decimal RetencionIsr { get; set; }
            /// <summary>Gets or sets the RetencionIva field. Derived from Entity Model Field 'RetencionesAdicionales.RetencionIva'</summary>
            
            public System.Decimal RetencionIva { get; set; }
            /// <summary>Gets or sets the TotalMenosRetenciones field. Derived from Entity Model Field 'RetencionesAdicionales.TotalMenosRetenciones'</summary>
            
            public System.Decimal TotalMenosRetenciones { get; set; }
        }
    }

}