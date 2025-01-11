using Microsoft.EntityFrameworkCore;
using PlanetShoes.Core.Enums;
using PlanetShoes.Infrastructure.Data;
using System;
using System.Collections.Generic;

namespace PlanetShoes.Infrastructure.Context
{
    public class PlanetShoesDbContext : DbContext
    {

        // Construtor padrão (usado no ambiente de produção)
        public PlanetShoesDbContext()
        {
        }

        // Construtor que aceita DbContextOptions<PlanetShoesDbContext> (usado nos testes)
        public PlanetShoesDbContext(DbContextOptions<PlanetShoesDbContext> options)
            : base(options)
        {
        }

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


            //Configuração do relacionamento entre SubEstruturaComPeca e Peca
            modelBuilder.Entity<SubEstruturaComPeca>()
                .HasMany(s => s.Pecas)
                .WithOne()
                .HasForeignKey(p => p.IdEstrutura);


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

            var usuario3 = new Usuario
            {
                UserId = Guid.NewGuid().ToString(), // Gera um novo GUID
                Username = "Gabriel",
                Password = "gabriel123", // Em um cenário real, use um hash de senha!
                Email = "gabriel.oliveira@planetshoes.com",
                DisplayName = "Gabriel Oliveira"
            };

            var usuario4 = new Usuario
            {
                UserId = Guid.NewGuid().ToString(), // Gera um novo GUID
                Username = "Sidney",
                Password = "sidney123", // Em um cenário real, use um hash de senha!
                Email = "sidney.magal@planetshoes.com",
                DisplayName = "Sidney Magal"
            };

            var usuario5 = new Usuario
            {
                UserId = Guid.NewGuid().ToString(), // Gera um novo GUID
                Username = "Wederson",
                Password = "wederson123", // Em um cenário real, use um hash de senha!
                Email = "wederson.ferreira@planetshoes.com",
                DisplayName = "Wederson Ferreira"
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
            // Inserção de estruturas do tipo Acabado
            var acabado1 = new SubEstruturaAcabado
            {
                IdEstrutura = "Estrutura1",
                IdSubEstrutura = "SubEstrutura1",
                Consumo = 10.5f,
                ImgAcabado = new byte[0] // Imagem vazia para exemplo
            };

            var acabado2 = new SubEstruturaAcabado
            {
                IdEstrutura = "Estrutura2",
                IdSubEstrutura = "SubEstrutura2",
                Consumo = 15.0f,
                ImgAcabado = new byte[0] // Imagem vazia para exemplo
            };

            // Inserção de estruturas do tipo Aviamento
            var aviamento1 = new SubEstruturaAviamento
            {
                IdEstrutura = "Estrutura3",
                IdSubEstrutura = "SubEstrutura3",
                Consumo = 5.0f,
                ImgAcabado = new byte[0] // Imagem vazia para exemplo
            };

            var aviamento2 = new SubEstruturaAviamento
            {
                IdEstrutura = "Estrutura4",
                IdSubEstrutura = "SubEstrutura4",
                Consumo = 7.5f,
                ImgAcabado = new byte[0] // Imagem vazia para exemplo
            };

            // Inserção de estruturas do tipo ComPeca (Cabedal)
            var estruturaComPecaCabedal1 = new SubEstruturaComPecaCabedal
            {
                IdEstrutura = "Estrutura5",
                IdSubEstrutura = "SubEstrutura5",
                DesignCabedal = DesignCabedal.Classic,
                EstruturaCabedal = TipoEstruturaCabedal.Couro
            };

            var estruturaComPecaCabedal2 = new SubEstruturaComPecaCabedal
            {
                IdEstrutura = "Estrutura6",
                IdSubEstrutura = "SubEstrutura6",
                DesignCabedal = DesignCabedal.Running,
                EstruturaCabedal = TipoEstruturaCabedal.Sintetico
            };

            // Inserção de estruturas do tipo ComPeca (Solado)
            var estruturaComPecaSolado1 = new SubEstruturaComPecaSolado
            {
                IdEstrutura = "Estrutura7",
                IdSubEstrutura = "SubEstrutura7",
                AlturaSolado = AlturaSolado.Medio,
                DesignSolado = DesignSolado.Gomos,
                EstruturaSolado = TipoEstruturaSolado.Monocomponente
            };

            var estruturaComPecaSolado2 = new SubEstruturaComPecaSolado
            {
                IdEstrutura = "Estrutura8",
                IdSubEstrutura = "SubEstrutura8",
                AlturaSolado = AlturaSolado.Alto,
                DesignSolado = DesignSolado.Tratorado,
                EstruturaSolado = TipoEstruturaSolado.Bicompomentente
            };

            // Inserção de estruturas do tipo ComPeca (genérico)
            var estruturaComPecaGenerica1 = new SubEstruturaComPeca
            {
                IdEstrutura = "Estrutura9",
                IdSubEstrutura = "SubEstrutura9"
            };

            var estruturaComPecaGenerica2 = new SubEstruturaComPeca
            {
                IdEstrutura = "Estrutura10",
                IdSubEstrutura = "SubEstrutura10"
            };

            // Inserção das estruturas no banco de dados
            modelBuilder.Entity<SubEstruturaAcabado>().HasData(acabado1, acabado2);
            modelBuilder.Entity<SubEstruturaAviamento>().HasData(aviamento1, aviamento2);
            modelBuilder.Entity<SubEstruturaComPecaCabedal>().HasData(estruturaComPecaCabedal1, estruturaComPecaCabedal2);
            modelBuilder.Entity<SubEstruturaComPecaSolado>().HasData(estruturaComPecaSolado1, estruturaComPecaSolado2);
            modelBuilder.Entity<SubEstruturaComPeca>().HasData(estruturaComPecaGenerica1, estruturaComPecaGenerica2);
        }

        private void InserePecas(ModelBuilder modelBuilder)
        {
            // Inserção de peças do tipo PecaCabedal
            var pecaCabedal1 = new PecaCabedal
            {
                IdPeca = "PecaCabedal1",
                Agrupamento = AgrupamentoPeca.Um_Para_Um,
                Codigo = 101,
                Consumo = 2.5f,
                Descricao = "Cabedal de couro",
                ImgPeca = new byte[0],
                Nome = "Cabedal 1",
                Tamanho = TamanhoPeca.Tamanho40,
                IdMateriaPrima = "MateriaPrima1",
                NomeModelo = "Empire",
                Perimetro = 50.0f,
                Superficie = 100.0f,
                IdEstrutura = "Estrutura5" // Vincula à estrutura ComPecaCabedal1
            };

            var pecaCabedal2 = new PecaCabedal
            {
                IdPeca = "PecaCabedal2",
                Agrupamento = AgrupamentoPeca.Dois_Para_Um,
                Codigo = 102,
                Consumo = 3.0f,
                Descricao = "Cabedal sintético",
                ImgPeca = new byte[0],
                Nome = "Cabedal 2",
                Tamanho = TamanhoPeca.Tamanho42,
                IdMateriaPrima = "MateriaPrima2",
                NomeModelo = "Modern",
                Perimetro = 55.0f,
                Superficie = 110.0f,
                IdEstrutura = "Estrutura5" // Vincula à estrutura ComPecaCabedal2
            };

            // Inserção de peças do tipo PecaSolado
            var pecaSolado1 = new PecaSolado
            {
                IdPeca = "PecaSolado1",
                Agrupamento = AgrupamentoPeca.Um_Para_Um,
                Codigo = 201,
                Consumo = 1.5f,
                Descricao = "Solado de borracha",
                ImgPeca = new byte[0],
                Nome = "Solado 1",
                Tamanho = TamanhoPeca.Tamanho40,
                IdMateriaPrima = "MateriaPrima2",
                Peso = 0.5f,
                IdEstrutura = "Estrutura5" // Vincula à estrutura ComPecaSolado1
            };

            var pecaSolado2 = new PecaSolado
            {
                IdPeca = "PecaSolado2",
                Agrupamento = AgrupamentoPeca.Dois_Para_Um,
                Codigo = 202,
                Consumo = 2.0f,
                Descricao = "Solado de EVA",
                ImgPeca = new byte[0],
                Nome = "Solado 2",
                Tamanho = TamanhoPeca.Tamanho42,
                IdMateriaPrima = "MateriaPrima1",
                Peso = 0.6f,
                IdEstrutura = "Estrutura8" // Vincula à estrutura ComPecaSolado2
            };

            // Inserção de peças do tipo Peca (genérico)
            var pecaGenerica1 = new Peca
            {
                IdPeca = "PecaGenerica1",
                Agrupamento = AgrupamentoPeca.Um_Para_Um,
                Codigo = 301,
                Consumo = 1.0f,
                Descricao = "Peça genérica 1",
                ImgPeca = new byte[0],
                Nome = "Peça Genérica 1",
                Tamanho = TamanhoPeca.Tamanho40,
                IdMateriaPrima = "MateriaPrima1",
                IdEstrutura = "Estrutura9" // Vincula à estrutura ComPecaGenerica1
            };

            var pecaGenerica2 = new Peca
            {
                IdPeca = "PecaGenerica2",
                Agrupamento = AgrupamentoPeca.Dois_Para_Um,
                Codigo = 302,
                Consumo = 1.5f,
                Descricao = "Peça genérica 2",
                ImgPeca = new byte[0],
                Nome = "Peça Genérica 2",
                Tamanho = TamanhoPeca.Tamanho42,
                IdMateriaPrima = "MateriaPrima2",
                IdEstrutura = "Estrutura10" // Vincula à estrutura ComPecaGenerica2
            };

            // Inserção das peças no banco de dados
            modelBuilder.Entity<PecaCabedal>().HasData(pecaCabedal1, pecaCabedal2);
            modelBuilder.Entity<PecaSolado>().HasData(pecaSolado1, pecaSolado2);
            modelBuilder.Entity<Peca>().HasData(pecaGenerica1, pecaGenerica2);
        }
    }
}