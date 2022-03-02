using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarineFarm.Data.Migrations
{
    /// <summary>
    /// Migracion donde se agregan las tablas involucrada en la produccion
    /// </summary>
    public partial class Produccion : Migration
    {
        /// <summary>
        /// Up
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produccion",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Supervid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produccion", x => x.id);
                    table.ForeignKey(
                        name: "FK_Produccion_AspNetUsuario_Supervid",
                        column: x => x.Supervid,
                        principalTable: "AspNetUsuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MariscoProduccion",
                columns: table => new
                {
                    Mariscoid = table.Column<int>(type: "int", nullable: false),
                    Produccionid = table.Column<int>(type: "int", nullable: false),
                    CantidadUtilizada = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MariscoProduccion", x => new { x.Produccionid, x.Mariscoid });
                    table.ForeignKey(
                        name: "FK_MariscoProduccion_Mariscos_Mariscoid",
                        column: x => x.Mariscoid,
                        principalTable: "Mariscos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MariscoProduccion_Produccion_Produccionid",
                        column: x => x.Produccionid,
                        principalTable: "Produccion",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductoProduccion",
                columns: table => new
                {
                    Produccionid = table.Column<int>(type: "int", nullable: false),
                    Productoid = table.Column<int>(type: "int", nullable: false),
                    CantidadProducida = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoProduccion", x => new { x.Produccionid, x.Productoid });
                    table.ForeignKey(
                        name: "FK_ProductoProduccion_Produccion_Produccionid",
                        column: x => x.Produccionid,
                        principalTable: "Produccion",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductoProduccion_Productos_Productoid",
                        column: x => x.Productoid,
                        principalTable: "Productos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MariscoProduccion_Mariscoid",
                table: "MariscoProduccion",
                column: "Mariscoid");

            migrationBuilder.CreateIndex(
                name: "IX_Produccion_Supervid",
                table: "Produccion",
                column: "Supervid");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoProduccion_Productoid",
                table: "ProductoProduccion",
                column: "Productoid");
        }
        /// <summary>
        /// Down
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MariscoProduccion");

            migrationBuilder.DropTable(
                name: "ProductoProduccion");

            migrationBuilder.DropTable(
                name: "Produccion");
        }
    }
}
