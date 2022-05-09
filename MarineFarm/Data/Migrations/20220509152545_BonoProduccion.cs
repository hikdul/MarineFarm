using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarineFarm.Data.Migrations
{
    /// <summary>
    /// para agregar el bono de produccion como un parametro extra
    /// </summary>
    public partial class BonoProduccion : Migration
    {
        /// <summary>
        /// up
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KgBono",
                table: "Config");

            migrationBuilder.DropColumn(
                name: "PagoBono",
                table: "Config");

            migrationBuilder.AddColumn<int>(
                name: "Bonoid",
                table: "Equipos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Bonos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    act = table.Column<bool>(type: "bit", nullable: false),
                    Kilogramos = table.Column<double>(type: "float", nullable: false),
                    Pago = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bonos", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_Bonoid",
                table: "Equipos",
                column: "Bonoid");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipos_Bonos_Bonoid",
                table: "Equipos",
                column: "Bonoid",
                principalTable: "Bonos",
                principalColumn: "id");
        }
        /// <summary>
        /// Down
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipos_Bonos_Bonoid",
                table: "Equipos");

            migrationBuilder.DropTable(
                name: "Bonos");

            migrationBuilder.DropIndex(
                name: "IX_Equipos_Bonoid",
                table: "Equipos");

            migrationBuilder.DropColumn(
                name: "Bonoid",
                table: "Equipos");

            migrationBuilder.AddColumn<double>(
                name: "KgBono",
                table: "Config",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PagoBono",
                table: "Config",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
