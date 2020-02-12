using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCLab1.Migrations
{
    public partial class Features : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PricingModels",
                table: "PricingModels");

            migrationBuilder.RenameTable(
                name: "PricingModels",
                newName: "PricingPlans");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PricingPlans",
                table: "PricingPlans",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Features",
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
                        principalTable: "PricingPlans",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Features_PricingModelForeignKey",
                table: "Features",
                column: "PricingModelForeignKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PricingPlans",
                table: "PricingPlans");

            migrationBuilder.RenameTable(
                name: "PricingPlans",
                newName: "PricingModels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PricingModels",
                table: "PricingModels",
                column: "ID");
        }
    }
}
