using Microsoft.EntityFrameworkCore.Migrations;

namespace Comandante.Migrations
{
    public partial class CategoriaNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Productos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<long>(
                name: "IdCategoriaPadre",
                table: "Categorias",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Productos");

            migrationBuilder.AlterColumn<long>(
                name: "IdCategoriaPadre",
                table: "Categorias",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);
        }
    }
}
