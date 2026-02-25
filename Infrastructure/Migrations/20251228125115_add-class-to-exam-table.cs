using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addclasstoexamtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SchoolClassId",
                table: "Exams",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exams_SchoolClassId",
                table: "Exams",
                column: "SchoolClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_SchoolClassses_SchoolClassId",
                table: "Exams",
                column: "SchoolClassId",
                principalTable: "SchoolClassses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_SchoolClassses_SchoolClassId",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_SchoolClassId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "SchoolClassId",
                table: "Exams");
        }
    }
}
