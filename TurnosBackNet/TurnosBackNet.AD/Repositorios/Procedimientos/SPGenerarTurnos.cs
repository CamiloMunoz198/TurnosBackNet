using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TurnosBackNet.AD.Repositorios.Contextos;
using TurnosBackNet.AD.Repositorios.Entidades;
using TurnosBackNet.EN.DTO;

namespace TurnosBackNet.AD.Repositorios.Procedimientos
{
    public class SPGenerarTurnos
    {
        public  async Task<List<CreacionTurnosEN>> EjecutarProcedimiento_SP_GenerarTurnos(TurnosDBContextAD turnosDBContextAD, AgendamientoEN agendamientoEN)
        {
            var resultado = await turnosDBContextAD.Set<CreacionTurnosEN>()
                .FromSqlRaw("EXEC SP_GenerarTurnos @FechaInicio, @FechaFin, @IdServicio",
                    new SqlParameter("@FechaInicio", agendamientoEN.FechaInicio),
                    new SqlParameter("@FechaFin", agendamientoEN.FechaFin),
                    new SqlParameter("@IdServicio", agendamientoEN.IdServicio))
                .ToListAsync();
            return resultado;
        }
    }
}
