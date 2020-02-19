using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCLab1.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "wsTrade");

            migrationBuilder.CreateTable(
                name: "Accounts",
                schema: "wsTrade",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Balance = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PricingPlans",
                schema: "wsTrade",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanName = table.Column<string>(nullable: true),
                    PlanDescription = table.Column<string>(nullable: true),
                    PlanCost = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PricingPlans", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                schema: "wsTrade",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ticker = table.Column<string>(nullable: true),
                    StockName = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                schema: "wsTrade",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureName = table.Column<string>(nullable: true),
                    FeatureDescription = table.Column<string>(nullable: true),
                    PricingModelForeignKey = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Features_PricingPlans_PricingModelForeignKey",
                        column: x => x.PricingModelForeignKey,
                        principalSchema: "wsTrade",
                        principalTable: "PricingPlans",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Features_PricingModelForeignKey",
                schema: "wsTrade",
                table: "Features",
                column: "PricingModelForeignKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts",
                schema: "wsTrade");

            migrationBuilder.DropTable(
                name: "Features",
                schema: "wsTrade");

            migrationBuilder.DropTable(
                name: "Stocks",
                schema: "wsTrade");

            migrationBuilder.DropTable(
                name: "PricingPlans",
                schema: "wsTrade");
        }
    }
}
