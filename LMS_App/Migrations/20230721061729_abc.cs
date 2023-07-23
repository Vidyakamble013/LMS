using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS_App.Migrations
{
    public partial class abc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoanDetails",
                columns: table => new
                {
                    LoanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanNumber = table.Column<int>(type: "int", nullable: false),
                    LoanAmount = table.Column<double>(type: "float", nullable: true),
                    LoanTerms = table.Column<int>(type: "int", nullable: true),
                    BorrowerInformation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropertyInformation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoanFees = table.Column<double>(type: "float", nullable: true),
                    OriginationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OriginationAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineInformation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegalDocument = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanDetails", x => x.LoanId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanDetails");
        }
    }
}
