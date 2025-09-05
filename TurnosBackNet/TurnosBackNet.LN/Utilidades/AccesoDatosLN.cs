using TurnosBackNet.AD.Repositorios.Contextos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace TurnoBackNet.LN.Utilidades
{
    public class AccesoDatosLN
    {
        //Configuracion de cadena de conexion para entorno desarrollo y produccion
        public TurnosDBContextAD ObtenerCadenaTurnos(IConfiguration configuration, IHostEnvironment environtment)
        {
            return environtment.IsDevelopment() ? new TurnosDBContextAD(configuration.GetConnectionString("ConexionSQLTurnosDBDev")) : new TurnosDBContextAD(configuration.GetConnectionString("ConexionSQLTurnosDBProd"));
        }
    }
}
