using Microsoft.EntityFrameworkCore.Migrations;

namespace MigrationTableNames.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Information = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerServiceGrouping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerServiceGrouping", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerServiceClientGrouping",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    GroupingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerServiceClientGrouping", x => new { x.ClientId, x.GroupingId });
                    table.ForeignKey(
                        name: "FK_CustomerServiceClientGrouping_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerServiceClientGrouping_CustomerServiceGrouping_GroupingId",
                        column: x => x.GroupingId,
                        principalTable: "CustomerServiceGrouping",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientUser (Dictionary<string, object>)",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientUser (Dictionary<string, object>)", x => new { x.ClientId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ClientUser (Dictionary<string, object>)_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientUser (Dictionary<string, object>)_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientUser (Dictionary<string, object>)_UserId",
                table: "ClientUser (Dictionary<string, object>)",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerServiceClientGrouping_GroupingId",
                table: "CustomerServiceClientGrouping",
                column: "GroupingId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerServiceGrouping_Name",
                table: "CustomerServiceGrouping",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientUser (Dictionary<string, object>)");

            migrationBuilder.DropTable(
                name: "CustomerServiceClientGrouping");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "CustomerServiceGrouping");
        }
    }
}
