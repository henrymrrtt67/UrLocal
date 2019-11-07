using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace UrLocal.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bar_check",
                columns: table => new
                {
                    bar_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    wine = table.Column<bool>(nullable: false),
                    beer = table.Column<bool>(nullable: false),
                    spirit = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bar_check", x => x.bar_id);
                });

            migrationBuilder.CreateTable(
                name: "bar_score",
                columns: table => new
                {
                    bar_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    craft_slide = table.Column<int>(nullable: false),
                    complexity = table.Column<int>(nullable: false),
                    lqMeal = table.Column<double>(nullable: false),
                    lqBeer = table.Column<double>(nullable: false),
                    uqMeal = table.Column<double>(nullable: false),
                    uqBeer = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bar_score", x => x.bar_id);
                });

            migrationBuilder.CreateTable(
                name: "bars",
                columns: table => new
                {
                    barId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    bar_name = table.Column<string>(nullable: true),
                    street_num = table.Column<int>(nullable: false),
                    street_name = table.Column<string>(nullable: true),
                    suburb = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bars", x => x.barId);
                });

            migrationBuilder.CreateTable(
                name: "user_check",
                columns: table => new
                {
                    user_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    wine = table.Column<bool>(nullable: false),
                    beer = table.Column<bool>(nullable: false),
                    spirit = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_check", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "user_pref",
                columns: table => new
                {
                    user_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    craft_slide = table.Column<int>(nullable: false),
                    complexity = table.Column<int>(nullable: false),
                    price_range = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_pref", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    userId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.userId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bar_check");

            migrationBuilder.DropTable(
                name: "bar_score");

            migrationBuilder.DropTable(
                name: "bars");

            migrationBuilder.DropTable(
                name: "user_check");

            migrationBuilder.DropTable(
                name: "user_pref");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
