using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarineFarm.Data.Migrations
{
    /// <summary>
    /// Para almacenar la tabla de configuraciones
    /// </summary>
    public partial class config : Migration
    {
        /// <summary>
        /// Up
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Config",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiasHabiles = table.Column<int>(type: "int", nullable: false),
                    ProduccionDefaultPorDia = table.Column<double>(type: "float", nullable: false),
                    KgBono = table.Column<double>(type: "float", nullable: false),
                    PagoBono = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Config", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MuestrasDiarias_Calibreid",
                table: "MuestrasDiarias",
                column: "Calibreid");

            migrationBuilder.CreateIndex(
                name: "IX_MuestrasDiarias_Empaquetadoid",
                table: "MuestrasDiarias",
                column: "Empaquetadoid");

            migrationBuilder.CreateIndex(
                name: "IX_MuestrasDiarias_Mariscoid",
                table: "MuestrasDiarias",
                column: "Mariscoid");

            migrationBuilder.CreateIndex(
                name: "IX_MuestrasDiarias_TipoProduccionid",
                table: "MuestrasDiarias",
                column: "TipoProduccionid");

            migrationBuilder.AddForeignKey(
                name: "FK_MuestrasDiarias_Calibres_Calibreid",
                table: "MuestrasDiarias",
                column: "Calibreid",
                principalTable: "Calibres",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MuestrasDiarias_Empaquetados_Empaquetadoid",
                table: "MuestrasDiarias",
                column: "Empaquetadoid",
                principalTable: "Empaquetados",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MuestrasDiarias_Mariscos_Mariscoid",
                table: "MuestrasDiarias",
                column: "Mariscoid",
                principalTable: "Mariscos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MuestrasDiarias_TiposProduccion_TipoProduccionid",
                table: "MuestrasDiarias",
                column: "TipoProduccionid",
                principalTable: "TiposProduccion",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
        /// <summary>
        /// Down
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MuestrasDiarias_Calibres_Calibreid",
                table: "MuestrasDiarias");

            migrationBuilder.DropForeignKey(
                name: "FK_MuestrasDiarias_Empaquetados_Empaquetadoid",
                table: "MuestrasDiarias");

            migrationBuilder.DropForeignKey(
                name: "FK_MuestrasDiarias_Mariscos_Mariscoid",
                table: "MuestrasDiarias");

            migrationBuilder.DropForeignKey(
                name: "FK_MuestrasDiarias_TiposProduccion_TipoProduccionid",
                table: "MuestrasDiarias");

            migrationBuilder.DropTable(
                name: "Config");

            migrationBuilder.DropIndex(
                name: "IX_MuestrasDiarias_Calibreid",
                table: "MuestrasDiarias");

            migrationBuilder.DropIndex(
                name: "IX_MuestrasDiarias_Empaquetadoid",
                table: "MuestrasDiarias");

            migrationBuilder.DropIndex(
                name: "IX_MuestrasDiarias_Mariscoid",
                table: "MuestrasDiarias");

            migrationBuilder.DropIndex(
                name: "IX_MuestrasDiarias_TipoProduccionid",
                table: "MuestrasDiarias");
        }
    }
}
