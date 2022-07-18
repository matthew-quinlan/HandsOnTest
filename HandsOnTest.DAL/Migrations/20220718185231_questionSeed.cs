using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HandsOnTest.DAL.Migrations
{
    public partial class questionSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "QuestionId", "QuestionText" },
                values: new object[,]
                {
                    { 1, "In what city were you born?" },
                    { 2, "What is the name of your favorite pet?" },
                    { 3, "What is your mother's maiden name?" },
                    { 4, "What was the mascot of your high school?" },
                    { 5, "What was the make of your first car?" },
                    { 6, "What was your favorite toy as a child?" },
                    { 7, "Where did you meet your spouse?" },
                    { 8, "What is your favorite meal?" },
                    { 9, "Who is your favorite actor / actress ?" },
                    { 10, "What is your favorite album ?" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Question",
                keyColumn: "QuestionId",
                keyValue: 10);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "QuestionText",
                table: "Question",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
