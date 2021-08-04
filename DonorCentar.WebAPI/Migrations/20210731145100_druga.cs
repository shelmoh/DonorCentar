using Microsoft.EntityFrameworkCore.Migrations;

namespace DonorCentar.WebAPI.Migrations
{
    public partial class druga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Naziv",
                table: "LicniPodaci");

            migrationBuilder.AddColumn<string>(
                name: "Ime",
                table: "LicniPodaci",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prezime",
                table: "LicniPodaci",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ime",
                table: "LicniPodaci");

            migrationBuilder.DropColumn(
                name: "Prezime",
                table: "LicniPodaci");

            migrationBuilder.AddColumn<string>(
                name: "Naziv",
                table: "LicniPodaci",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
