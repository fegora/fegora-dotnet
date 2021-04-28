using Fegora.Servicios.Model;

namespace Fegora.Servicios
{
    public class RespuestaFegora<T>
    {
        public bool TieneError { get; set; }
        public T Contenido { get; set; }
        public Error Error { get; set; }
    }

    public class RespuestaFegora
    {
        public bool TieneError { get; set; }
        public Error Error { get; set; }
    }
}