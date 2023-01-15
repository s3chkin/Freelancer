using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Freelancer.Migrations
{
    public partial class freelancer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeliveryTime",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryTime2",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryTime3",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ExtraInfo",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraInfo2",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraInfo3",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PackageName",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PackageName2",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PackageName3",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PacketDescription",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PacketDescription2",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PacketDescription3",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "PacketPrice",
                table: "Jobs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PacketPrice2",
                table: "Jobs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PacketPrice3",
                table: "Jobs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Revision",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Revision2",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Revision3",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryTime",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "DeliveryTime2",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "DeliveryTime3",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ExtraInfo",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ExtraInfo2",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ExtraInfo3",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "PackageName",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "PackageName2",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "PackageName3",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "PacketDescription",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "PacketDescription2",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "PacketDescription3",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "PacketPrice",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "PacketPrice2",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "PacketPrice3",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Revision",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Revision2",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Revision3",
                table: "Jobs");
        }
    }
}
