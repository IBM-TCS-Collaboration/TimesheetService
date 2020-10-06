using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TimesheetService.Migrations
{
    public partial class initials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "descriptionTB",
                columns: table => new
                {
                    DescriptionId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    ProjectId = table.Column<int>(nullable: false),
                    TimesheetMasterId = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_descriptionTB", x => x.DescriptionId);
                });

            migrationBuilder.CreateTable(
                name: "timesheetAuditTB",
                columns: table => new
                {
                    ApprovalTimesheetLogID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApprovalUser = table.Column<int>(nullable: false),
                    ProcessedDate = table.Column<DateTime>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    TimesheetID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_timesheetAuditTB", x => x.ApprovalTimesheetLogID);
                });

            migrationBuilder.CreateTable(
                name: "timesheetDetails",
                columns: table => new
                {
                    TimesheetId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DaysofWeek = table.Column<string>(nullable: true),
                    Hours = table.Column<int>(nullable: false),
                    Period = table.Column<DateTime>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    TimesheetMasterId = table.Column<int>(nullable: false),
                    TotalHours = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_timesheetDetails", x => x.TimesheetId);
                });

            migrationBuilder.CreateTable(
                name: "timesheetMaster",
                columns: table => new
                {
                    TimesheetMasterId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false),
                    TotalHours = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    TimesheetStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_timesheetMaster", x => x.TimesheetMasterId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "descriptionTB");

            migrationBuilder.DropTable(
                name: "timesheetAuditTB");

            migrationBuilder.DropTable(
                name: "timesheetDetails");

            migrationBuilder.DropTable(
                name: "timesheetMaster");
        }
    }
}
