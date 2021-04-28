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

        public RespuestaFegora<ListadoPaginado<Dte>> Obtener(string idCuenta = null, TipoDte? tipo = null, string idReceptor = null,
            bool? enAmbienteDePruebas = null, DateTime? desde = null, DateTime? hasta = null, bool? anulados = null,
            byte? numeroPagina = null, byte? tamanioPagina = null, string numeroTransaccion = null)
        {
            // resource
            var request = new RestRequest("dte/", Method.GET);
            request.AddHeader("Accept", "application/json");

            #region filtros

            // idCuenta
            if (!string.IsNullOrEmpty(idCuenta))
            {
                request.AddQueryParameter("idCuenta", idCuenta);
            }

            // tipo
            if (tipo.HasValue)
            {
                request.AddQueryParameter("tipo", tipo.Value.ToString());
            }

            // idReceptor
            if (!string.IsNullOrEmpty(idReceptor))
            {
                request.AddQueryParameter("idReceptor", idReceptor);
            }

            // tipo
            if (enAmbienteDePruebas.HasValue)
            {
                request.AddQueryParameter("enAmbienteDePruebas", enAmbienteDePruebas.Value.ToString());
            }

            // desde
            if (desde.HasValue)
            {
                request.AddQueryParameter("desde", desde.Value.ToString("yyyy-MM-HHTmm:ss"));
            }

            // hasta
            if (hasta.HasValue)
            {
                request.AddQueryParameter("hasta", hasta.Value.ToString("yyyy-MM-HHTmm:ss"));
            }

            // anulados
            if (anulados.HasValue)
            {
                request.AddQueryParameter("anulados", anulados.Value.ToString());
            }

            // numeroPagina
            if (numeroPagina.HasValue)
            {
                request.AddQueryParameter("numPag", numeroPagina.Value.ToString());
            }

            // numeroPagina
            if (tamanioPagina.HasValue)
            {
                request.AddQueryParameter("tamPag", tamanioPagina.Value.ToString());
            }

            // numeroTransaccion
            if (!string.IsNullOrEmpty(numeroTransaccion))
            {
                request.AddQueryParameter("numeroTransaccion", numeroTransaccion);
            }
            #endregion

            // response
            return Ejecutar<ListadoPaginado<Dte>>(request);
        }

        public RespuestaFegora<Dte> Anular(string id, string motivoAnulacion)
        {
            // construir datos dte para anulacion
            var dte = new Dte();
            dte.Id = id;
            dte.Anulado = true;
            dte.DatosAnulacion = new DatosAnulacion();
            dte.DatosAnulacion.MotivoAnulacion = motivoAnulacion;

            // resource
            var request = new RestRequest("dte", Method.PATCH);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");

            // params
            var json = JsonConvert.SerializeObject(dte);
            request.AddJsonBody(json);            

            // response
            return Ejecutar<Dte>(request);
        }
    }
}
