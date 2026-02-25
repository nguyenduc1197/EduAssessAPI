using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removeschoolclasssubjectfromquestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_SchoolClassSubjects_SchoolClassSubjectId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_SchoolClassSubjectId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "SchoolClassSubjectId",
                table: "Questions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SchoolClassSubjectId",
                table: "Questions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Questions_SchoolClassSubjectId",
                table: "Questions",
                column: "SchoolClassSubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_SchoolClassSubjects_SchoolClassSubjectId",
                table: "Questions",
                column: "SchoolClassSubjectId",
                principalTable: "SchoolClassSubjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
