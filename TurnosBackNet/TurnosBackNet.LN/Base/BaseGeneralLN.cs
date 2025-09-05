using TurnoBackNet.LN.Modelos;
using TurnoBackNet.LN.Utilidades;


namespace TurnoBackNet.LN.Base
{
    public class BaseGeneralLN
    {
        public readonly RespuestasLN respuestas;
        protected readonly AccesoDatosLN accesoDatos;
        public BaseGeneralLN()
        {
            respuestas = new RespuestasLN();
            accesoDatos = new AccesoDatosLN();
        }
    }
}
