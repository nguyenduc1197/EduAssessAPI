using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatestudentexamandstudentexamanswertables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentExamAnswers_Questions_QuestionId",
                table: "StudentExamAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExamAnswers_StudentExams_StudentExamId",
                table: "StudentExamAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExams_StudentSubjects_StudentSubjectId",
                table: "StudentExams");

            migrationBuilder.DropIndex(
                name: "IX_StudentExams_StudentSubjectId",
                table: "StudentExams");

            migrationBuilder.DropColumn(
                name: "StudentSubjectId",
                table: "StudentExams");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartedAt",
                table: "StudentExams",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<Guid>(
                name: "ExamId",
                table: "StudentExams",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StudentId",
                table: "StudentExams",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "StudentExamId",
                table: "StudentExamAnswers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "QuestionId",
                table: "StudentExamAnswers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_StudentExams_ExamId",
                table: "StudentExams",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentExams_StudentId",
                table: "StudentExams",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExamAnswers_Questions_QuestionId",
                table: "StudentExamAnswers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExamAnswers_StudentExams_StudentExamId",
                table: "StudentExamAnswers",
                column: "StudentExamId",
                principalTable: "StudentExams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExams_Exams_ExamId",
                table: "StudentExams",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExams_Students_StudentId",
                table: "StudentExams",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentExamAnswers_Questions_QuestionId",
                table: "StudentExamAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExamAnswers_StudentExams_StudentExamId",
                table: "StudentExamAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExams_Exams_ExamId",
                table: "StudentExams");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExams_Students_StudentId",
                table: "StudentExams");

            migrationBuilder.DropIndex(
                name: "IX_StudentExams_ExamId",
                table: "StudentExams");

            migrationBuilder.DropIndex(
                name: "IX_StudentExams_StudentId",
                table: "StudentExams");

            migrationBuilder.DropColumn(
                name: "ExamId",
                table: "StudentExams");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "StudentExams");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartedAt",
                table: "StudentExams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StudentSubjectId",
                table: "StudentExams",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "StudentExamId",
                table: "StudentExamAnswers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "QuestionId",
                table: "StudentExamAnswers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentExams_StudentSubjectId",
                table: "StudentExams",
                column: "StudentSubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExamAnswers_Questions_QuestionId",
                table: "StudentExamAnswers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExamAnswers_StudentExams_StudentExamId",
                table: "StudentExamAnswers",
                column: "StudentExamId",
                principalTable: "StudentExams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExams_StudentSubjects_StudentSubjectId",
                table: "StudentExams",
                column: "StudentSubjectId",
                principalTable: "StudentSubjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
