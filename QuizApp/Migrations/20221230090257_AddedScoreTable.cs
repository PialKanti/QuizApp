using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedScoreTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Scores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalScore = table.Column<int>(type: "int", nullable: false),
                    EarnedScore = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    QuizId = table.Column<int>(type: "int", nullable: false),
                    CreatedTimestamp = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Scores_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Scores_Quizes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "10b61c84-cad1-4f7b-bb49-12f14ae32a5b", "AQAAAAEAACcQAAAAENwkzZI0B37aDNlubntguHs5i8tghnaXGe1A1mgw0+/OWs8YioN2uVnnTdjOIoEhQA==", "5df3f23f-7789-4bc0-8931-2e946f9f8c78" });

            migrationBuilder.CreateIndex(
                name: "IX_Scores_QuizId",
                table: "Scores",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_UserId",
                table: "Scores",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Scores");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9dc78a91-3f59-4837-9eee-ac804d70ef00", "AQAAAAEAACcQAAAAEIFpBuqptkwupq+bCjObKgocK0i9ZYtUjj3qNewPIatDx3fIWd/No56VNRaB4bHZBg==", "f76b907d-7b16-4d2c-b6af-f1d2b3b5f1d3" });
        }
    }
}
