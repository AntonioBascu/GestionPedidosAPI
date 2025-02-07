using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionPedidosAPI.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articulos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    Referencia = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    PrecioSinIva = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    RazonSocial = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    NombreComercial = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(12)", nullable: false),
                    Poblacion = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Provincia = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Domicilio = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(6)", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Creado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreadoPorID = table.Column<int>(type: "int", nullable: false),
                    Modificado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPorID = table.Column<int>(type: "int", nullable: false),
                    EntregaMax = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    Vendedor = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Pedidos_Usuarios_CreadoPorID",
                        column: x => x.CreadoPorID,
                        principalTable: "Usuarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedidos_Usuarios_ModificadoPorID",
                        column: x => x.ModificadoPorID,
                        principalTable: "Usuarios",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "LineasPedido",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDPedido = table.Column<int>(type: "int", nullable: false),
                    IDArticulo = table.Column<int>(type: "int", nullable: false),
                    TipoGrabado = table.Column<int>(type: "int", nullable: false),
                    Tinta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DosCaras = table.Column<bool>(type: "bit", nullable: false),
                    SituacionGrabacion = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Modificado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineasPedido", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LineasPedido_Articulos_IDArticulo",
                        column: x => x.IDArticulo,
                        principalTable: "Articulos",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_LineasPedido_Pedidos_IDPedido",
                        column: x => x.IDPedido,
                        principalTable: "Pedidos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineasPedido_Usuarios_ModificadoPorID",
                        column: x => x.ModificadoPorID,
                        principalTable: "Usuarios",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LineasPedido_IDArticulo",
                table: "LineasPedido",
                column: "IDArticulo");

            migrationBuilder.CreateIndex(
                name: "IX_LineasPedido_IDPedido",
                table: "LineasPedido",
                column: "IDPedido");

            migrationBuilder.CreateIndex(
                name: "IX_LineasPedido_ModificadoPorID",
                table: "LineasPedido",
                column: "ModificadoPorID");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_CreadoPorID",
                table: "Pedidos",
                column: "CreadoPorID");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_IdCliente",
                table: "Pedidos",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ModificadoPorID",
                table: "Pedidos",
                column: "ModificadoPorID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LineasPedido");

            migrationBuilder.DropTable(
                name: "Articulos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
