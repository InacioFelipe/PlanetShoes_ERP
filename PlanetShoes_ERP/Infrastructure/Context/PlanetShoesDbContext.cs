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

        // Criação de Chaves para os Ids de Cabedais de Producao
        private string TraditionIdEstrutura = "01D87D95-6249-4498-9DDA-A02DC6E42289";
        private string TraditionIdSubEstrutura = "F6E11985-8E4E-48E4-B2CC-D465D000346E";

        private string NewStoneIdEstrutura = "A035415C-2E66-488C-B71A-ABFDC01C563B";
        private string NewStoneIdSybEstrutura = "706DB229-FBDE-4DC8-809F-4438A04466C2";

        private string Winner7070IdEstrutura = "E8239707-2A14-4E06-AA4C-58ED9A42EFB9";
        private string Winner7070IdSubEstrutura = "4BA8CDC6-E596-428D-85AC-59407F2C2F87";

        private string JupiterInfIdEstrutura = "29FBB68A-5082-4DA0-B0A9-C7CCA1F74863";
        private string JupiterInfIdSubEstrutura ="58888D1E-ACB8-4C21-ADAE-4FA045BDABC2";

        private string OrionInfIdEstrutura = "82B642A3-49E5-44E1-BF4C-6DB5A5D32E2E";
        private string OrionInfIdSubEstrutura ="64DDEF39-2D7F-4536-9384-EF38A3BCAF64";

        private string VintageIdEstrutura = "5B26036A-093A-4281-B7F9-2FC8E279BA9B";
        private string VintageIdSubEstrutura = "614D36C0-BB73-4A47-81DC-53CA4E84EABF";

        private string IcaroIdEstrutura = "70C8D67F-8389-4A0F-B562-B65755BF5F2D";
        private string IcaroIdSubEstrutura = "E866DA20-6D2C-4DB8-8CAE-87E0583E0976";

        private string EmmaIdEstrutura = "B7DCEF23-1A4D-4107-8E09-5D77C4C7D672";
        private string EmmaIdSubEstrutura = "9DE1CFEF-3CC5-41D7-899A-CB6CFA9E097D";

        private string RockIdEstrutura = "D98C37D8-EBA7-4C56-8C2D-D1F09900968D";
        private string RockIdSubEstrutura = "50606EB5-86C1-40CA-A6A1-820E050DE4BA";

        private string IvyIdEstrutura = "6A041E67-E930-4C90-A5B5-4E6FFFDD9B4D";
        private string IvyIdSubEstrutura = "0776F178-C54A-4510-9071-B3BCD8949294";

        private string LosAngelesCanoBaixoIdEstrutura = "EF8F52BD-03C8-431B-8BBF-53E312E667CE";
        private string LosAngelesCanoBaixoIdSubEstrutura = "84EB0992-FF2B-4C17-AD84-884B5396C26C";

        private string MayaFrequenciaIdEstrutura = "8DBD4389-489A-420E-951D-8E10692C66C7";
        private string MayaFrequenciaIdSubEstrutura = "BBC0A289-83D4-4021-AF66-E8137C9AD0FE";

        private string EmpireIdEstrutura = "890A6467-11F0-4F24-AB71-1DA78E7557DC";
        private string EmpireIdSubEstrutura = "4EDDBF84-E910-45D9-9F5A-1D438A4C6079";

        private string PegasusIdEstrutura = "4FCC9FBE-2E74-49EE-894B-CD0218DEE4FC";
        private string PegasusIdSubEstrutura = "731C10FA-2FE5-46FC-AAB3-EF9C698AFCE5";

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


            // Inserção de dados Teste
            InsereUsuarios(modelBuilder);
            InsereMateriaPrima(modelBuilder);
            InsereEstruturas(modelBuilder);
            InserePecas(modelBuilder);

            // Insere Dados Producao
            InsereCabedaisProducao(modelBuilder);
            InserePecasTradition(modelBuilder);
        }


        // Dados para insercao
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
                Password = "gabriel", // Em um cenário real, use um hash de senha!
                Email = "gabriel.oliveira@planetshoes.com",
                DisplayName = "Gabriel Oliveira"
            };

            var usuario4 = new Usuario
            {
                UserId = Guid.NewGuid().ToString(), // Gera um novo GUID
                Username = "Sidney",
                Password = "sidney", // Em um cenário real, use um hash de senha!
                Email = "sidney.magal@planetshoes.com",
                DisplayName = "Sidney Magal"
            };

            var usuario5 = new Usuario
            {
                UserId = Guid.NewGuid().ToString(), // Gera um novo GUID
                Username = "Wederson",
                Password = "wederson", // Em um cenário real, use um hash de senha!
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
                EstruturaCabedal = TipoEstruturaCabedal.Curvin
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

        private void InsereCabedaisProducao(ModelBuilder modelBuilder)
        {
            var Tradition = new SubEstruturaComPecaCabedal
            {
                IdEstrutura = TraditionIdEstrutura,
                IdSubEstrutura = TraditionIdSubEstrutura,
                NomeEstrutura="Tradition",
                DesignCabedal = DesignCabedal.Classic,
                EstruturaCabedal = TipoEstruturaCabedal.Lona
            };
            var NewStone7010 = new SubEstruturaComPecaCabedal
            {
                IdEstrutura = NewStoneIdEstrutura,
                IdSubEstrutura = NewStoneIdSybEstrutura,
                NomeEstrutura="New Stone 7010",
                DesignCabedal = DesignCabedal.Classic,
                EstruturaCabedal = TipoEstruturaCabedal.Curvin
            };
            var Winner7070 = new SubEstruturaComPecaCabedal
            {
                IdEstrutura = Winner7070IdEstrutura,
                IdSubEstrutura = Winner7070IdSubEstrutura,
                NomeEstrutura = "Winner 7010",
                DesignCabedal = DesignCabedal.Classic,
                EstruturaCabedal = TipoEstruturaCabedal.Curvin
            };
            var JupiterInf = new SubEstruturaComPecaCabedal
            {
                IdEstrutura = JupiterInfIdEstrutura,
                IdSubEstrutura = JupiterInfIdSubEstrutura,
                NomeEstrutura = "Jupter infanatil",
                DesignCabedal = DesignCabedal.Running,
                EstruturaCabedal = TipoEstruturaCabedal.Nylon
            };
            var OrionInf = new SubEstruturaComPecaCabedal
            {
                IdEstrutura = OrionInfIdEstrutura,
                IdSubEstrutura = OrionInfIdSubEstrutura,
                NomeEstrutura = "Orion infantil",
                DesignCabedal = DesignCabedal.Running,
                EstruturaCabedal = TipoEstruturaCabedal.Nylon
            };
            var Vintage = new SubEstruturaComPecaCabedal
            {
                IdEstrutura = VintageIdEstrutura,
                IdSubEstrutura = VintageIdSubEstrutura,
                NomeEstrutura = "Vintage",
                DesignCabedal = DesignCabedal.Running,
                EstruturaCabedal = TipoEstruturaCabedal.Nylon
            };
            var Icaro = new SubEstruturaComPecaCabedal
            {
                IdEstrutura = IcaroIdEstrutura,
                IdSubEstrutura = IcaroIdSubEstrutura,
                NomeEstrutura = "Icaro",
                DesignCabedal = DesignCabedal.Running,
                EstruturaCabedal = TipoEstruturaCabedal.Nylon
            };
            var Emma = new SubEstruturaComPecaCabedal
            {
                IdEstrutura = EmmaIdEstrutura,
                IdSubEstrutura = EmmaIdSubEstrutura,
                NomeEstrutura = "Emma",
                DesignCabedal = DesignCabedal.Running,
                EstruturaCabedal = TipoEstruturaCabedal.Curvin
            };
            var Rock = new SubEstruturaComPecaCabedal
            {
                IdEstrutura = RockIdEstrutura,
                IdSubEstrutura = RockIdSubEstrutura,
                NomeEstrutura = "Rock",
                DesignCabedal = DesignCabedal.Running,
                EstruturaCabedal = TipoEstruturaCabedal.Curvin
            };
            var Ivy = new SubEstruturaComPecaCabedal
            {
                IdEstrutura = IvyIdEstrutura,
                IdSubEstrutura = IvyIdSubEstrutura,
                NomeEstrutura = "Ivy",
                DesignCabedal = DesignCabedal.Running,
                EstruturaCabedal = TipoEstruturaCabedal.Curvin
            };
            var LosAngelesCanoBaixo = new SubEstruturaComPecaCabedal
            {
                IdEstrutura = LosAngelesCanoBaixoIdEstrutura,
                IdSubEstrutura = LosAngelesCanoBaixoIdSubEstrutura,
                NomeEstrutura = "Los Angeles Cano Baixo",
                DesignCabedal = DesignCabedal.Running,
                EstruturaCabedal = TipoEstruturaCabedal.Lona
            };
            var MayaFrequencia = new SubEstruturaComPecaCabedal
            {
                IdEstrutura = MayaFrequenciaIdEstrutura,
                IdSubEstrutura = MayaFrequenciaIdSubEstrutura,
                NomeEstrutura = "Maya Frequencia",
                DesignCabedal = DesignCabedal.Running,
                EstruturaCabedal = TipoEstruturaCabedal.Nylon
            };
            var Empire = new SubEstruturaComPecaCabedal
            {
                IdEstrutura = EmpireIdEstrutura,
                IdSubEstrutura = EmpireIdSubEstrutura,
                NomeEstrutura = "Empire",
                DesignCabedal = DesignCabedal.Running,
                EstruturaCabedal = TipoEstruturaCabedal.Nylon
            };
            var Pegasus = new SubEstruturaComPecaCabedal
            {
                IdEstrutura = PegasusIdEstrutura,
                IdSubEstrutura = PegasusIdSubEstrutura,
                NomeEstrutura = "Pegasus",
                DesignCabedal = DesignCabedal.Running,
                EstruturaCabedal = TipoEstruturaCabedal.Nylon
            };

            //Inserção das estruturas no banco de dados
            modelBuilder.Entity<SubEstruturaComPecaCabedal>().HasData(
                Tradition, NewStone7010, Winner7070,
                JupiterInf, OrionInf, Vintage, Icaro, Emma,
                Rock, Ivy, LosAngelesCanoBaixo, MayaFrequencia,
                Empire, Pegasus);
        }

        private void InserePecasTradition(ModelBuilder modelBuilder)
        {
            // Inserção de peças
            var Lateral = new PecaCabedal
            {
                IdPeca = "786E20A8-C63B-4DDB-82F7-77746E608F6E",
                Agrupamento = AgrupamentoPeca.Um_Para_Um,
                Codigo = 649,
                Consumo = 2.5f,
                Descricao = "",
                ImgPeca = new byte[0],
                Nome = "Lateral",
                Tamanho = TamanhoPeca.Tamanho39,
                IdMateriaPrima = "649",
                IdEstrutura = TraditionIdEstrutura,
                NomeModelo = "Tradition",
                //Perimetro = 50.0f,
                //Superficie = 100.0f,
                //Data = DateTime.Now.Date,
                //Hora = DateTime.Now.TimeOfDay,
            };


            var Frente = new PecaCabedal
            {
                IdPeca = "E5F4B02A-7C69-469A-86FF-C6E552643373",
                Agrupamento = AgrupamentoPeca.Um_Para_Um,
                Codigo = 649,
                Consumo = 2.5f,
                Descricao = "",
                ImgPeca = new byte[0],
                Nome = "Frente",
                Tamanho = TamanhoPeca.Tamanho39,
                IdMateriaPrima = "649",
                IdEstrutura = TraditionIdEstrutura,
                NomeModelo = "Tradition",
                //Perimetro = 50.0f,
                //Superficie = 100.0f,
                //Data = DateTime.Now.Date,
                //Hora = DateTime.Now.TimeOfDay,
            };

            var Lingua = new PecaCabedal
            {
                IdPeca = "7D820DD4-F558-423C-804C-4AC12F9491C0",
                Agrupamento = AgrupamentoPeca.Um_Para_Um,
                Codigo = 649,
                Consumo = 2.5f,
                Descricao = "",
                ImgPeca = new byte[0],
                Nome = "Lingua",
                Tamanho = TamanhoPeca.Tamanho39,
                IdMateriaPrima = "649",
                IdEstrutura = TraditionIdEstrutura,
                NomeModelo = "Tradition",
                //Perimetro = 50.0f,
                //Superficie = 100.0f,
                //Data = DateTime.Now.Date,
                //Hora = DateTime.Now.TimeOfDay,
            };

            var ContraForte = new PecaCabedal
            {
                IdPeca = "1B183DD2-3629-44E1-A135-1CF173A960CB",
                Agrupamento = AgrupamentoPeca.Um_Para_Um,
                Codigo = 649,
                Consumo = 2.5f,
                Descricao = "",
                ImgPeca = new byte[0],
                Nome = "ContraForte",
                Tamanho = TamanhoPeca.Tamanho39,
                IdMateriaPrima = "649",
                IdEstrutura = TraditionIdEstrutura,
                NomeModelo = "Tradition",
                //Perimetro = 50.0f,
                //Superficie = 100.0f,
                //Data = DateTime.Now.Date,
                //Hora = DateTime.Now.TimeOfDay,
            };
            var Estrutura = new PecaCabedal
            {
                IdPeca = "D370D1C3-E7C5-40AB-9E99-634D564088FD",
                Agrupamento = AgrupamentoPeca.Um_Para_Um,
                Codigo = 620,
                Consumo = 2.5f,
                Descricao = "",
                ImgPeca = new byte[0],
                Nome = "Estrutura",
                Tamanho = TamanhoPeca.Tamanho39,
                IdMateriaPrima = "620",
                IdEstrutura = TraditionIdEstrutura,
                NomeModelo = "Tradition",
                //Perimetro = 50.0f,
                //Superficie = 100.0f,
                //Data = DateTime.Now.Date,
                //Hora = DateTime.Now.TimeOfDay,
            };
            var ReforçoTesourinha = new PecaCabedal
            {
                IdPeca = "940C7C4A-632A-4728-877B-89863C2BF36F",
                Agrupamento = AgrupamentoPeca.Um_Para_Um,
                Codigo = 649,
                Consumo = 2.5f,
                Descricao = "",
                ImgPeca = new byte[0],
                Nome = "Regorço Tesourinha",
                Tamanho = TamanhoPeca.Tamanho39,
                IdMateriaPrima = "649",
                IdEstrutura = TraditionIdEstrutura,
                NomeModelo = "Tradition",
                //Perimetro = 50.0f,
                //Superficie = 100.0f,
                //Data = DateTime.Now.Date,
                //Hora = DateTime.Now.TimeOfDay,
            };
            var Tubox = new PecaCabedal
            {

                IdPeca = "238DEEE8-ACDB-43E3-B468-FE2EB0D4A2CD",
                Agrupamento = AgrupamentoPeca.Um_Para_Um,
                Codigo = 617,
                Consumo = 2.5f,
                Descricao = "",
                ImgPeca = new byte[0],
                Nome = "Tubox",
                Tamanho = TamanhoPeca.Tamanho39,
                IdMateriaPrima = "617",
                IdEstrutura = TraditionIdEstrutura,
                NomeModelo = "Tradition",
                //Perimetro = 50.0f,
                //Superficie = 100.0f,
                //Data = DateTime.Now.Date,
                //Hora = DateTime.Now.TimeOfDay,
            };
            var PalmilhaAcabamento = new PecaCabedal
            {
                IdPeca = "D23A4A71-53CF-45EA-88E4-FDAEDF03158B",
                Agrupamento = AgrupamentoPeca.Um_Para_Um,
                Codigo = 478,
                Consumo = 2.5f,
                Descricao = "",
                ImgPeca = new byte[0],
                Nome = "Palmilha Acabamento",
                Tamanho = TamanhoPeca.Tamanho39,
                IdMateriaPrima = "478",
                IdEstrutura = TraditionIdEstrutura,
                NomeModelo = "Tradition",
                //Perimetro = 50.0f,
                //Superficie = 100.0f,
                //Data = DateTime.Now.Date,
                //Hora = DateTime.Now.TimeOfDay,
            };
            var PalmilhaMontagem = new PecaCabedal
            {
                IdPeca = "BE2E37D0-01CF-4C58-A9CE-2612571B8A9A",
                Agrupamento = AgrupamentoPeca.Um_Para_Um,
                Codigo = 313,
                Consumo = 2.5f,
                Descricao = "",
                ImgPeca = new byte[0],
                Nome = "Palmilha Montagem",
                Tamanho = TamanhoPeca.Tamanho39,
                IdMateriaPrima = "313",
                IdEstrutura = TraditionIdEstrutura,
                NomeModelo = "Tradition",
                //Perimetro = 50.0f,
                //Superficie = 100.0f,
                //Data = DateTime.Now.Date,
                //Hora = DateTime.Now.TimeOfDay,
            };
            var CunhoPalmilha = new PecaCabedal
            {
                IdPeca = "A3150C99-045A-4EA9-8583-866233CE1F18",
                Agrupamento = AgrupamentoPeca.Um_Para_Um,
                Codigo = 421,
                Consumo = 2.5f,
                Descricao = "",
                ImgPeca = new byte[0],
                Nome = "Cunho Palmilha",
                Tamanho = TamanhoPeca.Tamanho39,
                IdMateriaPrima = "421",
                IdEstrutura = TraditionIdEstrutura,
                NomeModelo = "Tradition",
                //Perimetro = 50.0f,
                //Superficie = 100.0f,
                //Data = DateTime.Now.Date,
                //Hora = DateTime.Now.TimeOfDay,
            };
            var Ilhos = new PecaCabedal
            {
                IdPeca = "81598CCB-AEE0-4448-9106-8226BC54E2AE",
                Agrupamento = AgrupamentoPeca.Um_Para_Um,
                Codigo = 23,
                Consumo = 2.5f,
                Descricao = "",
                ImgPeca = new byte[0],
                Nome = "Ilhos",
                Tamanho = TamanhoPeca.Tamanho39,
                IdMateriaPrima = "23",
                IdEstrutura = TraditionIdEstrutura,
                NomeModelo = "Tradition",
                //Perimetro = 50.0f,
                //Superficie = 100.0f,
                //Data = DateTime.Now.Date,
                //Hora = DateTime.Now.TimeOfDay,
            };
            var ColaPesponto = new PecaCabedal
            {
                IdPeca = "1D39D7E3-F75E-4611-AF5D-6B66012ECFDF",
                Agrupamento = AgrupamentoPeca.Um_Para_Um,
                Codigo = 460,
                Consumo = 2.5f,
                Descricao = "",
                ImgPeca = new byte[0],
                Nome = "ColaPesponto",
                Tamanho = TamanhoPeca.Tamanho39,
                IdMateriaPrima = "460",
                IdEstrutura = TraditionIdEstrutura,
                NomeModelo = "Tradition",
                //Perimetro = 50.0f,
                //Superficie = 100.0f,
                //Data = DateTime.Now.Date,
                //Hora = DateTime.Now.TimeOfDay,
            };
            var PalmilhaAcabamentoSilk = new PecaCabedal
            {
                IdPeca = "D9A9C947-1A63-4496-920E-64BBF4ED83E1",
                Agrupamento = AgrupamentoPeca.Um_Para_Um,
                Codigo = 158,
                Consumo = 2.5f,
                Descricao = "",
                ImgPeca = new byte[0],
                Nome = "Palmilha Acabamento",
                Tamanho = TamanhoPeca.Tamanho39,
                IdMateriaPrima = "158",
                IdEstrutura = TraditionIdEstrutura,
                NomeModelo = "Tradition",
                //Perimetro = 50.0f,
                //Superficie = 100.0f,
                //Data = DateTime.Now.Date,
                //Hora = DateTime.Now.TimeOfDay,
            };
            var Cadarço = new PecaCabedal
            {
                IdPeca = "32E9988E-6969-4209-9BF6-90AC2BD4FE79",
                Agrupamento = AgrupamentoPeca.Um_Para_Um,
                Codigo = 52,
                Consumo = 2.5f,
                Descricao = "",
                ImgPeca = new byte[0],
                Nome = "Tubox",
                Tamanho = TamanhoPeca.Tamanho39,
                IdMateriaPrima = "52",
                IdEstrutura = TraditionIdEstrutura,
                NomeModelo = "Tradition",
                //Perimetro = 50.0f,
                //Superficie = 100.0f,
                //Data = DateTime.Now.Date,
                //Hora = DateTime.Now.TimeOfDay,
            };
            var LinguaEtiqueta = new PecaCabedal
            {
                IdPeca = "D1D37C29-5759-443D-AC2B-1118F734FF8D",
                Agrupamento = AgrupamentoPeca.Um_Para_Um,
                Codigo = 0,
                Consumo = 2.5f,
                Descricao = "",
                ImgPeca = new byte[0],
                Nome = "Etiqueta Lingua",
                Tamanho = TamanhoPeca.Tamanho39,
                IdMateriaPrima = "",
                IdEstrutura = TraditionIdEstrutura,
                NomeModelo = "Tradition",
                //Perimetro = 50.0f,
                //Superficie = 100.0f,
                //Data = DateTime.Now.Date,
                //Hora = DateTime.Now.TimeOfDay,
            };
            var ViesCabedalLingua = new PecaCabedal
            {
                IdPeca = "6B4B84E7-47B8-4E0D-A575-D27F8E21EDB4",
                Agrupamento = AgrupamentoPeca.Um_Para_Um,
                Codigo = 529,
                Consumo = 2.5f,
                Descricao = "",
                ImgPeca = new byte[0],
                Nome = "Viés",
                Tamanho = TamanhoPeca.Tamanho39,
                IdMateriaPrima = "529",
                IdEstrutura = TraditionIdEstrutura,
                NomeModelo = "Tradition",
                //Perimetro = 50.0f,
                //Superficie = 100.0f,
                //Data = DateTime.Now.Date,
                //Hora = DateTime.Now.TimeOfDay,
            };
            var EtiquetaFusao = new PecaCabedal
            {
                IdPeca = "34391FA0-DF9D-450B-A61D-9F07929D27DF",
                Agrupamento = AgrupamentoPeca.Um_Para_Um,
                Codigo = 0,
                Consumo = 2.5f,
                Descricao = "",
                ImgPeca = new byte[0],
                Nome = "Tubox",
                Tamanho = TamanhoPeca.Tamanho39,
                IdMateriaPrima = "",
                IdEstrutura = TraditionIdEstrutura,
                NomeModelo = "Tradition",
                //Perimetro = 50.0f,
                //Superficie = 100.0f,
                //Data = DateTime.Now.Date,
                //Hora = DateTime.Now.TimeOfDay,
            };
            var LinhaBiqueira = new PecaCabedal
            {
                IdPeca = "A55D8AB8-F77E-4BEA-8BAE-3AD36930606A",
                Agrupamento = AgrupamentoPeca.Um_Para_Um,
                Codigo = 506,
                Consumo = 2.5f,
                Descricao = "",
                ImgPeca = new byte[0],
                Nome = "Linha Biqueira",
                Tamanho = TamanhoPeca.Tamanho39,
                IdMateriaPrima = "506",
                IdEstrutura = TraditionIdEstrutura,
                NomeModelo = "Tradition",
                //Perimetro = 50.0f,
                //Superficie = 100.0f,
                //Data = DateTime.Now.Date,
                //Hora = DateTime.Now.TimeOfDay,
            };
            var LinhaViesLingua = new PecaCabedal
            {
                IdPeca = "83BEFC4D-6572-47C7-B2D1-D36B7E7DD024",
                Agrupamento = AgrupamentoPeca.Um_Para_Um,
                Codigo = 506,
                Consumo = 2.5f,
                Descricao = "",
                ImgPeca = new byte[0],
                Nome = "Linha Viés Lingua",
                Tamanho = TamanhoPeca.Tamanho39,
                IdMateriaPrima = "506",
                IdEstrutura = TraditionIdEstrutura,
                NomeModelo = "Tradition",
                //Perimetro = 50.0f,
                //Superficie = 100.0f,
                //Data = DateTime.Now.Date,
                //Hora = DateTime.Now.TimeOfDay,
            };
            var LinhaContraForte = new PecaCabedal
            {
                IdPeca = "83FDF359-85CA-45C8-AEEE-B4D7D7DD8EE7",
                Agrupamento = AgrupamentoPeca.Um_Para_Um,
                Codigo = 506,
                Consumo = 2.5f,
                Descricao = "",
                ImgPeca = new byte[0],
                Nome = "Linha Contra Forte",
                Tamanho = TamanhoPeca.Tamanho39,
                IdMateriaPrima = "506",
                IdEstrutura = TraditionIdEstrutura,
                NomeModelo = "Tradition",
                //Perimetro = 50.0f,
                //Superficie = 100.0f,
                //Data = DateTime.Now.Date,
                //Hora = DateTime.Now.TimeOfDay,
            };
            var LinhaViesCabedal = new PecaCabedal
            {
                IdPeca = "81EC7B9A-D5D8-4334-A4E2-F994D0CF352E",
                Agrupamento = AgrupamentoPeca.Um_Para_Um,
                Codigo = 506,
                Consumo = 2.5f,
                Descricao = "",
                ImgPeca = new byte[0],
                Nome = "Linha Viés Cabedal",
                Tamanho = TamanhoPeca.Tamanho39,
                IdMateriaPrima = "506",
                IdEstrutura = TraditionIdEstrutura,
                NomeModelo = "Tradition",
                //Perimetro = 50.0f,
                //Superficie = 100.0f,
                //Data = DateTime.Now.Date,
                //Hora = DateTime.Now.TimeOfDay,
            };
            var LinhaCanelinha = new PecaCabedal
            {
                IdPeca = "B963687B-8253-47F6-8EAC-4B0247FF14D1",
                Agrupamento = AgrupamentoPeca.Um_Para_Um,
                Codigo = 506,
                Consumo = 2.5f,
                Descricao = "",
                ImgPeca = new byte[0],
                Nome = "Linha Canelinha",
                Tamanho = TamanhoPeca.Tamanho39,
                IdMateriaPrima = "506",
                IdEstrutura = TraditionIdEstrutura,
                NomeModelo = "Tradition",
                //Perimetro = 50.0f,
                //Superficie = 100.0f,
                //Data = DateTime.Now.Date,
                //Hora = DateTime.Now.TimeOfDay,
            };


            modelBuilder.Entity<PecaCabedal>().HasData(
            Lateral, Frente, Lingua, ContraForte, Estrutura, ReforçoTesourinha, Tubox,
            PalmilhaAcabamento, PalmilhaMontagem, CunhoPalmilha, Ilhos, ColaPesponto,
            PalmilhaAcabamentoSilk, Cadarço, LinguaEtiqueta, ViesCabedalLingua, EtiquetaFusao,
            LinhaBiqueira, LinhaViesLingua, LinhaContraForte, LinhaViesCabedal, LinhaCanelinha);

        }


    }
}