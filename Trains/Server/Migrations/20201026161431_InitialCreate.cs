using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trains.Server.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trains",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    YearMade = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 10, nullable: false),
                    Color = table.Column<int>(nullable: false),
                    LicensePlate = table.Column<string>(nullable: false),
                    Company = table.Column<string>(nullable: false),
                    HomeStation = table.Column<string>(nullable: false),
                    IsRenovated = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trains", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trains");
        }
    }
}
