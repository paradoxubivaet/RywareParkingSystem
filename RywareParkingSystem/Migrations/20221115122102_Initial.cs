using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RywareParkingSystem.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parkings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    Usages = table.Column<TimeSpan>(type: "interval", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parkings", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parkings");
        }
    }
}
