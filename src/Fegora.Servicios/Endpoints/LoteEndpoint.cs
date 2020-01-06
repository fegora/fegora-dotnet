using Fegora.Servicios.Model;
using Fegora.Utils;
using Newtonsoft.Json;
using RestSharp;

namespace Fegora.Servicios
{
    public class LoteEndpoint : EndpointBase
    {
        public LoteEndpoint(Session session) : base(session)
        {
        }

        public RespuestaFegora<Lote> Crear(Lote lote)
        {
            // resource
            var request = new RestRequest("lote", Method.POST);

            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = NewtonsoftJsonSerializer.Default;

            // params            
            request.AddJsonBody(lote);
            
            // response
            return Ejecutar<Lote>(request);
        }

        public RespuestaFegora<Lote> Obtener(string id)
        {
            // resource
            var request = new RestRequest(string.Format("lote/{0}", id), Method.GET);
            request.AddHeader("Accept", "application/json");

            // response
            return Ejecutar<Lote>(request);
        }

        public RespuestaFegora<Lote> ActualizarParcial(Lote lote)
        {
            // resource
            var request = new RestRequest(string.Format("lote/{0}", lote.Id), Method.PATCH);

            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = NewtonsoftJsonSerializer.Default;

            // params            
            request.AddJsonBody(lote);

            // response
            return Ejecutar<Lote>(request);
        }
    }
}
