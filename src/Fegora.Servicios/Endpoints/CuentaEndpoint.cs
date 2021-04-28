using Fegora.Servicios.Model;
using Fegora.Utils;
using Newtonsoft.Json;
using RestSharp;

namespace Fegora.Servicios
{
    public class CuentaEndpoint : EndpointBase
    {
        public CuentaEndpoint(Session session) : base(session)
        {
        }

        public RespuestaFegora<Cuenta> Crear(Cuenta cuenta)
        {
            // resource
            var request = new RestRequest("cuenta", Method.POST);

            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = NewtonsoftJsonSerializer.Default;

            // params            
            request.AddJsonBody(cuenta);

            // response
            return Ejecutar<Cuenta>(request);
        }

        public RespuestaFegora<Cuenta> Obtener(string id)
        {
            // resource
            var request = new RestRequest(string.Format("cuenta/{0}", id), Method.GET);
            request.AddHeader("Accept", "application/json");

            // response
            return Ejecutar<Cuenta>(request);
        }

        public RespuestaFegora<Cuenta> ActualizarParcial(Cuenta cuenta)
        {
            // resource
            var request = new RestRequest(string.Format("cuenta/{0}", cuenta.Id), Method.PATCH);

            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = NewtonsoftJsonSerializer.Default;

            // params            
            request.AddJsonBody(cuenta);

            // response
            return Ejecutar<Cuenta>(request);
        }
    }
}
