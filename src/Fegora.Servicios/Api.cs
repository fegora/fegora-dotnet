namespace Fegora.Servicios
{
    public class Api
    {
        public Api() : this(string.Empty, string.Empty, string.Empty, string.Empty)
        {
        }

        public Api(string clientId, string clientSecret, string userName, string password)
        {
            Session = new Session(clientId, clientSecret, userName, password);
            Dtes = new DteEndpoint(Session);
            Contribuyentes = new ContribuyenteEndpoint(Session);
        }

        public Session Session {get; set;}
        
        public DteEndpoint Dtes { get; set; }

        public ContribuyenteEndpoint Contribuyentes { get; set; }
    }
}
