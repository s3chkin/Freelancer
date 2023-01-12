using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Freelancer.Migrations
{
    public partial class freelancerrdb3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_ContactUs_ContactUsId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_ContactUsId",
                table: "Jobs");

            migrationBuilder.CreateTable(
                name: "ContactUsJob",
                columns: table => new
                {
                    ContactUsId = table.Column<int>(type: "int", nullable: false),
                    JobsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUsJob", x => new { x.ContactUsId, x.JobsId });
                    table.ForeignKey(
                        name: "FK_ContactUsJob_ContactUs_ContactUsId",
                        column: x => x.ContactUsId,
                        principalTable: "ContactUs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactUsJob_Jobs_JobsId",
                        column: x => x.JobsId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactUsJob_JobsId",
                table: "ContactUsJob",
                column: "JobsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactUsJob");

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
    }
}
