using Microsoft.EntityFrameworkCore;
using NET___BioSentinela.Domain.Entities;
using NET___BioSentinela.Infrastructure.Mapping;

namespace NET___BioSentinela.Infrastructure.Context
{
    public class BioContext(DbContextOptions<BioContext> options) : DbContext(options)
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Regiao> Regiao { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<Alerta> Alerta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            modelBuilder.ApplyConfiguration(new RegiaoMapping());
            modelBuilder.ApplyConfiguration(new AlertaMApping());
            modelBuilder.ApplyConfiguration(new SensorMapping());
        }


    }
}