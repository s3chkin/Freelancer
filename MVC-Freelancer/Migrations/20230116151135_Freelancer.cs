using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Freelancer.Migrations
{
    public partial class Freelancer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Requests_RequestId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_RequestId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ImagesId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Requests");

            migrationBuilder.AddColumn<int>(
                name: "ImagesId",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RequestId",
                table: "Images",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_RequestId",
                table: "Images",
                column: "RequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Requests_RequestId",
                table: "Images",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id");
        }
    }
}
