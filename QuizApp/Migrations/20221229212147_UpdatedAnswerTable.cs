using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedAnswerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    OptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Options_OptionId",
                        column: x => x.OptionId,
                        principalTable: "Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9dc78a91-3f59-4837-9eee-ac804d70ef00", "AQAAAAEAACcQAAAAEIFpBuqptkwupq+bCjObKgocK0i9ZYtUjj3qNewPIatDx3fIWd/No56VNRaB4bHZBg==", "f76b907d-7b16-4d2c-b6af-f1d2b3b5f1d3" });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_OptionId",
                table: "Answers",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "57baf6aa-fefe-40ca-bf78-931a7e0f33f6", "AQAAAAEAACcQAAAAEEkW2nmv7UQKnztmF4McVGhWKwYPe9wZS5oDUPHI4xd1CgnNTPGNOxyIhWHrtreq6Q==", "0310cf55-602d-4082-bbef-92a86cd57d1f" });
        }
    }
}
