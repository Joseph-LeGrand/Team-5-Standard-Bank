using Microsoft.EntityFrameworkCore.Migrations;

namespace Dummy.Migrations
{
    public partial class SaltHash : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "DummyModel",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salt",
                table: "DummyModel");
        }
    }
}
