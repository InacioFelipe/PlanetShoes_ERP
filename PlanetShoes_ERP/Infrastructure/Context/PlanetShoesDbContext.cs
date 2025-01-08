using Microsoft.EntityFrameworkCore;
using PlanetShoes.Core.Enums;
using PlanetShoes.Infrastructure.Data;
using System;
using System.Collections.Generic;

namespace PlanetShoes.Infrastructure.Context
{
    public class PlanetShoesDbContext : DbContext
    {
        // DbSets para cada entidade
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Estrutura> Estruturas { get; set; }
        public DbSet<SubEstruturaAcabado> SubEstruturasAcabado { get; set; }
        public DbSet<SubEstruturaAviamento> SubEstruturasAviamento { get; set; }
        public DbSet<SubEstruturaComPeca> SubEstruturasComPeca { get; set; }
        public DbSet<SubEstruturaComPecaSolado> SubEstruturasComPecaSolado { get; set; }
        public DbSet<SubEstruturaComPecaCabedal> SubEstruturasComPecaCabedal { get; set; }
        public DbSet<Peca> Pecas { get; set; }
        public DbSet<PecaSolado> PecasSolado { get; set; }
        public DbSet<PecaCabedal> PecasCabedal { get; set; }
        public DbSet<MateriaPrima> MateriasPrimas { get; set; }

        // Configuração da conexão com o banco de dados
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=localhost\\SQLEXPRESS;" +
                "Database=PlanetShoesDb;" +
                "Integrated Security=True;" +
                "Connect Timeout=30;" +
                "Encrypt=True;" +
                "Trust Server Certificate=True;" +
                "Application Intent=ReadWrite;" +
                "Multi Subnet Failover=False"
            )
            .EnableSensitiveDataLogging(); // Habilita logging detalhado
        }

        // Configuração do modelo de dados
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração da hierarquia de Estrutura (TPH - Table-per-Hierarchy)
            modelBuilder.Entity<Estrutura>()
                .HasDiscriminator<string>("TipoEstrutura")
                .HasValue<SubEstruturaAcabado>("Acabado")
                .HasValue<SubEstruturaAviamento>("Aviamento")
                .HasValue<SubEstruturaComPeca>("ComPeca")
                .HasValue<SubEstruturaComPecaSolado>("ComPecaSolado")
                .HasValue<SubEstruturaComPecaCabedal>("ComPecaCabedal");


            // Inserção de dados iniciais
            InsereUsuarios(modelBuilder);
            InsereMateriaPrima(modelBuilder);
            InsereEstruturas(modelBuilder);
            InserePecas(modelBuilder);
        }


        private void InsereUsuarios(ModelBuilder modelBuilder)
        {
            //---------------------------------------------
            // Criar Usuários (entidades independentes)
            //---------------------------------------------

            var usuario1 = new Usuario
            {
                UserId = "9d340277-2ced-4037-84f4-c6fc2cba5579", //Guid.NewGuid().ToString(),
                Username = "Inacio",
                Password = "inacio", // Em um cenário real, use um hash de senha!
                Email = "inacio.felipe@planetshoes.com",
                DisplayName = "Inacio Felipe Couto Ferreira"
            };

            var usuario2 = new Usuario
            {
                UserId = "f9921ce6-ff36-4757-b3be-a7c7e53c45a2", //Guid.NewGuid().ToString(),
                Username = "Luciano",
                Password = "luciano", // Em um cenário real, use um hash de senha!
                Email = "luciano.ferreira@planetshoes.com",
                DisplayName = "Luciano Antônio Ferreira"
            };

            modelBuilder.Entity<Usuario>().HasData(usuario1, usuario2);

        }

        private void InsereMateriaPrima(ModelBuilder modelBuilder)
        {
            var materiaPrima1 = new MateriaPrima
            {
                IdMateriaPrima = "MateriaPrima1",
                Nome = "Couro Bovino",
                Classe = "Natural",
                Descricao = "Couro de alta qualidade",
                UnidadeMedida = UnidadeDeMedida.Metro,
                Valor = 100.00m
            };

            var materiaPrima2 = new MateriaPrima
            {
                IdMateriaPrima = "MateriaPrima2",
                Nome = "Borracha Sintética",
                Classe = "Sintético",
                Descricao = "Borracha para solados",
                UnidadeMedida = UnidadeDeMedida.Quilograma,
                Valor = 50.00m
            };

            modelBuilder.Entity<MateriaPrima>().HasData(materiaPrima1, materiaPrima2);
        }

        private void InsereEstruturas(ModelBuilder modelBuilder)
        {
            //---------------------------------------------
            // Criar Estruturas e Subestruturas com valores fixos
            //---------------------------------------------

            // Estrutura base
            var estrutura1 = new Estrutura
            {
                IdEstrutura = "Estrutura0", // Valor fixo
                IdSubEstrutura = "SubEstrutura0" // Valor fixo
            };

            // Subestrutura Acabado
            var subEstruturaAcabado1 = new SubEstruturaAcabado
            {
                IdEstrutura = "Estrutura1", // Relacionamento com Estrutura (valor fixo)
                IdSubEstrutura = "SubEstrutura1", // Valor fixo
                Consumo = 10.5f, // Valor fixo
                ImgAcabado = new byte[0] // Imagem vazia para exemplo
            };

            // Subestrutura Aviamento
            var subEstruturaAviamento1 = new SubEstruturaAviamento
            {
                IdEstrutura = "Estrutura2", // Valor fixo
                IdSubEstrutura = "SubEstrutura2", // Valor fixo
                Consumo = 5.0f, // Valor fixo
                ImgAcabado = new byte[0] // Imagem vazia para exemplo
            };

            // Subestrutura com Peça (Solado)
            var subEstruturaComPecaSolado1 = new SubEstruturaComPecaSolado
            {
                IdEstrutura = "Estrutura3", // Valor fixo
                IdSubEstrutura = "SubEstrutura3", // Valor fixo
                AlturaSolado = AlturaSolado.Medio, // Valor fixo
                DesignSolado = DesignSolado.Gomos, // Valor fixo
                EstruturaSolado = TipoEstruturaSolado.Monocomponente // Valor fixo
            };

            // Subestrutura com Peça (Cabedal)
            var subEstruturaComPecaCabedal1 = new SubEstruturaComPecaCabedal
            {
                IdEstrutura = "Estrutura4", // Valor fixo
                IdSubEstrutura = "SubEstrutura4", // Valor fixo
                DesignCabedal = DesignCabedal.Classic, // Valor fixo
                EstruturaCabedal = TipoEstruturaCabedal.Couro // Valor fixo
            };

            // Inserção no banco de dados

            modelBuilder.Entity<Estrutura>().HasData(estrutura1);
            modelBuilder.Entity<SubEstruturaAcabado>().HasData(subEstruturaAcabado1);
            modelBuilder.Entity<SubEstruturaAviamento>().HasData(subEstruturaAviamento1);
            modelBuilder.Entity<SubEstruturaComPecaSolado>().HasData(subEstruturaComPecaSolado1);
            modelBuilder.Entity<SubEstruturaComPecaCabedal>().HasData(subEstruturaComPecaCabedal1);
        }

        private void InserePecas(ModelBuilder modelBuilder)
        {
            var pecaSolado1 = new PecaSolado
            {
                IdPeca = "IdPeca1",
                Agrupamento = AgrupamentoPeca.Um_Para_Um,
                Codigo = 101,
                Consumo = 2.5f,
                Descricao = "Solado de borracha",
                ImgPeca = new byte[0],
                Nome = "Solado 1",
                Tamanho = TamanhoPeca.Tamanho40,
                IdMateriaPrima = "MateriaPrima2", // Relacionamento com Matéria-Prima
            };

            var pecaCabedal1 = new PecaCabedal
            {
                IdPeca = "IdPeca2",
                Agrupamento = AgrupamentoPeca.Dois_Para_Um,
                Codigo = 201,
                Consumo = 1.0f,
                Descricao = "Cabedal de couro",
                ImgPeca = new byte[0],
                Nome = "Cabedal 1",
                NomeModelo = "Empire",
                Tamanho = TamanhoPeca.Tamanho42,
                IdMateriaPrima = "MateriaPrima1", // Relacionamento com Matéria-Prima
            };

            modelBuilder.Entity<PecaSolado>().HasData(pecaSolado1);
            modelBuilder.Entity<PecaCabedal>().HasData(pecaCabedal1);
        }
    }
}