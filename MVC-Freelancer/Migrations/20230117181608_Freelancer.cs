using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Freelancer.Migrations
{
    public partial class Freelancer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Jobs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Jobs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
