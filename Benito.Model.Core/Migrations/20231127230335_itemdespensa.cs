using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Benito.Model.Core.Migrations
{
    /// <inheritdoc />
    public partial class itemdespensa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.CreateTable(
                name: "ItemDespensa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnStock = table.Column<bool>(type: "bit", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    FecCrea = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FecModifica = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FecElimina = table.Column<DateTime>(type: "datetime2", nullable: true),
                    McaActivo = table.Column<bool>(type: "bit", nullable: false),
                    McaEliminado = table.Column<bool>(type: "bit", nullable: true),
                    UsuCrea = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuModifica = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UsuElimina = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDespensa", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemDespensa");

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    EnStock = table.Column<bool>(type: "bit", nullable: false),
                    FecCrea = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FecElimina = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FecModifica = table.Column<DateTime>(type: "datetime2", nullable: true),
                    McaActivo = table.Column<bool>(type: "bit", nullable: false),
                    McaEliminado = table.Column<bool>(type: "bit", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuCrea = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuElimina = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UsuModifica = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                });
        }
    }
}
