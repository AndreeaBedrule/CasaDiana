using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CasaDiana.Migrations
{
    public partial class RoomChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_RoomType_RoomtypeId",
                table: "Room");

            migrationBuilder.DropTable(
                name: "RoomType");

            migrationBuilder.DropTable(
                name: "Facilities");

            migrationBuilder.DropIndex(
                name: "IX_Room_RoomtypeId",
                table: "Room");

            migrationBuilder.RenameColumn(
                name: "RoomtypeId",
                table: "Room",
                newName: "Price");

            migrationBuilder.AddColumn<bool>(
                name: "Bath",
                table: "Room",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HairDryer",
                table: "Room",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfPersons",
                table: "Room",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "PetFriendly",
                table: "Room",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Smoking",
                table: "Room",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_RoomId",
                table: "Reservation",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Room_RoomId",
                table: "Reservation",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Room_RoomId",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_RoomId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "Bath",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "HairDryer",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "NumberOfPersons",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "PetFriendly",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "Smoking",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Reservation");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Room",
                newName: "RoomtypeId");

            migrationBuilder.CreateTable(
                name: "Facilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bath = table.Column<bool>(type: "bit", nullable: false),
                    HairDryer = table.Column<bool>(type: "bit", nullable: false),
                    PetFriendly = table.Column<bool>(type: "bit", nullable: false),
                    Smoking = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacilitiesId = table.Column<int>(type: "int", nullable: false),
                    NumberOfPersons = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomType_Facilities_FacilitiesId",
                        column: x => x.FacilitiesId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Room_RoomtypeId",
                table: "Room",
                column: "RoomtypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomType_FacilitiesId",
                table: "RoomType",
                column: "FacilitiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_RoomType_RoomtypeId",
                table: "Room",
                column: "RoomtypeId",
                principalTable: "RoomType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
