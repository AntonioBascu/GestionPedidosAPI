using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionPedidosAPI.Migrations
{
    /// <inheritdoc />
    public partial class ClienteUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineasPedido_Usuarios_ModificadoPorID",
                table: "LineasPedido");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_IdCliente",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Usuarios_CreadoPorID",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Usuarios_ModificadoPorID",
                table: "Pedidos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.AlterColumn<string>(
                name: "ModificadoPorID",
                table: "Pedidos",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "IdCliente",
                table: "Pedidos",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CreadoPorID",
                table: "Pedidos",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ModificadoPorID",
                table: "LineasPedido",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

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
                name: "FK_LineasPedido_AspNetUsers_ModificadoPorID",
                table: "LineasPedido",
                column: "ModificadoPorID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_AspNetUsers_CreadoPorID",
                table: "Pedidos",
                column: "CreadoPorID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_AspNetUsers_IdCliente",
                table: "Pedidos",
                column: "IdCliente",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_AspNetUsers_ModificadoPorID",
                table: "Pedidos",
                column: "ModificadoPorID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineasPedido_AspNetUsers_ModificadoPorID",
                table: "LineasPedido");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_AspNetUsers_CreadoPorID",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_AspNetUsers_IdCliente",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_AspNetUsers_ModificadoPorID",
                table: "Pedidos");

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
                name: "Discriminator",
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

            migrationBuilder.AlterColumn<int>(
                name: "ModificadoPorID",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdCliente",
                table: "Pedidos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "CreadoPorID",
                table: "Pedidos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "ModificadoPorID",
                table: "LineasPedido",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(6)", nullable: false),
                    Domicilio = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    NombreComercial = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Poblacion = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Provincia = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    RazonSocial = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(12)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Taller = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_LineasPedido_Usuarios_ModificadoPorID",
                table: "LineasPedido",
                column: "ModificadoPorID",
                principalTable: "Usuarios",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_IdCliente",
                table: "Pedidos",
                column: "IdCliente",
                principalTable: "Clientes",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Usuarios_CreadoPorID",
                table: "Pedidos",
                column: "CreadoPorID",
                principalTable: "Usuarios",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Usuarios_ModificadoPorID",
                table: "Pedidos",
                column: "ModificadoPorID",
                principalTable: "Usuarios",
                principalColumn: "ID");
        }
    }
}
