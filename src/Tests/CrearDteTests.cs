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
                PrecioUnitario = 1
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
        public void CredencialesInvalidas()
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
                PrecioUnitario = 1
            });

            // ejecutar la creacion
            fegora = new Api("apiApp", "", "43430775", "BadPass");
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
        public void InformacionDteInvalida()
        {
            // construir el DTE
            var dte = new Dte();
            dte.Receptor = new Receptor()
            {
                Id = "111111",
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
                PrecioUnitario = 1
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
        public void CrearDteCheckDuplicidad()
        {
            // construir el DTE
            var dte1 = ConstruirDteSencillo();

            // este campo permite hacer el chequeo de dupllicidad. Utiliza un campo de tu sistema
            // que sea único por factura, como el número de orden, por ejemplo
            var numeroDeOrden = new Random().Next(1, 10000000);
            dte1.NumeroTransaccion = numeroDeOrden;

            // ejecutar la creacion
            var resp1 = fegora.Dtes.Crear(dte1);

            // tests
            Console.WriteLine("Resultados de DTE-1");
            if (resp1.TieneError)
            {
                ImprimirError(resp1.Error);
            }
            Assert.IsFalse(resp1.TieneError);
            Assert.IsNotNull(resp1.Contenido);
            Assert.IsNotNull(resp1.Contenido.Id);

            // mostrar valores relevantes de impresion            
            ImprimirInformacionRelevanteDocumento(resp1.Contenido);

            // segundo documento, que simula una duplicidad, que debería ser manejada por el api
            // en vez de crear un nuevo documento, se devuelve el documento original. Esto lo comprobaremos
            // al comparar el UUID original (dte1) y el nuevo (dte2). Deberían ser iguales, en cuanto hacen referencia
            // al mismo numeroTransaccion

            var dte2 = ConstruirDteSencillo();
            dte2.NumeroTransaccion = numeroDeOrden;
            
            // ejecutar la creacion
            var resp2 = fegora.Dtes.Crear(dte1);

            // tests
            Console.WriteLine("Resultados de DTE-2");
            if (resp2.TieneError)
            {
                ImprimirError(resp2.Error);
            }
            Assert.IsFalse(resp2.TieneError);
            Assert.IsNotNull(resp2.Contenido);
            Assert.IsNotNull(resp2.Contenido.Id);

            // test principal: debe ser el mismo documento que dte1.
            Assert.AreEqual(dte1.Id, dte2.Id);

            // mostrar valores relevantes de impresion            
            ImprimirInformacionRelevanteDocumento(resp1.Contenido);
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
        public void CrearNotaCreditoFace()
        {            
            // construir la nota de credito
            var dteNC = new Dte();
            dteNC.Receptor = new Receptor()
            {
                Id = "CF",
                Nombre = "Consumidor Final",
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
                Descripcion = "Negociacion de Descuento",
                PrecioUnitario = 5,
                Tipo = TipoItem.Servicio
            });

            // datos generales de la nota de credito. No se debe incluir el 
            // campo idDteOriginal, ya que no lo hay pues es FACE. 
            dteNC.Tipo = TipoDte.NotaCredito;
            dteNC.MotivoAjuste = "Negociacion de descuento";

            // datos de documento FACE. Debe incluir todos los datos e indicar
            // que es regimen antiguo.
            dteNC.DteOriginal = new DteOriginal();
            dteNC.DteOriginal.EsRegimenAntiguo = true;
            dteNC.DteOriginal.Id = "2019-1-61-1084644";
            dteNC.DteOriginal.Serie = "A1";
            dteNC.DteOriginal.FechaEmision = new DateTime(2019, 9, 30);
            dteNC.DteOriginal.Numero = 1007749;
            
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
