using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Benito.Model.Core.Migrations
{
    /// <inheritdoc />
    public partial class producto8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Categoría",
                table: "Producto",
                newName: "CodCategoría");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CodCategoría",
                table: "Producto",
                newName: "Categoría");
        }
    }
}
