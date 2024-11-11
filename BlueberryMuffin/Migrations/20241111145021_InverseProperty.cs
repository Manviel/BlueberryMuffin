using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlueberryMuffin.Migrations
{
    /// <inheritdoc />
    public partial class InverseProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Answers_SurveyResponses_SurveyResponseId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_SelectedOptions_Answers_AnswerId",
                table: "SelectedOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyAccesses_AspNetUsers_UserId",
                table: "SurveyAccesses");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyAccesses_Surveys_SurveyId",
                table: "SurveyAccesses");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d7f2d20-3039-457a-8bce-0d862e863576");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a36c1db-dc86-4e07-a6c0-547246cf083d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4f3125e-646e-4947-ac33-3cf7a1e27a6c");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_SurveyResponses_SurveyResponseId",
                table: "Answers",
                column: "SurveyResponseId",
                principalTable: "SurveyResponses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SelectedOptions_Answers_AnswerId",
                table: "SelectedOptions",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyAccesses_AspNetUsers_UserId",
                table: "SurveyAccesses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyAccesses_Surveys_SurveyId",
                table: "SurveyAccesses",
                column: "SurveyId",
                principalTable: "Surveys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Answers_SurveyResponses_SurveyResponseId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_SelectedOptions_Answers_AnswerId",
                table: "SelectedOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyAccesses_AspNetUsers_UserId",
                table: "SurveyAccesses");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyAccesses_Surveys_SurveyId",
                table: "SurveyAccesses");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4d7f2d20-3039-457a-8bce-0d862e863576", null, "Administrator", "ADMIN" },
                    { "6a36c1db-dc86-4e07-a6c0-547246cf083d", null, "User", "USER" },
                    { "e4f3125e-646e-4947-ac33-3cf7a1e27a6c", null, "Manager", "MANAGER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_SurveyResponses_SurveyResponseId",
                table: "Answers",
                column: "SurveyResponseId",
                principalTable: "SurveyResponses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SelectedOptions_Answers_AnswerId",
                table: "SelectedOptions",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyAccesses_AspNetUsers_UserId",
                table: "SurveyAccesses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyAccesses_Surveys_SurveyId",
                table: "SurveyAccesses",
                column: "SurveyId",
                principalTable: "Surveys",
                principalColumn: "Id");
        }
    }
}
