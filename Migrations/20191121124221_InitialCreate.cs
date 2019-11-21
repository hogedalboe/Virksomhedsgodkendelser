using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Virksomhedsgodkendelser.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pnr = table.Column<int>(nullable: false),
                    Virksomhedsnavn = table.Column<string>(nullable: true),
                    CVRnr = table.Column<string>(nullable: true),
                    PostnrPostdistrikt = table.Column<string>(nullable: true),
                    Tlfnr = table.Column<string>(nullable: true),
                    UddannelseskodeUddannelsesbetegnelse = table.Column<string>(nullable: true),
                    COSAnr = table.Column<string>(nullable: true),
                    SpecialekodeSpecialebetegnelse = table.Column<string>(nullable: true),
                    GodkendelseOprettet = table.Column<DateTime>(nullable: false),
                    Nygodkendelse = table.Column<int>(nullable: false),
                    Godkendelsesdato = table.Column<DateTime>(nullable: false),
                    Godkendelsesaendring = table.Column<int>(nullable: false),
                    Godkendelsesantal = table.Column<int>(nullable: false),
                    AntalIgangvarendeAftaler = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
