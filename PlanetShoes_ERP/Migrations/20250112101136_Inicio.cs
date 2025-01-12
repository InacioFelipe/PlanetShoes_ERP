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
                columns: new[] { "IdEstrutura", "DesignCabedal", "EstruturaCabedal", "SubEstruturaComPeca_EstruturaIdEstrutura", "IdSubEstrutura", "ImgSubEstruturaComPeca", "TipoEstrutura" },
                values: new object[,]
                {
                    { "01D87D95-6249-4498-9DDA-A02DC6E42289", 2, 4, null, "F6E11985-8E4E-48E4-B2CC-D465D000346E", new byte[0], "ComPecaCabedal" },
                    { "29FBB68A-5082-4DA0-B0A9-C7CCA1F74863", 1, 3, null, "58888D1E-ACB8-4C21-ADAE-4FA045BDABC2", new byte[0], "ComPecaCabedal" },
                    { "4FCC9FBE-2E74-49EE-894B-CD0218DEE4FC", 1, 3, null, "731C10FA-2FE5-46FC-AAB3-EF9C698AFCE5", new byte[0], "ComPecaCabedal" },
                    { "5B26036A-093A-4281-B7F9-2FC8E279BA9B", 1, 3, null, "614D36C0-BB73-4A47-81DC-53CA4E84EABF", new byte[0], "ComPecaCabedal" },
                    { "6A041E67-E930-4C90-A5B5-4E6FFFDD9B4D", 1, 2, null, "0776F178-C54A-4510-9071-B3BCD8949294", new byte[0], "ComPecaCabedal" },
                    { "70C8D67F-8389-4A0F-B562-B65755BF5F2D", 1, 3, null, "E866DA20-6D2C-4DB8-8CAE-87E0583E0976", new byte[0], "ComPecaCabedal" },
                    { "82B642A3-49E5-44E1-BF4C-6DB5A5D32E2E", 1, 3, null, "64DDEF39-2D7F-4536-9384-EF38A3BCAF64", new byte[0], "ComPecaCabedal" },
                    { "890A6467-11F0-4F24-AB71-1DA78E7557DC", 1, 3, null, "4EDDBF84-E910-45D9-9F5A-1D438A4C6079", new byte[0], "ComPecaCabedal" },
                    { "8DBD4389-489A-420E-951D-8E10692C66C7", 1, 3, null, "BBC0A289-83D4-4021-AF66-E8137C9AD0FE", new byte[0], "ComPecaCabedal" },
                    { "A035415C-2E66-488C-B71A-ABFDC01C563B", 2, 2, null, "706DB229-FBDE-4DC8-809F-4438A04466C2", new byte[0], "ComPecaCabedal" },
                    { "B7DCEF23-1A4D-4107-8E09-5D77C4C7D672", 1, 2, null, "9DE1CFEF-3CC5-41D7-899A-CB6CFA9E097D", new byte[0], "ComPecaCabedal" },
                    { "D98C37D8-EBA7-4C56-8C2D-D1F09900968D", 1, 2, null, "50606EB5-86C1-40CA-A6A1-820E050DE4BA", new byte[0], "ComPecaCabedal" },
                    { "E8239707-2A14-4E06-AA4C-58ED9A42EFB9", 2, 2, null, "4BA8CDC6-E596-428D-85AC-59407F2C2F87", new byte[0], "ComPecaCabedal" },
                    { "EF8F52BD-03C8-431B-8BBF-53E312E667CE", 1, 4, null, "84EB0992-FF2B-4C17-AD84-884B5396C26C", new byte[0], "ComPecaCabedal" }
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
                    { "1B183DD2-3629-44E1-A135-1CF173A960CB", 0, 101, 2.5f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "PecaCabedal", new TimeSpan(0, 0, 0, 0, 0), "01D87D95-6249-4498-9DDA-A02DC6E42289", "MateriaPrima1", new byte[0], null, "ContraForte", "Tradition", 0f, 0f, 39 },
                    { "1D39D7E3-F75E-4611-AF5D-6B66012ECFDF", 0, 101, 2.5f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "PecaCabedal", new TimeSpan(0, 0, 0, 0, 0), "01D87D95-6249-4498-9DDA-A02DC6E42289", "MateriaPrima1", new byte[0], null, "ColaPesponto", "Tradition", 0f, 0f, 39 },
                    { "238DEEE8-ACDB-43E3-B468-FE2EB0D4A2CD", 0, 101, 2.5f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "PecaCabedal", new TimeSpan(0, 0, 0, 0, 0), "01D87D95-6249-4498-9DDA-A02DC6E42289", "MateriaPrima1", new byte[0], null, "Tubox", "Tradition", 0f, 0f, 39 },
                    { "32E9988E-6969-4209-9BF6-90AC2BD4FE79", 0, 101, 2.5f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "PecaCabedal", new TimeSpan(0, 0, 0, 0, 0), "01D87D95-6249-4498-9DDA-A02DC6E42289", "MateriaPrima1", new byte[0], null, "Tubox", "Tradition", 0f, 0f, 39 },
                    { "34391FA0-DF9D-450B-A61D-9F07929D27DF", 0, 101, 2.5f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "PecaCabedal", new TimeSpan(0, 0, 0, 0, 0), "01D87D95-6249-4498-9DDA-A02DC6E42289", "MateriaPrima1", new byte[0], null, "Tubox", "Tradition", 0f, 0f, 39 },
                    { "6B4B84E7-47B8-4E0D-A575-D27F8E21EDB4", 0, 101, 2.5f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "PecaCabedal", new TimeSpan(0, 0, 0, 0, 0), "01D87D95-6249-4498-9DDA-A02DC6E42289", "MateriaPrima1", new byte[0], null, "Viés", "Tradition", 0f, 0f, 39 },
                    { "786E20A8-C63B-4DDB-82F7-77746E608F6E", 0, 101, 2.5f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "PecaCabedal", new TimeSpan(0, 0, 0, 0, 0), "01D87D95-6249-4498-9DDA-A02DC6E42289", "MateriaPrima1", new byte[0], null, "Lateral", "Tradition", 0f, 0f, 39 },
                    { "7D820DD4-F558-423C-804C-4AC12F9491C0", 0, 101, 2.5f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "PecaCabedal", new TimeSpan(0, 0, 0, 0, 0), "01D87D95-6249-4498-9DDA-A02DC6E42289", "MateriaPrima1", new byte[0], null, "Lingua", "Tradition", 0f, 0f, 39 },
                    { "81598CCB-AEE0-4448-9106-8226BC54E2AE", 0, 101, 2.5f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "PecaCabedal", new TimeSpan(0, 0, 0, 0, 0), "01D87D95-6249-4498-9DDA-A02DC6E42289", "MateriaPrima1", new byte[0], null, "Ilhos", "Tradition", 0f, 0f, 39 },
                    { "81EC7B9A-D5D8-4334-A4E2-F994D0CF352E", 0, 101, 2.5f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "PecaCabedal", new TimeSpan(0, 0, 0, 0, 0), "01D87D95-6249-4498-9DDA-A02DC6E42289", "MateriaPrima1", new byte[0], null, "Linha Viés Cabedal", "Tradition", 0f, 0f, 39 },
                    { "83BEFC4D-6572-47C7-B2D1-D36B7E7DD024", 0, 101, 2.5f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "PecaCabedal", new TimeSpan(0, 0, 0, 0, 0), "01D87D95-6249-4498-9DDA-A02DC6E42289", "MateriaPrima1", new byte[0], null, "Linha Viés Lingua", "Tradition", 0f, 0f, 39 },
                    { "83FDF359-85CA-45C8-AEEE-B4D7D7DD8EE7", 0, 101, 2.5f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "PecaCabedal", new TimeSpan(0, 0, 0, 0, 0), "01D87D95-6249-4498-9DDA-A02DC6E42289", "MateriaPrima1", new byte[0], null, "Linha Contra Forte", "Tradition", 0f, 0f, 39 },
                    { "940C7C4A-632A-4728-877B-89863C2BF36F", 0, 101, 2.5f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "PecaCabedal", new TimeSpan(0, 0, 0, 0, 0), "01D87D95-6249-4498-9DDA-A02DC6E42289", "MateriaPrima1", new byte[0], null, "Regorço Tesourinha", "Tradition", 0f, 0f, 39 },
                    { "A3150C99-045A-4EA9-8583-866233CE1F18", 0, 101, 2.5f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "PecaCabedal", new TimeSpan(0, 0, 0, 0, 0), "01D87D95-6249-4498-9DDA-A02DC6E42289", "MateriaPrima1", new byte[0], null, "Cunho Palmilha", "Tradition", 0f, 0f, 39 },
                    { "A55D8AB8-F77E-4BEA-8BAE-3AD36930606A", 0, 101, 2.5f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "PecaCabedal", new TimeSpan(0, 0, 0, 0, 0), "01D87D95-6249-4498-9DDA-A02DC6E42289", "MateriaPrima1", new byte[0], null, "Linha Biqueira", "Tradition", 0f, 0f, 39 },
                    { "B963687B-8253-47F6-8EAC-4B0247FF14D1", 0, 101, 2.5f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "PecaCabedal", new TimeSpan(0, 0, 0, 0, 0), "01D87D95-6249-4498-9DDA-A02DC6E42289", "MateriaPrima1", new byte[0], null, "Linha Canelinha", "Tradition", 0f, 0f, 39 },
                    { "BE2E37D0-01CF-4C58-A9CE-2612571B8A9A", 0, 101, 2.5f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "PecaCabedal", new TimeSpan(0, 0, 0, 0, 0), "01D87D95-6249-4498-9DDA-A02DC6E42289", "MateriaPrima1", new byte[0], null, "Palmilha Montagem", "Tradition", 0f, 0f, 39 },
                    { "D1D37C29-5759-443D-AC2B-1118F734FF8D", 0, 101, 2.5f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "PecaCabedal", new TimeSpan(0, 0, 0, 0, 0), "01D87D95-6249-4498-9DDA-A02DC6E42289", "MateriaPrima1", new byte[0], null, "Etiqueta Lingua", "Tradition", 0f, 0f, 39 },
                    { "D23A4A71-53CF-45EA-88E4-FDAEDF03158B", 0, 101, 2.5f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "PecaCabedal", new TimeSpan(0, 0, 0, 0, 0), "01D87D95-6249-4498-9DDA-A02DC6E42289", "MateriaPrima1", new byte[0], null, "Palmilha Acabamento", "Tradition", 0f, 0f, 39 },
                    { "D370D1C3-E7C5-40AB-9E99-634D564088FD", 0, 101, 2.5f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "PecaCabedal", new TimeSpan(0, 0, 0, 0, 0), "01D87D95-6249-4498-9DDA-A02DC6E42289", "MateriaPrima1", new byte[0], null, "Estrutura", "Tradition", 0f, 0f, 39 },
                    { "D9A9C947-1A63-4496-920E-64BBF4ED83E1", 0, 101, 2.5f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "PecaCabedal", new TimeSpan(0, 0, 0, 0, 0), "01D87D95-6249-4498-9DDA-A02DC6E42289", "MateriaPrima1", new byte[0], null, "Palmilha Acabamento", "Tradition", 0f, 0f, 39 },
                    { "E5F4B02A-7C69-469A-86FF-C6E552643373", 0, 101, 2.5f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "PecaCabedal", new TimeSpan(0, 0, 0, 0, 0), "01D87D95-6249-4498-9DDA-A02DC6E42289", "MateriaPrima1", new byte[0], null, "Frente", "Tradition", 0f, 0f, 39 },
                    { "PecaCabedal1", 0, 101, 2.5f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cabedal de couro", "PecaCabedal", new TimeSpan(0, 0, 0, 0, 0), "Estrutura5", "MateriaPrima1", new byte[0], null, "Cabedal 1", "Empire", 50f, 100f, 40 },
                    { "PecaCabedal2", 1, 102, 3f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cabedal sintético", "PecaCabedal", new TimeSpan(0, 0, 0, 0, 0), "Estrutura5", "MateriaPrima2", new byte[0], null, "Cabedal 2", "Modern", 55f, 110f, 42 }
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
                    { "PecaSolado1", 0, 201, 1.5f, "Solado de borracha", "PecaSolado", "Estrutura5", "MateriaPrima2", new byte[0], null, "Solado 1", 0.5f, 40 },
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
