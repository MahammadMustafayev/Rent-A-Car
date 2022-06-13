using Microsoft.EntityFrameworkCore.Migrations;

namespace RentACar.Migrations
{
    public partial class CreatedBrandandCarTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarModel",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "BrandId",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BrandId1",
                table: "Cars",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_BrandId1",
                table: "Cars",
                column: "BrandId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Brands_BrandId1",
                table: "Cars",
                column: "BrandId1",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Brands_BrandId1",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_Cars_BrandId1",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "BrandId1",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "CarModel",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
