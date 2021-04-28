using Fegora.Servicios.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace Fegora.Servicios
{
    public class Session
    {
        #region Variables
        private string _host;
        private readonly string DEFAULT_HOST = "https://api.fegora.com";
        private readonly string CONFIG_HOST_KEY = "Fegora.Servicios.Host";
        private readonly string CONFIG_CLIENT_ID_KEY = "Fegora.Servicios.ClientId";
        private readonly string CONFIG_CLIENT_SECRET_KEY = "Fegora.Servicios.ClientSecret";
        private readonly string CONFIG_USERNAME_KEY = "Fegora.Servicios.Username";
        private readonly string CONFIG_PASSWORD_KEY = "Fegora.Servicios.Password";
        #endregion

        #region Constructores
        public Session()
        {            
            InicializarConfiguracion();
        }        

        public Session(string clientId, string clientSecret, string userName, string password)
        {           
            ClientId = clientId;
            ClientSecret = clientSecret;
            Username = userName;
            Password = password;

            InicializarConfiguracion();
        }

        private void InicializarConfiguracion()
        {
            #region Valores desde config, si existieran y fueran necesarios
            if (string.IsNullOrEmpty(Host) && !string.IsNullOrEmpty(Environment.GetEnvironmentVariable(CONFIG_HOST_KEY)))
            {
                Host = Environment.GetEnvironmentVariable(CONFIG_HOST_KEY);
            }

            if (string.IsNullOrEmpty(ClientId) && !string.IsNullOrEmpty(Environment.GetEnvironmentVariable(CONFIG_CLIENT_ID_KEY)))
            {
                ClientId = Environment.GetEnvironmentVariable(CONFIG_CLIENT_ID_KEY);
            }

            if (string.IsNullOrEmpty(ClientSecret) && !string.IsNullOrEmpty(Environment.GetEnvironmentVariable(CONFIG_CLIENT_SECRET_KEY)))
            {
                ClientSecret = Environment.GetEnvironmentVariable(CONFIG_CLIENT_SECRET_KEY);
            }

            if (string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Environment.GetEnvironmentVariable(CONFIG_USERNAME_KEY)))
            {
                Username = Environment.GetEnvironmentVariable(CONFIG_USERNAME_KEY);
            }

            if (string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(Environment.GetEnvironmentVariable(CONFIG_PASSWORD_KEY)))
            {
                Password = Environment.GetEnvironmentVariable(CONFIG_PASSWORD_KEY);
            }

            if (string.IsNullOrEmpty(Host))
            {
                Host = DEFAULT_HOST;
            }
            #endregion
            
            // posibilidad de hacer las conversiones como camelCase y 
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Newtonsoft.Json.Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                Converters = new List<JsonConverter> { new StringEnumConverter { CamelCaseText = true } }
            };

            // aceptar diferentes procolos de seguridad
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            // inicializar cliente
            InicializarHttpClient();
        }

        private void InicializarHttpClient()
        {
            Client = new RestClient
            {
                BaseUrl = new Uri(Host)
            };
            
            Client.AddDefaultHeader("Accept", "application/json");            
        }          
        #endregion

        #region Propiedades
        public string Host
        {
            get { return _host; }
            set
            {
                _host = value;
                InicializarHttpClient();
            }
        }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
        internal Token Token { get; set ; }
        internal RestClient Client { get; set; }
        #endregion

        #region Metodos de conexion y Ejecucion generales
        internal RespuestaFegora Conectar()
        {
            var respuestaADevolver = new RespuestaFegora();
                        
            // headers
            var request = new RestRequest("token", Method.POST);
            
            request.AddParameter( "grant_type", "password");
            request.AddParameter("username", Username);
            request.AddParameter("password", Password);
            request.AddParameter("client_id", ClientId);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            // response
            IRestResponse response = null;
            try
            {
                response = Client.Execute(request);
            }
            catch (Exception ex)
            {
                var x = ex.Message;
            }

            var resultAsString = response.Content;            
            if (response.StatusCode == HttpStatusCode.OK)
            {                
                Token = JsonConvert.DeserializeObject<Token>(resultAsString);
                respuestaADevolver.TieneError = false;
            }
            else
            {
                var errorToken =  JsonConvert.DeserializeObject<ErrorToken>(resultAsString);
                respuestaADevolver.Error = new Error
                {
                    Mensaje = string.Format("{0}: {1}", errorToken.error, errorToken.error_description)
                };
                respuestaADevolver.TieneError = true;
                Token = null;
            }

            return respuestaADevolver;
        }       
        #endregion
    }
}
