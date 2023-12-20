using Microsoft.EntityFrameworkCore.Migrations;

namespace RebuiltExecPetAPI.Migrations
{
    public partial class RemoveQuoteFromPO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_PetOwner_petOwnerId",
                table: "Quotes");

            migrationBuilder.DropIndex(
                name: "IX_Quotes_petOwnerId",
                table: "Quotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PetOwner",
                table: "PetOwner");

            migrationBuilder.RenameTable(
                name: "PetOwner",
                newName: "PetOwners");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PetOwners",
                table: "PetOwners",
                column: "PetOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_petOwnerId",
                table: "Quotes",
                column: "petOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_PetOwners_petOwnerId",
                table: "Quotes",
                column: "petOwnerId",
                principalTable: "PetOwners",
                principalColumn: "PetOwnerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_PetOwners_petOwnerId",
                table: "Quotes");

            migrationBuilder.DropIndex(
                name: "IX_Quotes_petOwnerId",
                table: "Quotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PetOwners",
                table: "PetOwners");

            migrationBuilder.RenameTable(
                name: "PetOwners",
                newName: "PetOwner");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PetOwner",
                table: "PetOwner",
                column: "PetOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_petOwnerId",
                table: "Quotes",
                column: "petOwnerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_PetOwner_petOwnerId",
                table: "Quotes",
                column: "petOwnerId",
                principalTable: "PetOwner",
                principalColumn: "PetOwnerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
