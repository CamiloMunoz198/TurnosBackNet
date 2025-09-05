using TurnoBackNet.LN.Base;
using TurnosBackNet.AD.Repositorios.Contextos;
using TurnosBackNet.AD.Repositorios.Entidades;
using TurnosBackNet.EN.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using TurnosBackNet.AD.Repositorios.Procedimientos;

namespace TurnoBackNet.LN.Logica
{
    public class TurnoLN : BaseGeneralLN
    {
        private readonly IConfiguration configuration;
        private readonly IHostEnvironment environment;
        public TurnoLN(IConfiguration configuration, IHostEnvironment environment)
        {
            this.configuration = configuration;
            this.environment = environment;
        }

        public async Task GenerarTurnosLN(AgendamientoEN agendamientoEN)
        {
            // Lógica para crear un pedido
            try
            {
                using (TurnosDBContextAD TurnoDBContextAD = accesoDatos.ObtenerCadenaTurnos(configuration, environment))
                {
                    try
                    {
                        SPGenerarTurnos generaTurnosAD = new SPGenerarTurnos();
                        var Turnos = await generaTurnosAD.EjecutarProcedimiento_SP_GenerarTurnos(TurnoDBContextAD, agendamientoEN);


                        if (Turnos.Any())
                        {
                            respuestas.Respuesta.Add("Turnos", Turnos);
                        }
                        else
                        {
                            respuestas.NoEncontrado("No se pudieron generaron Turnos para el servicio solicitado");
                        }
                    }
                    catch (Exception ex)
                    {
                        respuestas.Fallido($"Error Al Generar y Consultar Turnos En DB.{ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                respuestas.Error500($"Error al consultar Turno en ConsultarTurnoLN:{ex.Message}");
            }
        }
    }
}
