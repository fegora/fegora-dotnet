using System;
using Fegora.Servicios.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fegora.Servicios.Tests
{
    [TestClass]
    public class CuentaTests
    {
        private Api fegora;

        [TestInitialize]
        public void ConfiguracionTests()
        {
            // si no usas el constructor con valores, son tomados de tu archivo de configuracion
            //fegora = new Api();

            // si desea puede incluir los valores en el constructor
            var clientId = "";
            var clientSecret = "";
            var userName = "";
            var password = "";
            fegora = new Api(clientId, clientSecret, userName, password);
        }

        [TestMethod]
        public void ObtenerCuenta()
        {
            var id = "43430775";
            var resp = fegora.Cuentas.Obtener(id);

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

        private void ImprimirInformacionRelevanteDocumento(Cuenta cuenta)
        {
            Console.WriteLine("Info Cuenta");
            Console.WriteLine("------------------");
            Console.WriteLine("ID: {0}", cuenta.Id);
            Console.WriteLine("Nombre: {0}", cuenta.InformacionFiscal.Nombre);
            Console.WriteLine("Datos Adicionales");
            foreach (var da in cuenta.DatosAdicionales)
            {
                Console.WriteLine("\t{0} : {1}", da.Nombre, da.Valor);
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
