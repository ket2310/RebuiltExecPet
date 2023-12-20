using Microsoft.EntityFrameworkCore.Migrations;

namespace RebuiltExecPetAPI.Migrations
{
    public partial class BringOwnerObject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "QuoteId",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "CellNumber",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "Instructions",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Quotes");

            migrationBuilder.CreateTable(
                name: "PetOwner",
                columns: table => new
                {
                    PetOwnerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CellNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instructions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    quoteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetOwner", x => x.PetOwnerId);
                    table.ForeignKey(
                        name: "FK_PetOwner_Quotes_quoteId",
                        column: x => x.quoteId,
                        principalTable: "Quotes",
                        principalColumn: "QuoteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PetOwner_quoteId",
                table: "PetOwner",
                column: "quoteId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PetOwner");

            migrationBuilder.AddColumn<string>(
                name: "CellNumber",
                table: "Quotes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Quotes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Quotes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instructions",
                table: "Quotes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Quotes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Quotes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "QuoteId", "CellNumber", "Email", "FirstName", "Instructions", "LastName", "PhoneNumber", "TravelType" },
                values: new object[] { 1, "1234567890", "dablumaroon@gmail.com", "Kirk", " Drive safe", "Thomas", "1234567890", 0 });
        }
    }
}
