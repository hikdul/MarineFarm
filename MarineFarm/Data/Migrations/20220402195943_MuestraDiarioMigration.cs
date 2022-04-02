using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarineFarm.Data.Migrations
{
    /// <summary>
    /// para crear la tabla de muestras diarias
    /// </summary>
    public partial class MuestraDiarioMigration : Migration
    {
        /// <summary>
        /// up
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MuestrasDiarias",
                columns: table => new
                {
                    mes = table.Column<int>(type: "int", nullable: false),
                    ano = table.Column<int>(type: "int", nullable: false),
                    Mariscoid = table.Column<int>(type: "int", nullable: false),
                    TipoProduccionid = table.Column<int>(type: "int", nullable: false),
                    Calibreid = table.Column<int>(type: "int", nullable: false),
                    Empaquetadoid = table.Column<int>(type: "int", nullable: false),
                    TotalProducido = table.Column<double>(type: "float", nullable: false),
                    ProduccionDiaria = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuestrasDiarias", x => new { x.ano, x.mes, x.Mariscoid, x.TipoProduccionid, x.Calibreid, x.Empaquetadoid });
                });
        }
        /// <summary>
        /// down
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MuestrasDiarias");
        }
    }
}
