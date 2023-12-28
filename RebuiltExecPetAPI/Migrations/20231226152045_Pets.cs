using Microsoft.EntityFrameworkCore.Migrations;

namespace RebuiltExecPetAPI.Migrations
{
    public partial class Pets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "catId",
                table: "PetOwners",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "dogId",
                table: "PetOwners",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "catId",
                table: "PetOwners");

            migrationBuilder.DropColumn(
                name: "dogId",
                table: "PetOwners");
        }
    }
}
