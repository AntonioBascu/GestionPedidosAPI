using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionPedidosAPI.Migrations
{
    /// <inheritdoc />
    public partial class EntidadCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_AspNetUsers_IdCliente",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "DosCaras",
                table: "LineasPedido");

            migrationBuilder.DropColumn(
                name: "AñoAntiguedad",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CodigoCliente",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CodigoPostal",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Domicilio",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NombreComercial",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Poblacion",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Provincia",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RazonSocial",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "IdCliente",
                table: "Pedidos",
                newName: "IDCliente");

            migrationBuilder.RenameIndex(
                name: "IX_Pedidos_IdCliente",
                table: "Pedidos",
                newName: "IX_Pedidos_IDCliente");

            migrationBuilder.AlterColumn<int>(
                name: "IDCliente",
                table: "Pedidos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "IDEncargado",
                table: "LineasPedido",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CodigoCliente = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Domicilio = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Poblacion = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Provincia = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(6)", nullable: false),
                    AñoAntiguedad = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ID);
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_IDCliente",
                table: "Pedidos",
                column: "IDCliente",
                principalTable: "Clientes",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineasPedido_AspNetUsers_IDEncargado",
                table: "LineasPedido");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_IDCliente",
                table: "Pedidos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_LineasPedido_IDEncargado",
                table: "LineasPedido");

            migrationBuilder.DropColumn(
                name: "IDEncargado",
                table: "LineasPedido");

            migrationBuilder.RenameColumn(
                name: "IDCliente",
                table: "Pedidos",
                newName: "IdCliente");

            migrationBuilder.RenameIndex(
                name: "IX_Pedidos_IDCliente",
                table: "Pedidos",
                newName: "IX_Pedidos_IdCliente");

            migrationBuilder.AlterColumn<string>(
                name: "IdCliente",
                table: "Pedidos",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "DosCaras",
                table: "LineasPedido",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "AñoAntiguedad",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodigoCliente",
                table: "AspNetUsers",
                type: "nvarchar(25)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodigoPostal",
                table: "AspNetUsers",
                type: "nvarchar(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Domicilio",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NombreComercial",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Poblacion",
                table: "AspNetUsers",
                type: "nvarchar(30)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Provincia",
                table: "AspNetUsers",
                type: "nvarchar(30)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RazonSocial",
                table: "AspNetUsers",
                type: "nvarchar(150)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_AspNetUsers_IdCliente",
                table: "Pedidos",
                column: "IdCliente",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
