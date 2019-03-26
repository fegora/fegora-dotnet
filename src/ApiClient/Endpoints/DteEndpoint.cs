using Fegora.Servicios.Model;
using Fegora.Servicios.Model.DteTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Fegora.Servicios
{
    public class DteEndpoint : EndpointBase
    {
        public DteEndpoint(Session session) : base(session)
        {
        }

        public RespuestaFegora<Dte> Crear(Dte dte)
        {
            var aDevolver = new RespuestaFegora<Dte>();

            // resource
            var request = new HttpRequestMessage(HttpMethod.Post, "dte");

            // params
            var json = JsonConvert.SerializeObject(dte);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            request.Content = content;

            // response
            return Ejecutar<Dte>(request);
        }

        public RespuestaFegora<Dte> Obtener(string id)
        {
            var aDevolver = new RespuestaFegora<Dte>();

            // resource
            var request = new HttpRequestMessage(HttpMethod.Get, string.Format("dte/{0}", id));

            // response
            return Ejecutar<Dte>(request);
        }

        public RespuestaFegora<Dte> Anular(string id, string motivoAnulacion)
        {
            var aDevolver = new RespuestaFegora<Dte>();

            // construir datos dte para anulacion
            var dte = new Dte();
            dte.Id = id;
            dte.Anulado = true;
            dte.DatosAnulacion = new DatosAnulacion();
            dte.DatosAnulacion.MotivoAnulacion = motivoAnulacion;

            // resource
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), "dte");

            // params
            var json = JsonConvert.SerializeObject(dte);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            request.Content = content;

            // response
            return Ejecutar<Dte>(request);
        }
    }
}
