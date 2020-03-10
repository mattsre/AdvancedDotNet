using Microsoft.EntityFrameworkCore.Migrations;

namespace mvcLabs.Migrations
{
    public partial class ManufacturerCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Model",
                schema: "mvcLabs",
                table: "Cars",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ManufacturerID",
                schema: "mvcLabs",
                table: "Cars",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                schema: "mvcLabs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ManufacturerID",
                schema: "mvcLabs",
                table: "Cars",
                column: "ManufacturerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Manufacturers_ManufacturerID",
                schema: "mvcLabs",
                table: "Cars",
                column: "ManufacturerID",
                principalSchema: "mvcLabs",
                principalTable: "Manufacturers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Manufacturers_ManufacturerID",
                schema: "mvcLabs",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "Manufacturers",
                schema: "mvcLabs");

            migrationBuilder.DropIndex(
                name: "IX_Cars_ManufacturerID",
                schema: "mvcLabs",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ManufacturerID",
                schema: "mvcLabs",
                table: "Cars");

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                schema: "mvcLabs",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
