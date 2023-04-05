using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Freelancer.Migrations
{
    public partial class freelancer4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TakerRating",
                table: "Jobs",
                newName: "RatingForTaker");

            migrationBuilder.RenameColumn(
                name: "GiverRating",
                table: "Jobs",
                newName: "RatingForGiver");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RatingForTaker",
                table: "Jobs",
                newName: "TakerRating");

            migrationBuilder.RenameColumn(
                name: "RatingForGiver",
                table: "Jobs",
                newName: "GiverRating");
        }
    }
}
