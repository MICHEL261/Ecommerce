using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VentasBackend.Migrations
{
    /// <inheritdoc />
    public partial class aa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tiendas_Tiendas_TiendaId",
                table: "Tiendas");

            migrationBuilder.DropIndex(
                name: "IX_Tiendas_TiendaId",
                table: "Tiendas");

            migrationBuilder.DropColumn(
                name: "TiendaId",
                table: "Tiendas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TiendaId",
                table: "Tiendas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tiendas_TiendaId",
                table: "Tiendas",
                column: "TiendaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tiendas_Tiendas_TiendaId",
                table: "Tiendas",
                column: "TiendaId",
                principalTable: "Tiendas",
                principalColumn: "Id");
        }
    }
}
