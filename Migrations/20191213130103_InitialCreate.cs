using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Virksomhedsgodkendelser.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Approval",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CVRnr = table.Column<string>(nullable: true),
                    Pnr = table.Column<string>(nullable: true),
                    Pname = table.Column<string>(nullable: true),
                    StreetAddress = table.Column<string>(nullable: true),
                    PostalCode = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    EducationCode = table.Column<int>(nullable: false),
                    EducationName = table.Column<string>(nullable: true),
                    SpecialisationCode = table.Column<int>(nullable: false),
                    SpecialisationName = table.Column<string>(nullable: true),
                    Limitation1 = table.Column<string>(nullable: true),
                    Limitation2 = table.Column<string>(nullable: true),
                    ApprovalCreatedDate = table.Column<DateTime>(nullable: false),
                    ApprovalDate = table.Column<DateTime>(nullable: false),
                    ApprovalQuantity = table.Column<int>(nullable: false),
                    ApprovalsInUse = table.Column<int>(nullable: false),
                    OtherApprovalsInUse = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    RegionCode = table.Column<int>(nullable: false),
                    MunicipalCode = table.Column<int>(nullable: false),
                    BusinessCode = table.Column<string>(nullable: true),
                    BusinessName = table.Column<string>(nullable: true),
                    UpdateInitials = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    CorporateStructureCode = table.Column<string>(nullable: true),
                    CorporateStructureName = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    CompanyStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Approval", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pnr = table.Column<int>(nullable: false),
                    Virksomhedsnavn = table.Column<string>(nullable: true),
                    CVRnr = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "District",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistrictCode = table.Column<int>(nullable: false),
                    DistrictName = table.Column<string>(nullable: true),
                    MunicipalityCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Municipality",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MunicipalityCode = table.Column<int>(nullable: false),
                    MunicipalityName = table.Column<string>(nullable: true),
                    RegionCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipality", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionCode = table.Column<int>(nullable: false),
                    RegionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Approval");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "District");

            migrationBuilder.DropTable(
                name: "Municipality");

            migrationBuilder.DropTable(
                name: "Region");
        }
    }
}
