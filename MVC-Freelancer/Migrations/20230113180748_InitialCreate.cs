using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Freelancer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Jobs_JobId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_JobId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "DeliveryTime1",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "DeliveryTime2",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "DeliveryTime3",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "PacketDescription1",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "PacketDescription2",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "PacketDescription3",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "PacketName1",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "PacketName2",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "Price1",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "Price2",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "Revision1",
                table: "Packages");

            migrationBuilder.RenameColumn(
                name: "Revision3",
                table: "Packages",
                newName: "Revision");

            migrationBuilder.RenameColumn(
                name: "Revision2",
                table: "Packages",
                newName: "DeliveryTime");

            migrationBuilder.RenameColumn(
                name: "Price3",
                table: "Packages",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "PacketName3",
                table: "Packages",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "PackageName",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PacketDescription",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "jobPackages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    PackageId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobPackages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_jobPackages_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_jobPackages_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_jobPackages_JobId",
                table: "jobPackages",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_jobPackages_PackageId",
                table: "jobPackages",
                column: "PackageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "jobPackages");

            migrationBuilder.DropColumn(
                name: "PackageName",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "PacketDescription",
                table: "Packages");

            migrationBuilder.RenameColumn(
                name: "Revision",
                table: "Packages",
                newName: "Revision3");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Packages",
                newName: "Price3");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Packages",
                newName: "PacketName3");

            migrationBuilder.RenameColumn(
                name: "DeliveryTime",
                table: "Packages",
                newName: "Revision2");

            migrationBuilder.AddColumn<int>(
                name: "DeliveryTime1",
                table: "Packages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryTime2",
                table: "Packages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryTime3",
                table: "Packages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "Packages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PacketDescription1",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PacketDescription2",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PacketDescription3",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PacketName1",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PacketName2",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price1",
                table: "Packages",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Price2",
                table: "Packages",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Revision1",
                table: "Packages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Packages_JobId",
                table: "Packages",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Jobs_JobId",
                table: "Packages",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
