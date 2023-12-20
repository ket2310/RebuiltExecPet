using Microsoft.EntityFrameworkCore.Migrations;

namespace RebuiltExecPetAPI.Migrations
{
    public partial class ModifyQuoteTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetOwner_Quotes_quoteId",
                table: "PetOwner");

            migrationBuilder.DropIndex(
                name: "IX_PetOwner_quoteId",
                table: "PetOwner");

            migrationBuilder.DropColumn(
                name: "quoteId",
                table: "PetOwner");

            migrationBuilder.AddColumn<int>(
                name: "petOwnerId",
                table: "Quotes",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_PetOwner_petOwnerId",
                table: "Quotes");

            migrationBuilder.DropIndex(
                name: "IX_Quotes_petOwnerId",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "petOwnerId",
                table: "Quotes");

            migrationBuilder.AddColumn<int>(
                name: "quoteId",
                table: "PetOwner",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PetOwner_quoteId",
                table: "PetOwner",
                column: "quoteId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PetOwner_Quotes_quoteId",
                table: "PetOwner",
                column: "quoteId",
                principalTable: "Quotes",
                principalColumn: "QuoteId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
