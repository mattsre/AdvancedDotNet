using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCLab1.Migrations
{
    public partial class CompanyLogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyLogo",
                schema: "wsTrade",
                table: "Stocks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyLogo",
                schema: "wsTrade",
                table: "Stocks");
        }
    }
}
