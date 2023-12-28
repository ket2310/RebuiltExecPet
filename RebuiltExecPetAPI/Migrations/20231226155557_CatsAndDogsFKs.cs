using Microsoft.EntityFrameworkCore.Migrations;

namespace RebuiltExecPetAPI.Migrations
{
    public partial class CatsAndDogsFKs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PetOwners_catId",
                table: "PetOwners",
                column: "catId");

            migrationBuilder.CreateIndex(
                name: "IX_PetOwners_dogId",
                table: "PetOwners",
                column: "dogId");

            migrationBuilder.AddForeignKey(
                name: "FK_PetOwners_Cats_catId",
                table: "PetOwners",
                column: "catId",
                principalTable: "Cats",
                principalColumn: "CatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PetOwners_Dogs_dogId",
                table: "PetOwners",
                column: "dogId",
                principalTable: "Dogs",
                principalColumn: "DogId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetOwners_Cats_catId",
                table: "PetOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_PetOwners_Dogs_dogId",
                table: "PetOwners");

            migrationBuilder.DropIndex(
                name: "IX_PetOwners_catId",
                table: "PetOwners");

            migrationBuilder.DropIndex(
                name: "IX_PetOwners_dogId",
                table: "PetOwners");
        }
    }
}
