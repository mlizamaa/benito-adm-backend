using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Benito.Model.Core.Migrations
{
    /// <inheritdoc />
    public partial class producto3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Caracteristicas",
                table: "Producto",
                newName: "PuntosDestacadosJson");

            migrationBuilder.AlterColumn<Guid>(
                name: "CodTipo",
                table: "Producto",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CaracteristicasJson",
                table: "Producto",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Categoría",
                table: "Producto",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "McaDescuento",
                table: "Producto",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaTitulo",
                table: "Producto",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CaracteristicasJson",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "Categoría",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "McaDescuento",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "MetaTitulo",
                table: "Producto");

            migrationBuilder.RenameColumn(
                name: "PuntosDestacadosJson",
                table: "Producto",
                newName: "Caracteristicas");

            migrationBuilder.AlterColumn<string>(
                name: "CodTipo",
                table: "Producto",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }
    }
}
