using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Forecast.Infra.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    CellPhone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Cpf = table.Column<string>(nullable: true),
                    Rg = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
