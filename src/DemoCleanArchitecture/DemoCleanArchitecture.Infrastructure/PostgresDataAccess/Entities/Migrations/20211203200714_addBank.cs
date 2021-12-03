using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoCleanArchitecture.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class addBank : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bank",
                schema: "DemoClean",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Number = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bank",
                schema: "DemoClean");
        }
    }
}
