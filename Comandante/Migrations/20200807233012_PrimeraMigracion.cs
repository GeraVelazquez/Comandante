using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Comandante.Migrations
{
    public partial class PrimeraMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AreasServicio",
                columns: table => new
                {
                    IdArea = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    Activo = table.Column<bool>(nullable: false),
                    IdUsuarioCreo = table.Column<long>(nullable: false),
                    FechaCreo = table.Column<DateTime>(nullable: false),
                    IdUsuarioModifico = table.Column<long>(nullable: true),
                    FechaModifico = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreasServicio", x => x.IdArea);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    IdCategoria = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCategoriaPadre = table.Column<long>(nullable: false),
                    IdAreaServicio = table.Column<long>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    RGBIdentificador = table.Column<string>(maxLength: 50, nullable: true),
                    Icono = table.Column<string>(maxLength: 50, nullable: true),
                    Activo = table.Column<bool>(nullable: false),
                    IdUsuarioCreo = table.Column<long>(nullable: false),
                    FechaCreo = table.Column<DateTime>(nullable: false),
                    IdUsuarioModifico = table.Column<long>(nullable: true),
                    FechaModifico = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    IdProducto = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCategoria = table.Column<long>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 50, nullable: true),
                    Descripcion = table.Column<string>(maxLength: 150, nullable: true),
                    PrecioVenta = table.Column<double>(nullable: false),
                    CostoPreparacion = table.Column<double>(nullable: false),
                    MinsPreparacion = table.Column<int>(nullable: false),
                    IdUsuarioCreo = table.Column<long>(nullable: false),
                    FechaCreo = table.Column<DateTime>(nullable: false),
                    IdUsuarioModifico = table.Column<long>(nullable: true),
                    FechaModifico = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.IdProducto);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AreasServicio");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
