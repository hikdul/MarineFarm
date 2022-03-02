using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarineFarm.Data.Migrations
{
    /// <summary>
    /// Migracion que crea los contenedores para el stock
    /// </summary>
    public partial class stock : Migration
    {
        /// <summary>
        ///  Up
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.CreateTable(
                name: "Almacen",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<double>(type: "float", nullable: false),
                    Productoid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Almacen", x => x.id);
                    table.ForeignKey(
                        name: "FK_Almacen_Productos_Productoid",
                        column: x => x.Productoid,
                        principalTable: "Productos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistorialMateriaPrima",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mariscoid = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<double>(type: "float", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Usuarioid = table.Column<int>(type: "int", nullable: false),
                    Ingreso = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialMateriaPrima", x => x.id);
                    table.ForeignKey(
                        name: "FK_HistorialMateriaPrima_AspNetUsuario_Usuarioid",
                        column: x => x.Usuarioid,
                        principalTable: "AspNetUsuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistorialMateriaPrima_Mariscos_Mariscoid",
                        column: x => x.Mariscoid,
                        principalTable: "Mariscos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MateriasPrimas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mariscoid = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MateriasPrimas", x => x.id);
                    table.ForeignKey(
                        name: "FK_MateriasPrimas_Mariscos_Mariscoid",
                        column: x => x.Mariscoid,
                        principalTable: "Mariscos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Almacen_Productoid",
                table: "Almacen",
                column: "Productoid");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialMateriaPrima_Mariscoid",
                table: "HistorialMateriaPrima",
                column: "Mariscoid");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialMateriaPrima_Usuarioid",
                table: "HistorialMateriaPrima",
                column: "Usuarioid");

            migrationBuilder.CreateIndex(
                name: "IX_MateriasPrimas_Mariscoid",
                table: "MateriasPrimas",
                column: "Mariscoid");
        }
        /// <summary>
        /// Down
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Almacen");

            migrationBuilder.DropTable(
                name: "HistorialMateriaPrima");

            migrationBuilder.DropTable(
                name: "MateriasPrimas");

           
        }
    }
}
