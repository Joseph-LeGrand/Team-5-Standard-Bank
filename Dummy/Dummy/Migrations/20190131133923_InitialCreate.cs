using Microsoft.EntityFrameworkCore.Migrations;

namespace Dummy.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DummyModel",
                table: "DummyModel");

            migrationBuilder.RenameTable(
                name: "DummyModel",
                newName: "UserTest");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTest",
                table: "UserTest",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTest",
                table: "UserTest");

            migrationBuilder.RenameTable(
                name: "UserTest",
                newName: "DummyModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DummyModel",
                table: "DummyModel",
                column: "Id");
        }
    }
}
