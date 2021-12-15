using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudTask1.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Cnid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Cnid);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Did = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Did);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Sid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryCnid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Sid);
                    table.ForeignKey(
                        name: "FK_States_Countries_CountryCnid",
                        column: x => x.CountryCnid,
                        principalTable: "Countries",
                        principalColumn: "Cnid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CtId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateSid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CtId);
                    table.ForeignKey(
                        name: "FK_Cities_States_StateSid",
                        column: x => x.StateSid,
                        principalTable: "States",
                        principalColumn: "Sid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Aid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pincode = table.Column<int>(type: "int", nullable: false),
                    CityCtId = table.Column<int>(type: "int", nullable: true),
                    StateSid = table.Column<int>(type: "int", nullable: true),
                    CountryCnid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Aid);
                    table.ForeignKey(
                        name: "FK_Addresses_Cities_CityCtId",
                        column: x => x.CityCtId,
                        principalTable: "Cities",
                        principalColumn: "CtId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_Countries_CountryCnid",
                        column: x => x.CountryCnid,
                        principalTable: "Countries",
                        principalColumn: "Cnid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_States_StateSid",
                        column: x => x.StateSid,
                        principalTable: "States",
                        principalColumn: "Sid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentDid = table.Column<int>(type: "int", nullable: true),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    AddressAid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.id);
                    table.ForeignKey(
                        name: "FK_Employees_Addresses_AddressAid",
                        column: x => x.AddressAid,
                        principalTable: "Addresses",
                        principalColumn: "Aid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentDid",
                        column: x => x.DepartmentDid,
                        principalTable: "Departments",
                        principalColumn: "Did",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityCtId",
                table: "Addresses",
                column: "CityCtId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CountryCnid",
                table: "Addresses",
                column: "CountryCnid");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StateSid",
                table: "Addresses",
                column: "StateSid");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateSid",
                table: "Cities",
                column: "StateSid");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AddressAid",
                table: "Employees",
                column: "AddressAid");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentDid",
                table: "Employees",
                column: "DepartmentDid");

            migrationBuilder.CreateIndex(
                name: "IX_States_CountryCnid",
                table: "States",
                column: "CountryCnid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
