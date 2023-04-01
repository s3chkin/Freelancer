using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Freelancer.Migrations
{
    public partial class init004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "AspNetUsers");
        }
    }
}
