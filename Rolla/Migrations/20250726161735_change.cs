using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rolla.Migrations
{
    /// <inheritdoc />
    public partial class change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MapRoutes",
                table: "MapRoutes");

            migrationBuilder.RenameTable(
                name: "MapRoutes",
                newName: "MapRouteDrivers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MapRouteDrivers",
                table: "MapRouteDrivers",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MapRouteDrivers",
                table: "MapRouteDrivers");

            migrationBuilder.RenameTable(
                name: "MapRouteDrivers",
                newName: "MapRoutes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MapRoutes",
                table: "MapRoutes",
                column: "Id");
        }
    }
}
