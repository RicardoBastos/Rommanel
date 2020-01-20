using Microsoft.EntityFrameworkCore;
using Usuario.Infrastructure.Mapping;

namespace Usuario.Infrastructure
{
    public class UsuarioContext : DbContext
    {
        public UsuarioContext(DbContextOptions options) : base(options) =>
            Database.EnsureCreated();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
        }

        public DbSet<Usuario.Domain.Entities.Usuario> Usuario { get; set; }

    }

}
