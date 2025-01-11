using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanetShoes.Migrations
{
    /// <inheritdoc />
    public partial class AddTipoEstruturaToEstrutura : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pecas",
                keyColumn: "IdPeca",
                keyValue: "PecaCabedal2",
                column: "IdEstrutura",
                value: "Estrutura5");

            migrationBuilder.UpdateData(
                table: "Pecas",
                keyColumn: "IdPeca",
                keyValue: "PecaSolado1",
                column: "IdEstrutura",
                value: "Estrutura5");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pecas",
                keyColumn: "IdPeca",
                keyValue: "PecaCabedal2",
                column: "IdEstrutura",
                value: "Estrutura6");

            migrationBuilder.UpdateData(
                table: "Pecas",
                keyColumn: "IdPeca",
                keyValue: "PecaSolado1",
                column: "IdEstrutura",
                value: "Estrutura7");
        }
    }
}
