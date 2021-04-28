using System;
using System.Collections.Generic;
using Fegora.Servicios.Model;
using Fegora.Servicios.Model.DteTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fegora.Servicios.Tests
{
    [TestClass]
    public class ObtenerDteTests
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
        public void ObtenerDTE()
        {
            // obtener el dte con el metodo especifico para obtencion
            var id = "232E50FB-340B-4AD4-AABF-205E92741784";

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
        public void ObtenerDTEPorNumeroTransaccion()
        {
            // obtener el dte con el metodo especifico para obtencion
            var numTrans = "123XYZMPL";

            // ejecutar la creacion            
            var resp = fegora.Dtes.Obtener(numeroTransaccion: numTrans);

            // tests
            if (resp.TieneError)
            {
                ImprimirError(resp.Error);
            }
            Assert.IsFalse(resp.TieneError);
            Assert.IsNotNull(resp.Contenido);
            Assert.IsTrue(resp.Contenido.Data.Count == 1);

            // mostrar valores relevantes de impresion
            ImprimirInformacionRelevanteDocumentos(resp.Contenido.Data);
        }

        [TestMethod]
        public void ObtenerDTEPorNumeroTransaccionInexistente()
        {
            // obtener el dte con el metodo especifico para obtencion
            var numTrans = "111111.11111";

            // ejecutar la creacion            
            var resp = fegora.Dtes.Obtener(numeroTransaccion: numTrans);

            // tests
            if (resp.TieneError)
            {
                ImprimirError(resp.Error);
            }
            Assert.IsFalse(resp.TieneError);
            Assert.IsNotNull(resp.Contenido);
            Assert.IsTrue(resp.Contenido.Data.Count == 0);

            // mostrar valores relevantes de impresion
            ImprimirInformacionRelevanteDocumentos(resp.Contenido.Data);
        }

        private void ImprimirInformacionRelevanteDocumentos(List<Dte> dtes)
        {
            Console.WriteLine("Documentos encontrados: {0}", dtes.Count);
            Console.WriteLine("=======================================");
            Console.WriteLine();

            foreach (var dte in dtes)
            {
                ImprimirInformacionRelevanteDocumento(dte);
            }
        }

        private void ImprimirInformacionRelevanteDocumento(Dte dte)
        {
            Console.WriteLine("ID: {0}\tTipo: {1}", dte.Tipo, dte.Id);
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
