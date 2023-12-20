using Microsoft.EntityFrameworkCore.Migrations;

namespace RebuiltExecPetAPI.Migrations
{
    public partial class ModifyQuoteTableWitSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PetOwner",
                columns: new[] { "PetOwnerId", "CellNumber", "Email", "FirstName", "Instructions", "LastName", "PhoneNumber" },
                values: new object[] { 1, "1234567890", "dablumaroon@gmail.com", "Kirk", null, "Thomas", "1234567890" });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "QuoteId", "TravelType", "petOwnerId" },
                values: new object[] { 1, 0, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "QuoteId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PetOwner",
                keyColumn: "PetOwnerId",
                keyValue: 1);
        }
    }
}
