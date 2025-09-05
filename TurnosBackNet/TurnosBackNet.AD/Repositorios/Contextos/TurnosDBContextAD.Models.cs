using Microsoft.EntityFrameworkCore;
using TurnosBackNet.AD.Repositorios.Entidades;
using TurnosBackNet.EN.DTO;


namespace TurnosBackNet.AD.Repositorios.Contextos
{
    public partial class TurnosDBContextAD : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Servicios>(entity =>
            {
                entity.HasKey(e => e.IdServicio).HasName("PK_servicios");

                entity.HasOne(d => d.IdComercioNavigation).WithMany(p => p.Servicios).HasConstraintName("FK_Servicios_Comercios");
            });

            modelBuilder.Entity<Turnos>(entity =>
            {
                entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.Turnos).HasConstraintName("FK_Turnos_Servicios");
            });

            modelBuilder.Entity<CreacionTurnosEN>().HasNoKey().ToView(null);
        }
    }
}
