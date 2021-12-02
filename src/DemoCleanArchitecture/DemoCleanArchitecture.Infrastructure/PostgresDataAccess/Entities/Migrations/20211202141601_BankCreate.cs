using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoCleanArchitecture.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class BankCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "DemoClean");

            migrationBuilder.CreateTable(
                name: "Bank",
                schema: "DemoClean",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Number = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
