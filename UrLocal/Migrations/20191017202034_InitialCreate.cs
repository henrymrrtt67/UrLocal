using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace UrLocal.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bars",
                columns: table => new
                {
                    barId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    barName = table.Column<string>(nullable: true),
                    barLocation = table.Column<string>(nullable: true),
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
                    userName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    craftSlide = table.Column<int>(nullable: false),
                    complexity = table.Column<int>(nullable: false),
                    wineCheck = table.Column<bool>(nullable: false),
                    beerCheck = table.Column<bool>(nullable: false),
                    spiritCheck = table.Column<bool>(nullable: false),
                    priceCheck = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.userId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bars");
        }
    }
}
