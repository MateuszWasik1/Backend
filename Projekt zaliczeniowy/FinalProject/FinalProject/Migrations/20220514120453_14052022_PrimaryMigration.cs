using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Migrations
{
    public partial class _14052022_PrimaryMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CCardCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CId);
                });

            migrationBuilder.CreateTable(
                name: "Librarians",
                columns: table => new
                {
                    LId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LEmail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Librarians", x => x.LId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BISBN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BPublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomersCId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BId);
                    table.ForeignKey(
                        name: "FK_Books_Customers_CustomersCId",
                        column: x => x.CustomersCId,
                        principalTable: "Customers",
                        principalColumn: "CId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AGID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AMiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ALastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BooksBId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AId);
                    table.ForeignKey(
                        name: "FK_Authors_Books_BooksBId",
                        column: x => x.BooksBId,
                        principalTable: "Books",
                        principalColumn: "BId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_BooksBId",
                table: "Authors",
                column: "BooksBId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CustomersCId",
                table: "Books",
                column: "CustomersCId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Librarians");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
