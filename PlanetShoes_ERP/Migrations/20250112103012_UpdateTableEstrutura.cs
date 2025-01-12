using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanetShoes.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableEstrutura : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeEstrutura",
                table: "Estruturas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Estruturas",
                keyColumn: "IdEstrutura",
                keyValue: "01D87D95-6249-4498-9DDA-A02DC6E42289",
                column: "NomeEstrutura",
                value: "Tradition");

            migrationBuilder.UpdateData(
                table: "Estruturas",
                keyColumn: "IdEstrutura",
                keyValue: "29FBB68A-5082-4DA0-B0A9-C7CCA1F74863",
                column: "NomeEstrutura",
                value: "Jupter infanatil");

            migrationBuilder.UpdateData(
                table: "Estruturas",
                keyColumn: "IdEstrutura",
                keyValue: "4FCC9FBE-2E74-49EE-894B-CD0218DEE4FC",
                column: "NomeEstrutura",
                value: "Pegasus");

            migrationBuilder.UpdateData(
                table: "Estruturas",
                keyColumn: "IdEstrutura",
                keyValue: "5B26036A-093A-4281-B7F9-2FC8E279BA9B",
                column: "NomeEstrutura",
                value: "Vintage");

            migrationBuilder.UpdateData(
                table: "Estruturas",
                keyColumn: "IdEstrutura",
                keyValue: "6A041E67-E930-4C90-A5B5-4E6FFFDD9B4D",
                column: "NomeEstrutura",
                value: "Ivy");

            migrationBuilder.UpdateData(
                table: "Estruturas",
                keyColumn: "IdEstrutura",
                keyValue: "70C8D67F-8389-4A0F-B562-B65755BF5F2D",
                column: "NomeEstrutura",
                value: "Icaro");

            migrationBuilder.UpdateData(
                table: "Estruturas",
                keyColumn: "IdEstrutura",
                keyValue: "82B642A3-49E5-44E1-BF4C-6DB5A5D32E2E",
                column: "NomeEstrutura",
                value: "Orion infantil");

            migrationBuilder.UpdateData(
                table: "Estruturas",
                keyColumn: "IdEstrutura",
                keyValue: "890A6467-11F0-4F24-AB71-1DA78E7557DC",
                column: "NomeEstrutura",
                value: "Empire");

            migrationBuilder.UpdateData(
                table: "Estruturas",
                keyColumn: "IdEstrutura",
                keyValue: "8DBD4389-489A-420E-951D-8E10692C66C7",
                column: "NomeEstrutura",
                value: "Maya Frequencia");

            migrationBuilder.UpdateData(
                table: "Estruturas",
                keyColumn: "IdEstrutura",
                keyValue: "A035415C-2E66-488C-B71A-ABFDC01C563B",
                column: "NomeEstrutura",
                value: "New Stone 7010");

            migrationBuilder.UpdateData(
                table: "Estruturas",
                keyColumn: "IdEstrutura",
                keyValue: "B7DCEF23-1A4D-4107-8E09-5D77C4C7D672",
                column: "NomeEstrutura",
                value: "Emma");

            migrationBuilder.UpdateData(
                table: "Estruturas",
                keyColumn: "IdEstrutura",
                keyValue: "D98C37D8-EBA7-4C56-8C2D-D1F09900968D",
                column: "NomeEstrutura",
                value: "Rock");

            migrationBuilder.UpdateData(
                table: "Estruturas",
                keyColumn: "IdEstrutura",
                keyValue: "E8239707-2A14-4E06-AA4C-58ED9A42EFB9",
                column: "NomeEstrutura",
                value: "Winner 7010");

            migrationBuilder.UpdateData(
                table: "Estruturas",
                keyColumn: "IdEstrutura",
                keyValue: "EF8F52BD-03C8-431B-8BBF-53E312E667CE",
                column: "NomeEstrutura",
                value: "Los Angeles Cano Baixo");

            migrationBuilder.UpdateData(
                table: "Estruturas",
                keyColumn: "IdEstrutura",
                keyValue: "Estrutura1",
                column: "NomeEstrutura",
                value: null);

            migrationBuilder.UpdateData(
                table: "Estruturas",
                keyColumn: "IdEstrutura",
                keyValue: "Estrutura10",
                column: "NomeEstrutura",
                value: null);

            migrationBuilder.UpdateData(
                table: "Estruturas",
                keyColumn: "IdEstrutura",
                keyValue: "Estrutura2",
                column: "NomeEstrutura",
                value: null);

            migrationBuilder.UpdateData(
                table: "Estruturas",
                keyColumn: "IdEstrutura",
                keyValue: "Estrutura3",
                column: "NomeEstrutura",
                value: null);

            migrationBuilder.UpdateData(
                table: "Estruturas",
                keyColumn: "IdEstrutura",
                keyValue: "Estrutura4",
                column: "NomeEstrutura",
                value: null);

            migrationBuilder.UpdateData(
                table: "Estruturas",
                keyColumn: "IdEstrutura",
                keyValue: "Estrutura5",
                column: "NomeEstrutura",
                value: null);

            migrationBuilder.UpdateData(
                table: "Estruturas",
                keyColumn: "IdEstrutura",
                keyValue: "Estrutura6",
                column: "NomeEstrutura",
                value: null);

            migrationBuilder.UpdateData(
                table: "Estruturas",
                keyColumn: "IdEstrutura",
                keyValue: "Estrutura7",
                column: "NomeEstrutura",
                value: null);

            migrationBuilder.UpdateData(
                table: "Estruturas",
                keyColumn: "IdEstrutura",
                keyValue: "Estrutura8",
                column: "NomeEstrutura",
                value: null);

            migrationBuilder.UpdateData(
                table: "Estruturas",
                keyColumn: "IdEstrutura",
                keyValue: "Estrutura9",
                column: "NomeEstrutura",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeEstrutura",
                table: "Estruturas");
        }
    }
}
