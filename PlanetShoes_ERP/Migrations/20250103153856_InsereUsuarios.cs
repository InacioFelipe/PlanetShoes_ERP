using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PlanetShoes.Migrations
{
    /// <inheritdoc />
    public partial class InsereUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UserId", "DisplayName", "Email", "Password", "ProfilePicture", "Username" },
                values: new object[,]
                {
                    { "9d340277-2ced-4037-84f4-c6fc2cba5579", "Inacio Felipe Couto Ferreira", "inacio.felipe@planetshoes.com", "inacio", null, "Inacio" },
                    { "f9921ce6-ff36-4757-b3be-a7c7e53c45a2", "Luciano Antônio Ferreira", "luciano.ferreira@planetshoes.com", "luciano", null, "Luciano" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "UserId",
                keyValue: "9d340277-2ced-4037-84f4-c6fc2cba5579");

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "UserId",
                keyValue: "f9921ce6-ff36-4757-b3be-a7c7e53c45a2");
        }
    }
}
