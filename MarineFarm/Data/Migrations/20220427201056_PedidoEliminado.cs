using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarineFarm.Data.Migrations
{
    /// <summary>
    /// para agregar la tabla de pedidos eliminados
    /// </summary>
    public partial class PedidoEliminado : Migration
    {
        /// <summary>
        /// Up
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PedidosEliminados",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Razon = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Eliminadoid = table.Column<int>(type: "int", nullable: false),
                    QuienEliminoid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidosEliminados", x => x.id);
                    table.ForeignKey(
                        name: "FK_PedidosEliminados_AspNetUsuario_QuienEliminoid",
                        column: x => x.QuienEliminoid,
                        principalTable: "AspNetUsuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PedidosEliminados_Pedidos_Eliminadoid",
                        column: x => x.Eliminadoid,
                        principalTable: "Pedidos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PedidosEliminados_Eliminadoid",
                table: "PedidosEliminados",
                column: "Eliminadoid");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosEliminados_QuienEliminoid",
                table: "PedidosEliminados",
                column: "QuienEliminoid");
        }
        /// <summary>
        /// Down
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidosEliminados");
        }
    }
}
