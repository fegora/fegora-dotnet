using Fegora.Servicios.Model;
using Fegora.Servicios.Model.DteTypes;
using Fegora.Utils;
using Newtonsoft.Json;
using RestSharp;
using System;

namespace Fegora.Servicios
{
    public class DteEndpoint : EndpointBase
    {
        public DteEndpoint(Session session) : base(session)
        {
        }

        public RespuestaFegora<Dte> Crear(Dte dte)
        {
            // resource
            var request = new RestRequest("dte", Method.POST);

            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = NewtonsoftJsonSerializer.Default;

            // params            
            request.AddJsonBody(dte);

            //request.AddHeader("Accept", "application/json");
            //request.AddHeader("Content-Type", "application/json");

            // response
            return Ejecutar<Dte>(request);
        }

        public RespuestaFegora<Dte> Obtener(string id)
        {
            // resource
            var request = new RestRequest(string.Format("dte/{0}", id), Method.GET);
            request.AddHeader("Accept", "application/json");

            // response
            return Ejecutar<Dte>(request);
        }

        public RespuestaFegora<Dte> Anular(string id, string motivoAnulacion)
        {
            // construir datos dte para anulacion
            var dte = new Dte();
            dte.Id = id;
            dte.Anulado = true;
            dte.DatosAnulacion = new DatosAnulacion();
            dte.DatosAnulacion.MotivoAnulacion = motivoAnulacion;

            //// resource
            var request = new RestRequest("dte", Method.PATCH);
            request.AddHeader("Accept", "application/json");

            //// params
            var json = JsonConvert.SerializeObject(dte);
            request.AddJsonBody(dte);                  

            // response
            return Ejecutar<Dte>(request);
        }
    }
}
