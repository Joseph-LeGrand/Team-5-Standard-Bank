using Microsoft.EntityFrameworkCore.Migrations;

namespace Dummy.Migrations
{
    public partial class renamedTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DummyModel",
                table: "DummyModel");

            migrationBuilder.RenameTable(
                name: "DummyModel",
                newName: "DummyModel");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "DummyModel",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DummyModel",
                table: "DummyModel",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DummyModel",
                table: "DummyModel");

            migrationBuilder.RenameTable(
                name: "DummyModel",
                newName: "DummyModel");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "DummyModel",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_DummyModel",
                table: "DummyModel",
                column: "Id");
        }
    }
}
