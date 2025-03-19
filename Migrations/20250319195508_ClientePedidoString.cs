using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionPedidosAPI.Migrations
{
    /// <inheritdoc />
    public partial class ClientePedidoString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_IDCliente",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_IDCliente",
                table: "Pedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "IDCliente",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Precio",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "PrecioSinIva",
                table: "Articulos");

            migrationBuilder.RenameTable(
                name: "Clientes",
                newName: "Cliente");

            migrationBuilder.RenameColumn(
                name: "AñoAntiguedad",
                table: "Cliente",
                newName: "AnoAntiguedad");

            migrationBuilder.AlterColumn<string>(
                name: "Vendedor",
                table: "Pedidos",
                type: "nvarchar(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)");

            migrationBuilder.AddColumn<string>(
                name: "Cliente",
                table: "Pedidos",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Tinta",
                table: "LineasPedido",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SituacionGrabacion",
                table: "LineasPedido",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AddColumn<DateTime>(
                name: "Creado",
                table: "LineasPedido",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreadoPorID",
                table: "LineasPedido",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Stock",
                table: "Articulos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Referencia",
                table: "Articulos",
                type: "nvarchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Articulos",
                type: "nvarchar(25)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Precio",
                table: "Articulos",
                type: "decimal(3,2)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_LineasPedido_CreadoPorID",
                table: "LineasPedido",
                column: "CreadoPorID");

            migrationBuilder.AddForeignKey(
                name: "FK_LineasPedido_AspNetUsers_CreadoPorID",
                table: "LineasPedido",
                column: "CreadoPorID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineasPedido_AspNetUsers_CreadoPorID",
                table: "LineasPedido");

            migrationBuilder.DropIndex(
                name: "IX_LineasPedido_CreadoPorID",
                table: "LineasPedido");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Cliente",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Creado",
                table: "LineasPedido");

            migrationBuilder.DropColumn(
                name: "CreadoPorID",
                table: "LineasPedido");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "Precio",
                table: "Articulos");

            migrationBuilder.RenameTable(
                name: "Cliente",
                newName: "Clientes");

            migrationBuilder.RenameColumn(
                name: "AnoAntiguedad",
                table: "Clientes",
                newName: "AñoAntiguedad");

            migrationBuilder.AlterColumn<string>(
                name: "Vendedor",
                table: "Pedidos",
                type: "nvarchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)");

            migrationBuilder.AddColumn<int>(
                name: "IDCliente",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Precio",
                table: "Pedidos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "Tinta",
                table: "LineasPedido",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SituacionGrabacion",
                table: "LineasPedido",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Stock",
                table: "Articulos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Referencia",
                table: "Articulos",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "Articulos",
                type: "nvarchar(25)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PrecioSinIva",
                table: "Articulos",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_IDCliente",
                table: "Pedidos",
                column: "IDCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_IDCliente",
                table: "Pedidos",
                column: "IDCliente",
                principalTable: "Clientes",
                principalColumn: "ID");
        }
    }
}
