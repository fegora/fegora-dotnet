using System;
using System.Collections.Generic;
using Fegora.Servicios.Model;
using Fegora.Servicios.Model.DteTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fegora.Servicios.Tests
{
    [TestClass]
    public class CrearDteTests
    {
        [TestMethod]
        public void CrearDteSimple()
        {
            // construir el DTE
            var dte = new Dte();
            dte.Receptor = new Receptor()
            {
                Id = "CF",
                Nombre = "Distribuidora XYZ",
                Direccion = new DireccionEntidad()
                {
                    Direccion = "2a CALLE 3-51 ZONA 9 GUATEMALA",
                    Departamento = "Guatemala",
                    Municipio = "Guatemala",
                    Pais = Pais.GT,
                    CodigoPostal = "01009"
                }
            };

            dte.Items = new List<Item>();
            dte.Items.Add(new Item()
            {
                Descripcion = "Bocina BX-456",
                PrecioUnitario = 450
            });

            // ejecutar la creacion
            var fegora = new Api();
            var resp = fegora.Dtes.Crear(dte);

            // tests
            Assert.IsFalse(resp.TieneError);
            Assert.IsNotNull(resp.Contenido);
            Assert.IsNotNull(resp.Contenido.Id);

            // mostrar valores relevantes de impresion
            ImprimirInformacionRelevanteDocumento(resp.Contenido);            
        }

        [TestMethod]
        public void CrearDteServicio()
        {
            // construir el DTE
            var dte = new Dte();
            dte.Receptor = new Receptor()
            {
                Id = "CF",
                Nombre = "Distribuidora XYZ",
                Direccion = new DireccionEntidad()
                {
                    Direccion = "2a CALLE 3-51 ZONA 9 GUATEMALA",
                    Departamento = "Guatemala",
                    Municipio = "Guatemala",
                    Pais = Pais.GT,
                    CodigoPostal = "01009"
                }
            };

            dte.Items = new List<Item>();
            dte.Items.Add(new Item()
            {
                Descripcion = "Reaparacion y mantenimiento general de vehículo",
                PrecioUnitario = 1500,
                Tipo = TipoItem.Servicio
            });

            // ejecutar la creacion
            var fegora = new Api();
            var resp = fegora.Dtes.Crear(dte);

            Assert.IsFalse(resp.TieneError);
            Assert.IsNotNull(resp.Contenido);
            Assert.IsNotNull(resp.Contenido.Id);

            // mostrar valores relevantes de impresion
            ImprimirInformacionRelevanteDocumento(resp.Contenido);
        }

        [TestMethod]
        public void CrearNotaCredito()
        {
            // construir el DTE original
            var dteOriginal = new Dte();
            dteOriginal.Receptor = new Receptor()
            {
                Id = "CF",
                Nombre = "Distribuidora XYZ",
                Direccion = new DireccionEntidad()
                {
                    Direccion = "2a CALLE 3-51 ZONA 9 GUATEMALA",
                    Departamento = "Guatemala",
                    Municipio = "Guatemala",
                    Pais = Pais.GT,
                    CodigoPostal = "01009"
                }
            };

            dteOriginal.Items = new List<Item>();
            dteOriginal.Items.Add(new Item()
            {
                Descripcion = "Reaparacion y mantenimiento general de vehículo",
                PrecioUnitario = 1500,
                Tipo = TipoItem.Servicio
            });

            // ejecutar la creacion
            var fegora = new Api();
            var resp = fegora.Dtes.Crear(dteOriginal);
            Assert.IsFalse(resp.TieneError);
            Assert.IsNotNull(resp.Contenido);
            Assert.IsNotNull(resp.Contenido.Id);

            // construir la nota de credito
            var dteNC = new Dte();
            dteNC.Receptor = new Receptor()
            {
                Id = "CF",
                Nombre = "Distribuidora XYZ",
                Direccion = new DireccionEntidad()
                {
                    Direccion = "2a CALLE 3-51 ZONA 9 GUATEMALA",
                    Departamento = "Guatemala",
                    Municipio = "Guatemala",
                    Pais = Pais.GT,
                    CodigoPostal = "01009"
                }
            };

            dteNC.Items = new List<Item>();
            dteNC.Items.Add(new Item()
            {
                Descripcion = "Reaparacion y mantenimiento general de vehículo",
                PrecioUnitario = 500,
                Tipo = TipoItem.Servicio
            });

            // datos indispensables para una Nota de credito: el tipo, el documentoOriginal y el motivo del ajuste
            dteNC.Tipo = TipoDte.NotaCredito;
            dteNC.IdDteOriginal = resp.Contenido.Id;
            dteNC.MotivoAjuste = "Ajuste de precio por reclamo de servicio";

            var respNC = fegora.Dtes.Crear(dteNC);

            Assert.IsFalse(respNC.TieneError);
            Assert.IsNotNull(respNC.Contenido);
            Assert.IsNotNull(respNC.Contenido.Id);

            // mostrar valores relevantes de impresion
            ImprimirInformacionRelevanteDocumento(respNC.Contenido);
        }

        [TestMethod]
        public void ObtenerDTE()
        {
            // crear un DTE
            var dte = new Dte();
            dte.Receptor = new Receptor()
            {
                Id = "CF",
                Nombre = "Distribuidora XYZ",
                Direccion = new DireccionEntidad()
                {
                    Direccion = "2a CALLE 3-51 ZONA 9 GUATEMALA",
                    Departamento = "Guatemala",
                    Municipio = "Guatemala",
                    Pais = Pais.GT,
                    CodigoPostal = "01009"
                }
            };

            dte.Items = new List<Item>();
            dte.Items.Add(new Item()
            {
                Descripcion = "Audifonos con cancelación de sonido BX-456",
                PrecioUnitario = 450
            });

            // ejecutar la creacion
            var fegora = new Api();
            var resp = fegora.Dtes.Crear(dte);

            // obtener el dte con el metodo especifico para obtencion
            var id = resp.Contenido.Id;

            // ejecutar la creacion            
            var respObtener = fegora.Dtes.Obtener(id);

            Assert.IsFalse(respObtener.TieneError);
            Assert.IsNotNull(respObtener.Contenido);
            Assert.IsNotNull(respObtener.Contenido.Id);
            
            // mostrar valores relevantes de impresion
            ImprimirInformacionRelevanteDocumento(resp.Contenido);
        }

        [TestMethod]
        public void AnularDTE()
        {
            var fegora = new Api();
            var motivoAnulacion = "Montos y NIT errórenos.";

            #region crear un DTE nuevo para la prueba de anulacion
            var dte = new Dte();
            dte.Receptor = new Receptor()
            {
                Id = "CF",
                Nombre = "Distribuidora XYZ",
                Direccion = new DireccionEntidad()
                {
                    Direccion = "2a CALLE 3-51 ZONA 9 GUATEMALA",
                    Departamento = "Guatemala",
                    Municipio = "Guatemala",
                    Pais = Pais.GT,
                    CodigoPostal = "01009"
                }
            };

            dte.Items = new List<Item>();
            dte.Items.Add(new Item()
            {
                Descripcion = "Audifonos con cancelación de sonido BX-456",
                PrecioUnitario = 450
            });

            // ejecutar la creacion            
            var resp = fegora.Dtes.Crear(dte);
            #endregion

            // id del documento creado, que se usará para la prueba de anulación
            var id = resp.Contenido.Id;

            // ejecutar la anulacion
            var respAnulacion = fegora.Dtes.Anular(id, motivoAnulacion);

            Assert.IsFalse(respAnulacion.TieneError);
            Assert.IsNotNull(respAnulacion.Contenido);
            Assert.IsNotNull(respAnulacion.Contenido.Id);
            Assert.IsNotNull(respAnulacion.Contenido.DatosAnulacion);

            // mostrar valores relevantes de impresion
            ImprimirInformacionRelevanteDocumento(respAnulacion.Contenido);
        }

        private void ImprimirInformacionRelevanteDocumento(Dte dte)
        {
            Console.WriteLine("Documento creado");
            Console.WriteLine("------------------");
            Console.WriteLine("Tipo: {0}", dte.Tipo);
            Console.WriteLine("ID: {0}", dte.Id);
            Console.WriteLine("Serie: {0}", dte.Serie);
            Console.WriteLine("Numero: {0}", dte.Numero);
            Console.WriteLine("Archivo XML URI: {0}", dte.ArchivoXmlUri);
            Console.WriteLine();
            Console.WriteLine("Datos adicionales");
            Console.WriteLine("------------------");
            foreach (var datoAdicional in dte.DatoAdicionales)
            {
                Console.WriteLine("{0} ({1}) : {2}", datoAdicional.Nombre, datoAdicional.Visible.Value ? "visible" : "no visible", datoAdicional.Valor);
            }

            if (dte.DatosAnulacion != null)
            {
                Console.WriteLine();
                Console.WriteLine("Datos de Anulacion");
                Console.WriteLine("------------------");
                {
                    Console.WriteLine("ArchivoXmlUri (anulacion): {0}", dte.DatosAnulacion.ArchivoXmlUri);
                    Console.WriteLine("Fecha (anulacion): {0}", dte.DatosAnulacion.FechaAnulacion);
                    Console.WriteLine("Motivo (anulacion): {0}", dte.DatosAnulacion.MotivoAnulacion);
                }

            }
        }
    }
}
