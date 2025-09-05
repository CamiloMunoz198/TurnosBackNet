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

        public async Task CargarServiciosLN(ConsultaComercioEN comercioEN)
        {
            // Lógica para crear un pedido
            try
            {
                using (TurnosDBContextAD TurnoDBContextAD = accesoDatos.ObtenerCadenaTurnos(configuration, environment))
                {
                    try
                    {
                        var Servicios = TurnoDBContextAD.Servicios.Where(t => t.IdComercio == comercioEN.IdComercio)
                            .AsNoTracking()
                            .OrderBy(t => t.IdServicio)
                            .Include(c => c.IdComercioNavigation)

                            .Select(p => new
                            {
                                p.IdServicio,
                                p.NomServicio,
                                p.HoraApertura,
                                p.HoraCierre,
                                p.Duracion,
                                p.IdComercio,
                                NomComercio = p.IdComercioNavigation != null ? p.IdComercioNavigation.NomComercio : "Nombre de Comercio Desconocido",
                                AforoMaximo = p.IdComercioNavigation != null ? p.IdComercioNavigation.AforoMaximo : 0
                            })
                            .ToList();


                        if (Servicios.Any())
                        {
                            respuestas.Respuesta.Add("Servicios", Servicios);
                        }
                        else
                        {
                            respuestas.NoEncontrado("No se pudieron consultar los  Servicios para el Comercio solicitado");
                        }
                    }
                    catch (Exception ex)
                    {
                        respuestas.Fallido($"Error Al Generar y Consultar los Servicios En DB.{ex.Message}");
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
