using Microsoft.EntityFrameworkCore;

namespace PlanetShoes.Infrastructure.Data
{
    public class PlanetShoesDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;" +
                                        "Database=PlanetShoesDb;" +
                                        "Integrated Security=True;" +
                                        "Connect Timeout=30;" +
                                        "Encrypt=True;" +
                                        "Trust Server Certificate=True;" +
                                        "Application Intent=ReadWrite;" +
                                        "Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Insere os usuários iniciais
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    UserId = Guid.NewGuid().ToString(),
                    Username = "Inacio",
                    Password = "inacio", // Em um cenário real, use um hash de senha!
                    Email = "inacio.felipe@planetshoes.com",
                    DisplayName = "Inacio Felipe Couto Ferreira"
                },
                new Usuario
                {
                    UserId = Guid.NewGuid().ToString(),
                    Username = "Luciano",
                    Password = "luciano", // Em um cenário real, use um hash de senha!
                    Email = "luciano.ferreira@planetshoes.com",
                    DisplayName = "Luciano Antônio Ferreira"
                }
            );
        }

    }
}
  