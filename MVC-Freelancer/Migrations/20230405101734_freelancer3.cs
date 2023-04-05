using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Freelancer.Migrations
{
    public partial class freelancer3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Jobs");

            migrationBuilder.AddColumn<int>(
                name: "GiverRating",
                table: "Jobs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TakerRating",
                table: "Jobs",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GiverRating",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "TakerRating",
                table: "Jobs");

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Jobs",
                type: "float",
                nullable: true);
        }
    }
}
