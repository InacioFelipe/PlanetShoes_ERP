using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PlanetShoes.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
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
                    EstruturaIdEstrutura = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SubEstruturaAviamento_Consumo = table.Column<float>(type: "real", nullable: true),
                    SubEstruturaAviamento_ImgAcabado = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    SubEstruturaAviamento_EstruturaIdEstrutura = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ImgSubEstruturaComPeca = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    SubEstruturaComPeca_EstruturaIdEstrutura = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DesignCabedal = table.Column<int>(type: "int", nullable: true),
                    EstruturaCabedal = table.Column<int>(type: "int", nullable: true),
                    AlturaSolado = table.Column<int>(type: "int", nullable: true),
                    DesignSolado = table.Column<int>(type: "int", nullable: true),
                    EstruturaSolado = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estruturas", x => x.IdEstrutura);
                    table.ForeignKey(
                        name: "FK_Estruturas_Estruturas_EstruturaIdEstrutura",
                        column: x => x.EstruturaIdEstrutura,
                        principalTable: "Estruturas",
                        principalColumn: "IdEstrutura");
                    table.ForeignKey(
                        name: "FK_Estruturas_Estruturas_SubEstruturaAviamento_EstruturaIdEstrutura",
                        column: x => x.SubEstruturaAviamento_EstruturaIdEstrutura,
                        principalTable: "Estruturas",
                        principalColumn: "IdEstrutura");
                    table.ForeignKey(
                        name: "FK_Estruturas_Estruturas_SubEstruturaComPeca_EstruturaIdEstrutura",
                        column: x => x.SubEstruturaComPeca_EstruturaIdEstrutura,
                        principalTable: "Estruturas",
                        principalColumn: "IdEstrutura");
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
                    IdEstrutura = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MateriaPrimaIdMateriaPrima = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
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
                        name: "FK_Pecas_Estruturas_IdEstrutura",
                        column: x => x.IdEstrutura,
                        principalTable: "Estruturas",
                        principalColumn: "IdEstrutura",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pecas_MateriasPrimas_MateriaPrimaIdMateriaPrima",
                        column: x => x.MateriaPrimaIdMateriaPrima,
                        principalTable: "MateriasPrimas",
                        principalColumn: "IdMateriaPrima");
                });

            migrationBuilder.InsertData(
                table: "Estruturas",
                columns: new[] { "IdEstrutura", "Consumo", "EstruturaIdEstrutura", "IdSubEstrutura", "ImgAcabado", "TipoEstrutura" },
                values: new object[] { "Estrutura1", 10.5f, null, "SubEstrutura1", new byte[0], "Acabado" });

            migrationBuilder.InsertData(
                table: "Estruturas",
                columns: new[] { "IdEstrutura", "SubEstruturaComPeca_EstruturaIdEstrutura", "IdSubEstrutura", "ImgSubEstruturaComPeca", "TipoEstrutura" },
                values: new object[] { "Estrutura10", null, "SubEstrutura10", new byte[0], "ComPeca" });

            migrationBuilder.InsertData(
                table: "Estruturas",
                columns: new[] { "IdEstrutura", "Consumo", "EstruturaIdEstrutura", "IdSubEstrutura", "ImgAcabado", "TipoEstrutura" },
                values: new object[] { "Estrutura2", 15f, null, "SubEstrutura2", new byte[0], "Acabado" });

            migrationBuilder.InsertData(
                table: "Estruturas",
                columns: new[] { "IdEstrutura", "SubEstruturaAviamento_Consumo", "SubEstruturaAviamento_EstruturaIdEstrutura", "IdSubEstrutura", "SubEstruturaAviamento_ImgAcabado", "TipoEstrutura" },
                values: new object[,]
                {
                    { "Estrutura3", 5f, null, "SubEstrutura3", new byte[0], "Aviamento" },
                    { "Estrutura4", 7.5f, null, "SubEstrutura4", new byte[0], "Aviamento" }
                });

            migrationBuilder.InsertData(
                table: "Estruturas",
                columns: new[] { "IdEstrutura", "DesignCabedal", "EstruturaCabedal", "SubEstruturaComPeca_EstruturaIdEstrutura", "IdSubEstrutura", "ImgSubEstruturaComPeca", "TipoEstrutura" },
                values: new object[,]
                {
                    { "Estrutura5", 2, 1, null, "SubEstrutura5", new byte[0], "ComPecaCabedal" },
                    { "Estrutura6", 1, 2, null, "SubEstrutura6", new byte[0], "ComPecaCabedal" }
                });

            migrationBuilder.InsertData(
                table: "Estruturas",
                columns: new[] { "IdEstrutura", "AlturaSolado", "DesignSolado", "SubEstruturaComPeca_EstruturaIdEstrutura", "EstruturaSolado", "IdSubEstrutura", "ImgSubEstruturaComPeca", "TipoEstrutura" },
                values: new object[,]
                {
                    { "Estrutura7", 2, 1, null, 0, "SubEstrutura7", new byte[0], "ComPecaSolado" },
                    { "Estrutura8", 3, 4, null, 1, "SubEstrutura8", new byte[0], "ComPecaSolado" }
                });

            migrationBuilder.InsertData(
                table: "Estruturas",
                columns: new[] { "IdEstrutura", "SubEstruturaComPeca_EstruturaIdEstrutura", "IdSubEstrutura", "ImgSubEstruturaComPeca", "TipoEstrutura" },
                values: new object[] { "Estrutura9", null, "SubEstrutura9", new byte[0], "ComPeca" });

            migrationBuilder.InsertData(
                table: "MateriasPrimas",
                columns: new[] { "IdMateriaPrima", "Classe", "Codigo", "Descricao", "ImgMateriaPrima", "Nome", "UnidadeMedida", "Valor", "ValorUnitario" },
                values: new object[,]
                {
                    { "MateriaPrima1", "Natural", 0, "Couro de alta qualidade", null, "Couro Bovino", 2, 100.00m, null },
                    { "MateriaPrima2", "Sintético", 0, "Borracha para solados", null, "Borracha Sintética", 5, 50.00m, null }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UserId", "DisplayName", "Email", "Password", "ProfilePicture", "Username" },
                values: new object[,]
                {
                    { "9d340277-2ced-4037-84f4-c6fc2cba5579", "Inacio Felipe Couto Ferreira", "inacio.felipe@planetshoes.com", "inacio", null, "Inacio" },
                    { "f9921ce6-ff36-4757-b3be-a7c7e53c45a2", "Luciano Antônio Ferreira", "luciano.ferreira@planetshoes.com", "luciano", null, "Luciano" }
                });

            migrationBuilder.InsertData(
                table: "Pecas",
                columns: new[] { "IdPeca", "Agrupamento", "Codigo", "Consumo", "Data", "Descricao", "Discriminator", "Hora", "IdEstrutura", "IdMateriaPrima", "ImgPeca", "MateriaPrimaIdMateriaPrima", "Nome", "NomeModelo", "Perimetro", "Superficie", "Tamanho" },
                values: new object[,]
                {
                    { "PecaCabedal1", 0, 101, 2.5f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cabedal de couro", "PecaCabedal", new TimeSpan(0, 0, 0, 0, 0), "Estrutura5", "MateriaPrima1", new byte[0], null, "Cabedal 1", "Empire", 50f, 100f, 40 },
                    { "PecaCabedal2", 1, 102, 3f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cabedal sintético", "PecaCabedal", new TimeSpan(0, 0, 0, 0, 0), "Estrutura6", "MateriaPrima2", new byte[0], null, "Cabedal 2", "Modern", 55f, 110f, 42 }
                });

            migrationBuilder.InsertData(
                table: "Pecas",
                columns: new[] { "IdPeca", "Agrupamento", "Codigo", "Consumo", "Descricao", "Discriminator", "IdEstrutura", "IdMateriaPrima", "ImgPeca", "MateriaPrimaIdMateriaPrima", "Nome", "Tamanho" },
                values: new object[,]
                {
                    { "PecaGenerica1", 0, 301, 1f, "Peça genérica 1", "Peca", "Estrutura9", "MateriaPrima1", new byte[0], null, "Peça Genérica 1", 40 },
                    { "PecaGenerica2", 1, 302, 1.5f, "Peça genérica 2", "Peca", "Estrutura10", "MateriaPrima2", new byte[0], null, "Peça Genérica 2", 42 }
                });

            migrationBuilder.InsertData(
                table: "Pecas",
                columns: new[] { "IdPeca", "Agrupamento", "Codigo", "Consumo", "Descricao", "Discriminator", "IdEstrutura", "IdMateriaPrima", "ImgPeca", "MateriaPrimaIdMateriaPrima", "Nome", "Peso", "Tamanho" },
                values: new object[,]
                {
                    { "PecaSolado1", 0, 201, 1.5f, "Solado de borracha", "PecaSolado", "Estrutura7", "MateriaPrima2", new byte[0], null, "Solado 1", 0.5f, 40 },
                    { "PecaSolado2", 1, 202, 2f, "Solado de EVA", "PecaSolado", "Estrutura8", "MateriaPrima1", new byte[0], null, "Solado 2", 0.6f, 42 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estruturas_EstruturaIdEstrutura",
                table: "Estruturas",
                column: "EstruturaIdEstrutura");

            migrationBuilder.CreateIndex(
                name: "IX_Estruturas_SubEstruturaAviamento_EstruturaIdEstrutura",
                table: "Estruturas",
                column: "SubEstruturaAviamento_EstruturaIdEstrutura");

            migrationBuilder.CreateIndex(
                name: "IX_Estruturas_SubEstruturaComPeca_EstruturaIdEstrutura",
                table: "Estruturas",
                column: "SubEstruturaComPeca_EstruturaIdEstrutura");

            migrationBuilder.CreateIndex(
                name: "IX_Pecas_IdEstrutura",
                table: "Pecas",
                column: "IdEstrutura");

            migrationBuilder.CreateIndex(
                name: "IX_Pecas_MateriaPrimaIdMateriaPrima",
                table: "Pecas",
                column: "MateriaPrimaIdMateriaPrima");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pecas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Estruturas");

            migrationBuilder.DropTable(
                name: "MateriasPrimas");
        }
    }
}
