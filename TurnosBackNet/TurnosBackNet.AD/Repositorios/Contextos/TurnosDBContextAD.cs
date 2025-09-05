using Microsoft.EntityFrameworkCore;

namespace TurnosBackNet.AD.Repositorios.Contextos
{

    public partial class TurnosDBContextAD : DbContext
    {
        public readonly string cadenaConexion;

        public TurnosDBContextAD(string cadenaConexion)
        {
            this.cadenaConexion = cadenaConexion;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(cadenaConexion);
        }
    }
}
