using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionPedidosAPI.Migrations
{
    /// <inheritdoc />
    public partial class VendedorYEncargadoNulables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineasPedido_AspNetUsers_IDEncargado",
                table: "LineasPedido");

            migrationBuilder.DropIndex(
                name: "IX_LineasPedido_IDEncargado",
                table: "LineasPedido");

            migrationBuilder.DropColumn(
                name: "IDEncargado",
                table: "LineasPedido");

            migrationBuilder.AlterColumn<string>(
                name: "Vendedor",
                table: "Pedidos",
                type: "nvarchar(30)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)");

            migrationBuilder.AlterColumn<int>(
                name: "TipoGrabado",
                table: "LineasPedido",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "EncargadoID",
                table: "LineasPedido",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LineasPedido_EncargadoID",
                table: "LineasPedido",
                column: "EncargadoID");

            migrationBuilder.AddForeignKey(
                name: "FK_LineasPedido_AspNetUsers_EncargadoID",
                table: "LineasPedido",
                column: "EncargadoID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineasPedido_AspNetUsers_EncargadoID",
                table: "LineasPedido");

            migrationBuilder.DropIndex(
                name: "IX_LineasPedido_EncargadoID",
                table: "LineasPedido");

            migrationBuilder.DropColumn(
                name: "EncargadoID",
                table: "LineasPedido");

            migrationBuilder.AlterColumn<string>(
                name: "Vendedor",
                table: "Pedidos",
                type: "nvarchar(30)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TipoGrabado",
                table: "LineasPedido",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IDEncargado",
                table: "LineasPedido",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_LineasPedido_IDEncargado",
                table: "LineasPedido",
                column: "IDEncargado");

            migrationBuilder.AddForeignKey(
                name: "FK_LineasPedido_AspNetUsers_IDEncargado",
                table: "LineasPedido",
                column: "IDEncargado",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
