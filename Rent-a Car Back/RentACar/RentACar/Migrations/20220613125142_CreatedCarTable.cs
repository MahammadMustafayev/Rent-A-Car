using Microsoft.EntityFrameworkCore.Migrations;

namespace RentACar.Migrations
{
    public partial class CreatedCarTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarName = table.Column<string>(nullable: true),
                    CarModel = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    CarType = table.Column<string>(nullable: true),
                    CarDoor = table.Column<int>(nullable: false),
                    Seats = table.Column<int>(nullable: false),
                    LuggageSuit = table.Column<int>(nullable: false),
                    LuggageBaggage = table.Column<int>(nullable: false),
                    Transmission = table.Column<bool>(nullable: false),
                    Airconditioning = table.Column<bool>(nullable: false),
                    CarAge = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
