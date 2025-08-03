using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rolla.Migrations
{
    /// <inheritdoc />
    public partial class ssd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoutingDCode",
                table: "MapRouteDrivers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoutingDCode",
                table: "MapRouteDrivers");
        }
    }
}
