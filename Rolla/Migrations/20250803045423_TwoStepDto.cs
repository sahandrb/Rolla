using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rolla.Migrations
{
    /// <inheritdoc />
    public partial class TwoStepDto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoutingDCode",
                table: "Drivers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoutingDCode",
                table: "Drivers");
        }
    }
}
