using TurnoBackNet.LN.Logica;
using TurnosBackNet.EN.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace TurnosBackNet.SV.Servicios
{
    public class TurnoSV(IConfiguration configuration, IHostEnvironment environment) : ControllerBase
    {
        private readonly IConfiguration configuration = configuration;
        private readonly IHostEnvironment environment = environment;
        private TurnoLN? TurnoLN;

        public virtual async Task<IActionResult> GenerarTurnosSV(AgendamientoEN agendamientoEN)
        {
            try
            {
                TurnoLN = new TurnoLN(configuration, environment);
                await TurnoLN.GenerarTurnosLN(agendamientoEN);
                return StatusCode(TurnoLN.respuestas.Estado, TurnoLN.respuestas);
            }
            catch (Exception ex)
            {
                //Agregar un log de error aquí si es necesario con mensajes más detallados por correo
                return StatusCode(500, new Dictionary<string, object>() { { "Mensaje", $"Error al consultar el metodo GenerarTurnosSV:{ex.Message}" } });
            }
        }
    }
}
