using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fegora.Servicios.Tests
{
    [TestClass]
    public class ContribuyenteTests
    {
        private Api fegora;

        [TestInitialize]
        public void ConfiguracionTests()
        {
            fegora = new Api();
        }

        [TestMethod]
        public void ObtenerContribuyenteTest()
        {
            var resp = fegora.Contribuyentes.Obtener("27456935");
            Console.WriteLine(resp.Contenido.Nombre);
        }
    }
}
