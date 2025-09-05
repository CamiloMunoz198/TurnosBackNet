using TurnosBackNet.AD.Repositorios.Entidades;
using Microsoft.EntityFrameworkCore;

namespace TurnosBackNet.AD.Repositorios.Contextos
{
    public partial class TurnosDBContextAD: DbContext
    {
        public virtual DbSet<Comercios> Comercios { get; set; }

        public virtual DbSet<Servicios> Servicios { get; set; }

        public virtual DbSet<Turnos> Turnos { get; set; }
    }
}
