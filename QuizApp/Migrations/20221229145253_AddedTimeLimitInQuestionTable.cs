using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedTimeLimitInQuestionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TimeLimit",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "272a78e4-66ef-4f2a-a9f2-0a9f56220270", "AQAAAAEAACcQAAAAEOHbwLsnOrLLD7Rd17F8qeYmOXcZa65gMj+Q+sMNGPcXkA0waa0J3/408w3UTvnNZA==", "a56a646a-d252-4fb8-8e5e-80a8b44f3a7b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeLimit",
                table: "Questions");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c3472ff3-8610-416a-be5d-571aa3b1259b", "AQAAAAEAACcQAAAAED+Yn0D5XqRgshB4+7wDcNl+IGuA9yK6WEJbg+se4l3Ap/z1DfhOgtGf1dsqaUhLxw==", "7dcd4b5a-b324-4f4f-a317-8213c15833ff" });
        }
    }
}
