using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionPedidosAPI.Migrations
{
    /// <inheritdoc />
    public partial class PagoDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePropietarioTarjeta = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    NumeroTarjeta = table.Column<string>(type: "nvarchar(16)", nullable: false),
                    FechaCaducidad = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodigoSeguridad = table.Column<string>(type: "nvarchar(3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pagos");
        }
    }
}
