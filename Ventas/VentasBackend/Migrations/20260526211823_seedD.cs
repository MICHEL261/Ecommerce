using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VentasBackend.Migrations
{
    /// <inheritdoc />
    public partial class seedD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Tiendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TiendaId",
                table: "Tiendas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ordenes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ordenes_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdenesProductos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdenId = table.Column<int>(type: "int", nullable: false),
                    OrdenesId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenesProductos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdenesProductos_Ordenes_OrdenesId",
                        column: x => x.OrdenesId,
                        principalTable: "Ordenes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TiendaId = table.Column<int>(type: "int", nullable: false),
                    OrdenProductoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_OrdenesProductos_OrdenProductoId",
                        column: x => x.OrdenProductoId,
                        principalTable: "OrdenesProductos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productos_Tiendas_TiendaId",
                        column: x => x.TiendaId,
                        principalTable: "Tiendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tiendas_CategoriaId",
                table: "Tiendas",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tiendas_TiendaId",
                table: "Tiendas",
                column: "TiendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_ClienteId",
                table: "Ordenes",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesProductos_OrdenesId",
                table: "OrdenesProductos",
                column: "OrdenesId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_OrdenProductoId",
                table: "Productos",
                column: "OrdenProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_TiendaId",
                table: "Productos",
                column: "TiendaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tiendas_Categorias_CategoriaId",
                table: "Tiendas",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tiendas_Tiendas_TiendaId",
                table: "Tiendas",
                column: "TiendaId",
                principalTable: "Tiendas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tiendas_Categorias_CategoriaId",
                table: "Tiendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tiendas_Tiendas_TiendaId",
                table: "Tiendas");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "OrdenesProductos");

            migrationBuilder.DropTable(
                name: "Ordenes");

            migrationBuilder.DropIndex(
                name: "IX_Tiendas_CategoriaId",
                table: "Tiendas");

            migrationBuilder.DropIndex(
                name: "IX_Tiendas_TiendaId",
                table: "Tiendas");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Tiendas");

            migrationBuilder.DropColumn(
                name: "TiendaId",
                table: "Tiendas");
        }
    }
}
