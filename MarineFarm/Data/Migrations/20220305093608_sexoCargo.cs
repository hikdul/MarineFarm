using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarineFarm.Data.Migrations
{
    public partial class sexoCargo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "sexo",
                table: "Cargos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sexo",
                table: "Cargos");
        }
    }
}
