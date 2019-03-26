using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Fegora.Servicios.Model;
using System.Net;
using System.Configuration;
using System.Text;
using Fegora.Servicios.Model.DteTypes;
using System.IO;

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
            if (string.IsNullOrEmpty(Host) && ConfigurationManager.AppSettings.HasKeys() && ConfigurationManager.AppSettings[CONFIG_HOST_KEY] != null )
            {
                Host = ConfigurationManager.AppSettings.Get(CONFIG_HOST_KEY);
            }

            if (string.IsNullOrEmpty(ClientId) && ConfigurationManager.AppSettings.HasKeys() && ConfigurationManager.AppSettings[CONFIG_CLIENT_ID_KEY] != null)
            {
                ClientId = ConfigurationManager.AppSettings.Get(CONFIG_CLIENT_ID_KEY);
            }

            if (string.IsNullOrEmpty(ClientSecret) && ConfigurationManager.AppSettings.HasKeys() && ConfigurationManager.AppSettings[CONFIG_CLIENT_SECRET_KEY] != null)
            {
                ClientSecret = ConfigurationManager.AppSettings.Get(CONFIG_CLIENT_SECRET_KEY);
            }

            if (string.IsNullOrEmpty(Username) && ConfigurationManager.AppSettings.HasKeys() && ConfigurationManager.AppSettings[CONFIG_USERNAME_KEY] != null)
            {
                Username = ConfigurationManager.AppSettings.Get(CONFIG_USERNAME_KEY);
            }

            if (string.IsNullOrEmpty(Password) && ConfigurationManager.AppSettings.HasKeys() && ConfigurationManager.AppSettings[CONFIG_PASSWORD_KEY] != null)
            {
                Password = ConfigurationManager.AppSettings.Get(CONFIG_PASSWORD_KEY);
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
                Converters = new List<JsonConverter> { new StringEnumConverter { NamingStrategy = new CamelCaseNamingStrategy(true, false), CamelCaseText = true } }
            };

            // aceptar diferentes procolos de seguridad
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            // inicializar cliente
            InicializarHttpClient();
        }

        private void InicializarHttpClient()
        {
            Client = new HttpClient
            {
                BaseAddress = new Uri(Host)
            };

            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Add("Accept", "application/json");
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
        internal HttpClient Client { get; set; }
        #endregion

        #region Metodos de conexion y Ejecucion generales
        internal RespuestaFegora Conectar()
        {
            var respuestaADevolver = new RespuestaFegora();
            
            // params
            var parameters = new Dictionary<string, string>();            
            parameters.Add("grant_type", "password");
            parameters.Add("username", Username);
            parameters.Add("password", Password);
            parameters.Add("client_id", ClientId);

            // headers
            var request = new HttpRequestMessage(HttpMethod.Post, "token") { Content = new FormUrlEncodedContent(parameters) };
            request.Method = HttpMethod.Post;

            // response
            HttpResponseMessage response = null;
            try
            {
                response = Client.SendAsync(request).Result;
            }
            catch (Exception ex)
            {
                var x = ex.Message;
            }

            var resultAsString = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
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
