using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CasaDiana.Migrations
{
    public partial class RoomType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Facilities",
                table: "RoomType",
                newName: "FacilitiesId");

            migrationBuilder.CreateTable(
                name: "Facilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PetFriendly = table.Column<bool>(type: "bit", nullable: false),
                    Smoking = table.Column<bool>(type: "bit", nullable: false),
                    HairDryer = table.Column<bool>(type: "bit", nullable: false),
                    Bath = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomType_FacilitiesId",
                table: "RoomType",
                column: "FacilitiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomType_Facilities_FacilitiesId",
                table: "RoomType",
                column: "FacilitiesId",
                principalTable: "Facilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomType_Facilities_FacilitiesId",
                table: "RoomType");

            migrationBuilder.DropTable(
                name: "Facilities");

            migrationBuilder.DropIndex(
                name: "IX_RoomType_FacilitiesId",
                table: "RoomType");

            migrationBuilder.RenameColumn(
                name: "FacilitiesId",
                table: "RoomType",
                newName: "Facilities");
        }
    }
}
