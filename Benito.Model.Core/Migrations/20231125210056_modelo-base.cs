using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Benito.Model.Core.Migrations
{
    /// <inheritdoc />
    public partial class modelobase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Tipo",
                table: "Item",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Item",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "FecCrea",
                table: "Item",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FecModifica",
                table: "Item",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "McaActivo",
                table: "Item",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "McaEliminado",
                table: "Item",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UsuCrea",
                table: "Item",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UsuElimina",
                table: "Item",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UsuModifica",
                table: "Item",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Actuador",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo = table.Column<int>(type: "int", nullable: true),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    FecCrea = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FecModifica = table.Column<DateTime>(type: "datetime2", nullable: false),
                    McaActivo = table.Column<bool>(type: "bit", nullable: false),
                    McaEliminado = table.Column<bool>(type: "bit", nullable: false),
                    UsuCrea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuModifica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuElimina = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actuador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Huerto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FecCrea = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FecModifica = table.Column<DateTime>(type: "datetime2", nullable: false),
                    McaActivo = table.Column<bool>(type: "bit", nullable: false),
                    McaEliminado = table.Column<bool>(type: "bit", nullable: false),
                    UsuCrea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuModifica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuElimina = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Huerto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventarioBodega",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    FecCrea = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FecModifica = table.Column<DateTime>(type: "datetime2", nullable: false),
                    McaActivo = table.Column<bool>(type: "bit", nullable: false),
                    McaEliminado = table.Column<bool>(type: "bit", nullable: false),
                    UsuCrea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuModifica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuElimina = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventarioBodega", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemVenta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VentaId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    Detalle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    MontoNeto = table.Column<float>(type: "real", nullable: false),
                    MontoBruto = table.Column<float>(type: "real", nullable: false),
                    Iva = table.Column<float>(type: "real", nullable: false),
                    FecCrea = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FecModifica = table.Column<DateTime>(type: "datetime2", nullable: false),
                    McaActivo = table.Column<bool>(type: "bit", nullable: false),
                    McaEliminado = table.Column<bool>(type: "bit", nullable: false),
                    UsuCrea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuModifica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuElimina = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemVenta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plantacion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HuertoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Largo = table.Column<int>(type: "int", nullable: false),
                    Ancho = table.Column<int>(type: "int", nullable: false),
                    EspecieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaPlantacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaCosecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    CantidadCosechada = table.Column<int>(type: "int", nullable: false),
                    CantidadPendiente = table.Column<int>(type: "int", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FecCrea = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FecModifica = table.Column<DateTime>(type: "datetime2", nullable: false),
                    McaActivo = table.Column<bool>(type: "bit", nullable: false),
                    McaEliminado = table.Column<bool>(type: "bit", nullable: false),
                    UsuCrea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuModifica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuElimina = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plantacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resena = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodTipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    McaBorrador = table.Column<bool>(type: "bit", nullable: false),
                    CodigoBarra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Descuento = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Caracteristicas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FecCrea = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FecModifica = table.Column<DateTime>(type: "datetime2", nullable: false),
                    McaActivo = table.Column<bool>(type: "bit", nullable: false),
                    McaEliminado = table.Column<bool>(type: "bit", nullable: false),
                    UsuCrea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuModifica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuElimina = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sensor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo = table.Column<int>(type: "int", nullable: true),
                    TipoValor = table.Column<int>(type: "int", nullable: true),
                    FecCrea = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FecModifica = table.Column<DateTime>(type: "datetime2", nullable: false),
                    McaActivo = table.Column<bool>(type: "bit", nullable: false),
                    McaEliminado = table.Column<bool>(type: "bit", nullable: false),
                    UsuCrea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuModifica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuElimina = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    ProductoId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    FecCrea = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FecModifica = table.Column<DateTime>(type: "datetime2", nullable: false),
                    McaActivo = table.Column<bool>(type: "bit", nullable: false),
                    McaEliminado = table.Column<bool>(type: "bit", nullable: false),
                    UsuCrea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuModifica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuElimina = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventario_Producto_ProductoId1",
                        column: x => x.ProductoId1,
                        principalTable: "Producto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StockVenta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    FecCrea = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FecModifica = table.Column<DateTime>(type: "datetime2", nullable: false),
                    McaActivo = table.Column<bool>(type: "bit", nullable: false),
                    McaEliminado = table.Column<bool>(type: "bit", nullable: false),
                    UsuCrea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuModifica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuElimina = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockVenta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockVenta_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventario_ProductoId1",
                table: "Inventario",
                column: "ProductoId1");

            migrationBuilder.CreateIndex(
                name: "IX_StockVenta_ProductoId",
                table: "StockVenta",
                column: "ProductoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actuador");

            migrationBuilder.DropTable(
                name: "Huerto");

            migrationBuilder.DropTable(
                name: "Inventario");

            migrationBuilder.DropTable(
                name: "InventarioBodega");

            migrationBuilder.DropTable(
                name: "ItemVenta");

            migrationBuilder.DropTable(
                name: "Plantacion");

            migrationBuilder.DropTable(
                name: "Sensor");

            migrationBuilder.DropTable(
                name: "StockVenta");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropColumn(
                name: "FecCrea",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "FecModifica",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "McaActivo",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "McaEliminado",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "UsuCrea",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "UsuElimina",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "UsuModifica",
                table: "Item");

            migrationBuilder.AlterColumn<string>(
                name: "Tipo",
                table: "Item",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Item",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
