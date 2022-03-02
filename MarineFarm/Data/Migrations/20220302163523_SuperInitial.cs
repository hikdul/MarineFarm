using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarineFarm.Data.Migrations
{
    /// <summary>
    /// donde ingreso mas de un paso a lo ves
    /// </summary>
    public partial class SuperInitial : Migration
    {
        /// <summary>
        /// Up
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetUsuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    rut = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Userid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsuario", x => x.id);
                    table.ForeignKey(
                        name: "FK_AspNetUsuario_AspNetUsers_Userid",
                        column: x => x.Userid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Calibres",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    act = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calibres", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Empaquetados",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    act = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empaquetados", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Mariscos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    act = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mariscos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TiposProduccion",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    act = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposProduccion", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    act = table.Column<bool>(type: "bit", nullable: false),
                    Mariscoid = table.Column<int>(type: "int", nullable: false),
                    TipoProduccionid = table.Column<int>(type: "int", nullable: false),
                    Calibreid = table.Column<int>(type: "int", nullable: false),
                    Empaquetadoid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Productos_Calibres_Calibreid",
                        column: x => x.Calibreid,
                        principalTable: "Calibres",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productos_Empaquetados_Empaquetadoid",
                        column: x => x.Empaquetadoid,
                        principalTable: "Empaquetados",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productos_Mariscos_Mariscoid",
                        column: x => x.Mariscoid,
                        principalTable: "Mariscos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productos_TiposProduccion_TipoProduccionid",
                        column: x => x.TipoProduccionid,
                        principalTable: "TiposProduccion",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4d9bab5f-9c09-4d8a-b1a6-aadcd014a8a9", "a8ba4448-4313-426d-939d-bd3bfb100d00", "AdmoSistema", "ADMOSISTEMA" },
                    { "6e1b4175-cf9c-4fd2-ab0d-987f5af67434", "1f612377-9693-4f4b-9c67-85a5a75886a5", "Cliente", "CLIENTE" },
                    { "8f36838c-81ae-4d20-83a0-b867fd489771", "9b2ca63c-0775-4d88-8558-64ee0ab596a1", "Gerenteplanta", "GERENTEPLANTA" },
                    { "a6b2b621-d728-428e-a2be-bc8d30aed151", "7cecfe19-c86b-4e67-b615-058f35adf48f", "Superv", "SUPERV" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "445f6fc1-5dd4-4c32-af61-19a91b8f1367", 0, "4fe33ced-db51-45a5-bb0c-da209c48da73", "hikdul.dev@gmail.com", true, false, null, "HIKDUL.DEV@GMAIL.COM", "HIKDUL.DEV@GMAIL.COM", "AQAAAAEAACcQAAAAEP40pUAxaVddjvHTJxqrpAXRwtnyarejMTLBm3f3naznU853EDCoQftJ5VwTGqdTRQ==", "+51 931 084 717", true, "db56db34-986f-4188-aa1f-4e44ca6d3217", false, "hikdul.dev@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4d9bab5f-9c09-4d8a-b1a6-aadcd014a8a9", "445f6fc1-5dd4-4c32-af61-19a91b8f1367" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsuario_Userid",
                table: "AspNetUsuario",
                column: "Userid");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_Calibreid",
                table: "Productos",
                column: "Calibreid");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_Empaquetadoid",
                table: "Productos",
                column: "Empaquetadoid");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_Mariscoid",
                table: "Productos",
                column: "Mariscoid");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_TipoProduccionid",
                table: "Productos",
                column: "TipoProduccionid");
        }
        /// <summary>
        /// Down
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetUsuario");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Calibres");

            migrationBuilder.DropTable(
                name: "Empaquetados");

            migrationBuilder.DropTable(
                name: "Mariscos");

            migrationBuilder.DropTable(
                name: "TiposProduccion");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e1b4175-cf9c-4fd2-ab0d-987f5af67434");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f36838c-81ae-4d20-83a0-b867fd489771");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6b2b621-d728-428e-a2be-bc8d30aed151");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4d9bab5f-9c09-4d8a-b1a6-aadcd014a8a9", "445f6fc1-5dd4-4c32-af61-19a91b8f1367" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d9bab5f-9c09-4d8a-b1a6-aadcd014a8a9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "445f6fc1-5dd4-4c32-af61-19a91b8f1367");
        }
    }
}
