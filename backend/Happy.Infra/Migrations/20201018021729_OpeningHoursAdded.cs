using Microsoft.EntityFrameworkCore.Migrations;

namespace Happy.Infra.Migrations
{
    public partial class OpeningHoursAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OpeningHours",
                table: "Orphanages",
                maxLength: 64,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OpeningHours",
                table: "Orphanages");
        }
    }
}
