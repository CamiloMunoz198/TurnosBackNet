using TurnosBackNet.SV.Servicios;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TurnosBackNet.EN.DTO;

namespace TurnosBackNet.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnosController : TurnoSV
    {
        public TurnosController(IConfiguration configuration, IHostEnvironment environment) : base(configuration, environment) {
            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
        }
        // GET: TurnosController
        [HttpPost("GenerarTurnos")]
        public override async Task<IActionResult> GenerarTurnosSV(AgendamientoEN agendamientoEN)
            => await base.GenerarTurnosSV(agendamientoEN);
    }
}
