using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;

namespace PlanetShoes.Infrastructure.Data
{
    public class PlanetShoesDbContext : DbContext
    {
        public DbSet<MateriaPrima> MateriasPrimas { get; set; }
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

            // Configurações de entidades (se necessário)
            modelBuilder.Entity<MateriaPrima>().HasKey(m => m.IdMateriaPrima); // Define a chave primária
            modelBuilder.Entity<MateriaPrima>().Property(m => m.IdMateriaPrima).ValueGeneratedOnAdd(); // Configura o ID para ser gerado automaticamente

            //Insere os usuários iniciais
            modelBuilder.Entity<Usuario>().HasData(
            new Usuario
            {
                    UserId = "9d340277-2ced-4037-84f4-c6fc2cba5579", //Guid.NewGuid().ToString(),
                    Username = "Inacio",
                    Password = "inacio", // Em um cenário real, use um hash de senha!
                    Email = "inacio.felipe@planetshoes.com",
                    DisplayName = "Inacio Felipe Couto Ferreira"
                },
                new Usuario
                {
                    UserId = "f9921ce6-ff36-4757-b3be-a7c7e53c45a2", //Guid.NewGuid().ToString(),
                    Username = "Luciano",
                    Password = "luciano", // Em um cenário real, use um hash de senha!
                    Email = "luciano.ferreira@planetshoes.com",
                    DisplayName = "Luciano Antônio Ferreira"
                }
            );
        }

    }
}
  