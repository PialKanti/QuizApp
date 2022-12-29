using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedAnswerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "57baf6aa-fefe-40ca-bf78-931a7e0f33f6", "AQAAAAEAACcQAAAAEEkW2nmv7UQKnztmF4McVGhWKwYPe9wZS5oDUPHI4xd1CgnNTPGNOxyIhWHrtreq6Q==", "0310cf55-602d-4082-bbef-92a86cd57d1f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "499f4562-40be-4553-9bc9-e33de208d67d", "AQAAAAEAACcQAAAAEJTYdjqwYygbRfv233H3Z1IMG+n6oI6Fq9KyVeRMGaXJ7l/BcUQeeo6hQsbiPTIQQQ==", "bbceb831-5572-4b78-989b-9cef8b08b99b" });
        }
    }
}
