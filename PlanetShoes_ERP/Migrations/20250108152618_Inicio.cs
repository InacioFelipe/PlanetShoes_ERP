using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PlanetShoes.Migrations
{
    /// <inheritdoc />
    public partial class Inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estruturas",
                columns: table => new
                {
                    IdEstrutura = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdSubEstrutura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoEstrutura = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    Consumo = table.Column<float>(type: "real", nullable: true),
                    ImgAcabado = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    SubEstruturaAviamento_Consumo = table.Column<float>(type: "real", nullable: true),
                    SubEstruturaAviamento_ImgAcabado = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ImgSubEstruturaComPeca = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DesignCabedal = table.Column<int>(type: "int", nullable: true),
                    EstruturaCabedal = table.Column<int>(type: "int", nullable: true),
                    AlturaSolado = table.Column<int>(type: "int", nullable: true),
                    DesignSolado = table.Column<int>(type: "int", nullable: true),
                    EstruturaSolado = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estruturas", x => x.IdEstrutura);
                });

            migrationBuilder.CreateTable(
                name: "MateriasPrimas",
                columns: table => new
                {
                    IdMateriaPrima = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Classe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnidadeMedida = table.Column<int>(type: "int", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ValorUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ImgMateriaPrima = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MateriasPrimas", x => x.IdMateriaPrima);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePicture = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Pecas",
                columns: table => new
                {
                    IdPeca = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Agrupamento = table.Column<int>(type: "int", nullable: false),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Consumo = table.Column<float>(type: "real", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgPeca = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tamanho = table.Column<int>(type: "int", nullable: false),
                    IdMateriaPrima = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    SubEstruturaComPecaCabedalIdEstrutura = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SubEstruturaComPecaSoladoIdEstrutura = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Hora = table.Column<TimeSpan>(type: "time", nullable: true),
                    NomeModelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Perimetro = table.Column<float>(type: "real", nullable: true),
                    Superficie = table.Column<float>(type: "real", nullable: true),
                    Peso = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pecas", x => x.IdPeca);
                    table.ForeignKey(
                        name: "FK_Pecas_Estruturas_SubEstruturaComPecaCabedalIdEstrutura",
                        column: x => x.SubEstruturaComPecaCabedalIdEstrutura,
                        principalTable: "Estruturas",
                        principalColumn: "IdEstrutura");
                    table.ForeignKey(
                        name: "FK_Pecas_Estruturas_SubEstruturaComPecaSoladoIdEstrutura",
                        column: x => x.SubEstruturaComPecaSoladoIdEstrutura,
                        principalTable: "Estruturas",
                        principalColumn: "IdEstrutura");
                });

            migrationBuilder.InsertData(
                table: "Estruturas",
                columns: new[] { "IdEstrutura", "IdSubEstrutura", "TipoEstrutura" },
                values: new object[] { "Estrutura0", "SubEstrutura0", "Estrutura" });

            migrationBuilder.InsertData(
                table: "Estruturas",
                columns: new[] { "IdEstrutura", "Consumo", "IdSubEstrutura", "ImgAcabado", "TipoEstrutura" },
                values: new object[] { "Estrutura1", 10.5f, "SubEstrutura1", new byte[0], "Acabado" });

            migrationBuilder.InsertData(
                table: "Estruturas",
                columns: new[] { "IdEstrutura", "SubEstruturaAviamento_Consumo", "IdSubEstrutura", "SubEstruturaAviamento_ImgAcabado", "TipoEstrutura" },
                values: new object[] { "Estrutura2", 5f, "SubEstrutura2", new byte[0], "Aviamento" });

            migrationBuilder.InsertData(
                table: "Estruturas",
                columns: new[] { "IdEstrutura", "AlturaSolado", "DesignSolado", "EstruturaSolado", "IdSubEstrutura", "ImgSubEstruturaComPeca", "TipoEstrutura" },
                values: new object[] { "Estrutura3", 2, 1, 0, "SubEstrutura3", new byte[0], "ComPecaSolado" });

            migrationBuilder.InsertData(
                table: "Estruturas",
                columns: new[] { "IdEstrutura", "DesignCabedal", "EstruturaCabedal", "IdSubEstrutura", "ImgSubEstruturaComPeca", "TipoEstrutura" },
                values: new object[] { "Estrutura4", 2, 1, "SubEstrutura4", new byte[0], "ComPecaCabedal" });

            migrationBuilder.InsertData(
                table: "MateriasPrimas",
                columns: new[] { "IdMateriaPrima", "Classe", "Codigo", "Descricao", "ImgMateriaPrima", "Nome", "UnidadeMedida", "Valor", "ValorUnitario" },
                values: new object[,]
                {
                    { "MateriaPrima1", "Natural", 0, "Couro de alta qualidade", null, "Couro Bovino", 2, 100.00m, null },
                    { "MateriaPrima2", "Sintético", 0, "Borracha para solados", null, "Borracha Sintética", 5, 50.00m, null }
                });

            migrationBuilder.InsertData(
                table: "Pecas",
                columns: new[] { "IdPeca", "Agrupamento", "Codigo", "Consumo", "Descricao", "Discriminator", "IdMateriaPrima", "ImgPeca", "Nome", "Peso", "SubEstruturaComPecaCabedalIdEstrutura", "SubEstruturaComPecaSoladoIdEstrutura", "Tamanho" },
                values: new object[] { "IdPeca1", 0, 101, 2.5f, "Solado de borracha", "PecaSolado", "MateriaPrima2", new byte[0], "Solado 1", 0f, null, null, 40 });

            migrationBuilder.InsertData(
                table: "Pecas",
                columns: new[] { "IdPeca", "Agrupamento", "Codigo", "Consumo", "Data", "Descricao", "Discriminator", "Hora", "IdMateriaPrima", "ImgPeca", "Nome", "NomeModelo", "Perimetro", "SubEstruturaComPecaCabedalIdEstrutura", "SubEstruturaComPecaSoladoIdEstrutura", "Superficie", "Tamanho" },
                values: new object[] { "IdPeca2", 1, 201, 1f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cabedal de couro", "PecaCabedal", new TimeSpan(0, 0, 0, 0, 0), "MateriaPrima1", new byte[0], "Cabedal 1", "Empire", 0f, null, null, 0f, 42 });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UserId", "DisplayName", "Email", "Password", "ProfilePicture", "Username" },
                values: new object[,]
                {
                    { "9d340277-2ced-4037-84f4-c6fc2cba5579", "Inacio Felipe Couto Ferreira", "inacio.felipe@planetshoes.com", "inacio", null, "Inacio" },
                    { "f9921ce6-ff36-4757-b3be-a7c7e53c45a2", "Luciano Antônio Ferreira", "luciano.ferreira@planetshoes.com", "luciano", null, "Luciano" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pecas_SubEstruturaComPecaCabedalIdEstrutura",
                table: "Pecas",
                column: "SubEstruturaComPecaCabedalIdEstrutura");

            migrationBuilder.CreateIndex(
                name: "IX_Pecas_SubEstruturaComPecaSoladoIdEstrutura",
                table: "Pecas",
                column: "SubEstruturaComPecaSoladoIdEstrutura");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MateriasPrimas");

            migrationBuilder.DropTable(
                name: "Pecas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Estruturas");
        }
    }
}
