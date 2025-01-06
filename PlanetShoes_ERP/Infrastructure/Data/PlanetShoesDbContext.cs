using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;

namespace PlanetShoes.Infrastructure.Data
{
    public class PlanetShoesDbContext : DbContext
    {
        public DbSet<MateriaPrima> MateriasPrimas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Peca> Pecas { get; set; }
        public DbSet<PecaDeCabedal> PecasCabedal { get; set; }

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
            //modelBuilder.Entity<MateriaPrima>().HasKey(m => m.IdMateriaPrima); // Define a chave primária
            //modelBuilder.Entity<MateriaPrima>().Property(m => m.IdMateriaPrima).ValueGeneratedOnAdd(); // Configura o ID para ser gerado automaticamente

            //// Configura o relacionamento muitos-para-muitos entre Peca e MateriaPrima
            //modelBuilder.Entity<Peca>()
            //    .HasMany(p => p.MateriasPrimas)
            //    .WithMany()
            //    .UsingEntity(j => j.ToTable("PecaMateriaPrima"));

            //// Configura o relacionamento muitos-para-muitos entre Peca e ProcessoProdutivo
            //modelBuilder.Entity<Peca>()
            //    .HasMany(p => p.ProcessosProdutivos)
            //    .WithMany()
            //    .UsingEntity(j => j.ToTable("PecaProcessoProdutivo"));


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

//using Microsoft.EntityFrameworkCore;
//using PlanetShoes.Infrastructure.Data;
//using System;

//namespace PlanetShoes.Infrastructure
//{
//    public class PlanetShoesDbContext : DbContext
//    {
//        // DbSets para as entidades
//        public DbSet<Usuario> Usuarios { get; set; }
//        public DbSet<MateriaPrima> MateriasPrimas { get; set; }
//        public DbSet<Peca> Pecas { get; set; }
//        public DbSet<PecaDeCabedal> PecasCabedal { get; set; }
//        public DbSet<ProcessoProdutivo> ProcessosProdutivos { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            // Configuração da conexão com o banco de dados
//            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;" +
//                                        "Database=PlanetShoesDb;" +
//                                        "Integrated Security=True;" +
//                                        "Connect Timeout=30;" +
//                                        "Encrypt=True;" +
//                                        "Trust Server Certificate=True;" +
//                                        "Application Intent=ReadWrite;" +
//                                        "Multi Subnet Failover=False");
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            base.OnModelCreating(modelBuilder);

//            // Configuração da hierarquia de herança TPH para Peca e PecaDeCabedal
//            modelBuilder.Entity<Peca>()
//                .HasDiscriminator<string>("TipoPeca")
//                .HasValue<Peca>("PecaBase")
//                .HasValue<PecaDeCabedal>("PecaDeCabedal");

//            // Configuração das propriedades específicas de PecaDeCabedal
//            modelBuilder.Entity<PecaDeCabedal>()
//                .Property(p => p.Tamanho)
//                .HasColumnName("Tamanho");

//            // Configuração das chaves primárias e geração automática de IDs
//            modelBuilder.Entity<MateriaPrima>()
//                .HasKey(m => m.IdMateriaPrima);

//            modelBuilder.Entity<MateriaPrima>()
//                .Property(m => m.IdMateriaPrima)
//                .ValueGeneratedOnAdd();

//            modelBuilder.Entity<Peca>()
//                .HasKey(p => p.IdPeca);

//            modelBuilder.Entity<PecaDeCabedal>()
//                .HasKey(p => p.IdPeca);

//            modelBuilder.Entity<ProcessoProdutivo>()
//                .HasKey(p => p.IdProcessoProdutivo);

//            modelBuilder.Entity<Usuario>()
//                .HasKey(u => u.UserId);

//            //// Inserção de dados iniciais (usuários)
//            //modelBuilder.Entity<Usuario>().HasData(
//            //    new Usuario
//            //    {
//            //        UserId = "9d340277-2ced-4037-84f4-c6fc2cba5579",
//            //        Username = "Inacio",
//            //        Password = "inacio", // Em um cenário real, use um hash de senha!
//            //        Email = "inacio.felipe@planetshoes.com",
//            //        DisplayName = "Inacio Felipe Couto Ferreira"
//            //    },
//            //    new Usuario
//            //    {
//            //        UserId = "f9921ce6-ff36-4757-b3be-a7c7e53c45a2",
//            //        Username = "Luciano",
//            //        Password = "luciano", // Em um cenário real, use um hash de senha!
//            //        Email = "luciano.ferreira@planetshoes.com",
//            //        DisplayName = "Luciano Antônio Ferreira"
//            //    }
//            //);
//        }
//    }
//}
