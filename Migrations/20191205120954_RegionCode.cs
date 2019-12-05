using Microsoft.EntityFrameworkCore.Migrations;

namespace Virksomhedsgodkendelser.Migrations
{
    public partial class RegionCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RegionCode",
                table: "Region",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegionCode",
                table: "Region");
        }
    }
}
