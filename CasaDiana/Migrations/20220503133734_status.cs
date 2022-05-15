using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CasaDiana.Migrations
{
    public partial class status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Reservation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Reservation",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
