using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarineFarm.Data.Migrations
{
    /// <summary>
    /// pedido ingreso cantidades
    /// </summary>
    public partial class pedido3 : Migration
    {
        /// <summary>
        /// Up
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Cantidad",
                table: "PP",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
        /// <summary>
        /// down
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "PP");
        }
    }
}
