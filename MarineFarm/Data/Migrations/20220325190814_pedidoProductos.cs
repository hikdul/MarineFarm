using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarineFarm.Data.Migrations
{
    /// <summary>
    /// pedido de productos
    /// </summary>
    public partial class pedidoProductos : Migration
    {
        /// <summary>
        /// Up
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PP",
                columns: table => new
                {
                    pedidoid = table.Column<int>(type: "int", nullable: false),
                    Productoid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PP", x => new { x.pedidoid, x.Productoid });
                    table.ForeignKey(
                        name: "FK_PP_Pedidos_pedidoid",
                        column: x => x.pedidoid,
                        principalTable: "Pedidos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PP_Productos_Productoid",
                        column: x => x.Productoid,
                        principalTable: "Productos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PP_Productoid",
                table: "PP",
                column: "Productoid");
        }
        /// <summary>
        /// Down
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PP");
        }
    }
}
