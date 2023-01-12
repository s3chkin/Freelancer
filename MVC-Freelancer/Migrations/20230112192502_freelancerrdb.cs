using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Freelancer.Migrations
{
    public partial class freelancerrdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactUs_Jobs_JobId",
                table: "ContactUs");

            migrationBuilder.DropIndex(
                name: "IX_ContactUs_JobId",
                table: "ContactUs");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "ContactUs");

            migrationBuilder.AddColumn<int>(
                name: "ContactUsId",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_ContactUsId",
                table: "Jobs",
                column: "ContactUsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_ContactUs_ContactUsId",
                table: "Jobs",
                column: "ContactUsId",
                principalTable: "ContactUs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_ContactUs_ContactUsId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_ContactUsId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ContactUsId",
                table: "Jobs");

            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "ContactUs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ContactUs_JobId",
                table: "ContactUs",
                column: "JobId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactUs_Jobs_JobId",
                table: "ContactUs",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
