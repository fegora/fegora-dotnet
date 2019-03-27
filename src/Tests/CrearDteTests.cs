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
        private Api fegora;

        [TestInitialize]
        public void ConfiguracionTests()
        {
            fegora = new Api();

            // si desea puede incluir los valores en el constructor
            //fegora = new Api(clientId, clientSecret, userName, password);
        }

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
                PrecioUnitario = 1500
            });

            // ejecutar la creacion
            var resp = fegora.Dtes.Crear(dte);

            // tests
            if (resp.TieneError)
            {
                ImprimirError(resp.Error);
            }            
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
            var resp = fegora.Dtes.Crear(dte);

            // tests
            if (resp.TieneError)
            {
                ImprimirError(resp.Error);
            }            
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
            var dteOriginal = fegora.Dtes.Crear(ConstruirDteSencillo()).Contenido;

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
            dteNC.IdDteOriginal = dteOriginal.Id;
            dteNC.MotivoAjuste = "Ajuste de precio por reclamo de servicio";

            // ejecutar la creacion de la nota de credito
            var resp = fegora.Dtes.Crear(dteNC);

            // tests
            if (resp.TieneError)
            {
                ImprimirError(resp.Error);
            }            
            Assert.IsFalse(resp.TieneError);
            Assert.IsNotNull(resp.Contenido);
            Assert.IsNotNull(resp.Contenido.Id);

            // mostrar valores relevantes de impresion
            ImprimirInformacionRelevanteDocumento(resp.Contenido);
        }

        [TestMethod]
        public void ObtenerDTE()
        {
            // crear un DTE
            var dte = fegora.Dtes.Crear(ConstruirDteSencillo()).Contenido;

            // obtener el dte con el metodo especifico para obtencion
            var id = dte.Id;

            // ejecutar la creacion            
            var resp = fegora.Dtes.Obtener(id);

            // tests
            if (resp.TieneError)
            {
                ImprimirError(resp.Error);
            }            
            Assert.IsFalse(resp.TieneError);
            Assert.IsNotNull(resp.Contenido);
            Assert.IsNotNull(resp.Contenido.Id);
            
            // mostrar valores relevantes de impresion
            ImprimirInformacionRelevanteDocumento(resp.Contenido);            
        }

        [TestMethod]
        public void AnularDTE()
        {
            // crear dte sencillo para ser anulado más adelante
            var dte = fegora.Dtes.Crear(ConstruirDteSencillo()).Contenido;
            
            // ejecutar la anulacion
            var resp = fegora.Dtes.Anular(dte.Id, "Montos y NIT errórenos");

            // tests
            if (resp.TieneError)
            {
                ImprimirError(resp.Error);
            }
            Assert.IsFalse(resp.TieneError);
            Assert.IsNotNull(resp.Contenido);
            Assert.IsNotNull(resp.Contenido.Id);
            Assert.IsNotNull(resp.Contenido.DatosAnulacion);

            // mostrar valores relevantes de impresion
            ImprimirInformacionRelevanteDocumento(resp.Contenido);
        }

        private Dte ConstruirDteSencillo()
        {
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
                PrecioUnitario = 1500
            });

            return dte;
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
            foreach (var datoAdicional in dte.DatosAdicionales)
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

        private void ImprimirError(Error error)
        {
            Console.WriteLine("ERROR!");
            Console.WriteLine("-----------------");
            Console.WriteLine("Codigo: {0}", error.Codigo);
            Console.WriteLine("Mensaje: {0}", error.Mensaje);                        
        }


    }
}
