using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace UrLocal.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Creating the tables in the default string or the area placed if there isnt the tables already existing there.
            migrationBuilder.CreateTable(
                name: "bars",
                columns: table => new
                {
                    barId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    barName = table.Column<string>(nullable: false),
                    barLocation = table.Column<string>(nullable: false),
                    craftSlide = table.Column<int>(nullable: false),
                    complexity = table.Column<int>(nullable: false),
                    wineCheck = table.Column<bool>(nullable: false),
                    beerCheck = table.Column<bool>(nullable: false),
                    spiritCheck = table.Column<bool>(nullable: false),
                    lqMeal = table.Column<double>(nullable: false),
                    lqBeer = table.Column<double>(nullable: false),
                    uqMeal = table.Column<double>(nullable: false),
                    uqBeer = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bars", x => x.barId);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    userId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    craftSlide = table.Column<int>(nullable: false),
                    Complexity = table.Column<int>(nullable: false),
                    WineCheck = table.Column<bool>(nullable: false),
                    BeerCheck = table.Column<bool>(nullable: false),
                    SpiritCheck = table.Column<bool>(nullable: false),
                    PriceRange = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.userId);
                });
        }

        // when called will drop both tables
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bars");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
