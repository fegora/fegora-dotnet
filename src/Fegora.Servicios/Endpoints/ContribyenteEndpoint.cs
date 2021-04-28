using Fegora.Servicios.Model;
using Fegora.Servicios.Model.DteTypes;
using Fegora.Utils;
using Newtonsoft.Json;
using RestSharp;

namespace Fegora.Servicios
{
    public class ContribuyenteEndpoint : EndpointBase
    {
        public ContribuyenteEndpoint(Session session) : base(session)
        {
        }

        public RespuestaFegora<Contribuyente> Obtener(string id)
        {
            // resource
            var request = new RestRequest(string.Format("contribuyente/{0}", id), Method.GET);
            request.AddHeader("Accept", "application/json");

            // response
            return Ejecutar<Contribuyente>(request);
        }
    }
}
