using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionPedidosAPI.Migrations
{
    /// <inheritdoc />
    public partial class ArticuloLineaPedidoString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineasPedido_Articulos_IDArticulo",
                table: "LineasPedido");

            migrationBuilder.DropIndex(
                name: "IX_LineasPedido_IDArticulo",
                table: "LineasPedido");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Articulos",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "IDArticulo",
                table: "LineasPedido");

            migrationBuilder.RenameTable(
                name: "Articulos",
                newName: "Articulo");

            migrationBuilder.AddColumn<string>(
                name: "Articulo",
                table: "LineasPedido",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Articulo",
                table: "Articulo",
                column: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Articulo",
                table: "Articulo");

            migrationBuilder.DropColumn(
                name: "Articulo",
                table: "LineasPedido");

            migrationBuilder.RenameTable(
                name: "Articulo",
                newName: "Articulos");

            migrationBuilder.AddColumn<int>(
                name: "IDArticulo",
                table: "LineasPedido",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Articulos",
                table: "Articulos",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_LineasPedido_IDArticulo",
                table: "LineasPedido",
                column: "IDArticulo");

            migrationBuilder.AddForeignKey(
                name: "FK_LineasPedido_Articulos_IDArticulo",
                table: "LineasPedido",
                column: "IDArticulo",
                principalTable: "Articulos",
                principalColumn: "ID");
        }
    }
}
