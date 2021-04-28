﻿using Fegora.Servicios.Model;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace Fegora.Servicios
{
    public class EndpointBase
    {
        protected Session _session;
        public EndpointBase(Session session)
        {
            _session = session;
        }

        protected virtual RespuestaFegora<T> Ejecutar<T>(IRestRequest request) where T : new()
        {
            return Ejecutar<T>(request, true);
        }

        protected virtual RespuestaFegora<T> Ejecutar<T>(IRestRequest request, bool forzarReconexion) where T : new()
        {
            var respFegora = new RespuestaFegora<T>();

            #region Autenticacion
            if (_session.Token == null)
            {
                var respConexion = _session.Conectar();
                if (respConexion.TieneError)
                {
                    respFegora.TieneError = true;
                    respFegora.Error = respConexion.Error;
                    respFegora.Contenido = default(T);

                    return respFegora;
                }
            }
            request.AddHeader("Authorization", "Bearer " + _session.Token.access_token);
            #endregion

            var response = _session.Client.Execute(request);
            var resultAsString = response.Content;

            // respuesta correcta
            if (response.StatusCode == HttpStatusCode.OK)
            {
                respFegora.TieneError = false;
                respFegora.Contenido = JsonConvert.DeserializeObject<T>(resultAsString);
                respFegora.Error = new Error();
            }
            // error de autenticacion
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                respFegora.TieneError = true;
                respFegora.Error = new Error()
                {
                    Mensaje = "Error de autenticaión"
                };

                // intentar renovar token
                if (forzarReconexion)
                {
                    _session.Conectar();
                    respFegora = Ejecutar<T>(request, false);
                }
            }
            // algún otro error proveniente del api
            else
            {
                respFegora.TieneError = true;
                respFegora.Error = JsonConvert.DeserializeObject<Error>(resultAsString);
                respFegora.Contenido = new T();
            }

            return respFegora;
        }
    }
}
