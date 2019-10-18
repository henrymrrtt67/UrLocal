using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace UrLocal.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    craftSlide = table.Column<int>(nullable: false),
                    Complexity = table.Column<int>(nullable: false),
                    WineCheck = table.Column<bool>(nullable: false),
                    BeerCheck = table.Column<bool>(nullable: false),
                    SpiritCheck = table.Column<bool>(nullable: false),
                    PriceRange = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
