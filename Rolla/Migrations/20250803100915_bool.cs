using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rolla.Migrations
{
    /// <inheritdoc />
    public partial class @bool : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MapRouteRiders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "NotFound",
                table: "MapRouteRiders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MapRouteDrivers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "NotFound",
                table: "MapRouteDrivers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MapRouteRiders");

            migrationBuilder.DropColumn(
                name: "NotFound",
                table: "MapRouteRiders");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MapRouteDrivers");

            migrationBuilder.DropColumn(
                name: "NotFound",
                table: "MapRouteDrivers");
        }
    }
}
