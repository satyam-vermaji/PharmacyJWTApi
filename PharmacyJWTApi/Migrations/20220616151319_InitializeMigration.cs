using Microsoft.EntityFrameworkCore.Migrations;

namespace PharmacyJWTApi.Migrations
{
    public partial class InitializeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetails", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "UserDetails",
                columns: new[] { "UserId", "Address", "Age", "Email", "Password", "PhoneNumber", "RoleId", "UserName" },
                values: new object[] { 1, "sector 25 nagloi delhi", 20, "varun@abc.com", "varum@1234", "9897124588", 1, "varun" });

            migrationBuilder.InsertData(
                table: "UserDetails",
                columns: new[] { "UserId", "Address", "Age", "Email", "Password", "PhoneNumber", "RoleId", "UserName" },
                values: new object[] { 2, "sector 20 nagloi delhi", 22, "Nikhil@abc.com", "Nikhil@1234", "9897125599", 2, "Nikhil" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDetails");
        }
    }
}
