using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class GUID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AFullName",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AFullName",
                table: "Authors");
        }
    }
}
