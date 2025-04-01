using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teachzilla.Model.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Created = table.Column<long>(type: "INTEGER", nullable: false),
                    Updated = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Homework",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    StudentID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Due = table.Column<long>(type: "INTEGER", nullable: false),
                    Created = table.Column<long>(type: "INTEGER", nullable: false),
                    Updated = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Homework", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Homework_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    StudentID = table.Column<Guid>(type: "TEXT", nullable: false),
                    LessonDate = table.Column<long>(type: "INTEGER", nullable: false),
                    Created = table.Column<long>(type: "INTEGER", nullable: false),
                    Updated = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Lessons_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    Created = table.Column<long>(type: "INTEGER", nullable: false),
                    Updated = table.Column<long>(type: "INTEGER", nullable: false),
                    StudentID = table.Column<Guid>(type: "TEXT", nullable: true),
                    HomeworkID = table.Column<Guid>(type: "TEXT", nullable: true),
                    LessonID = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Notes_Homework_HomeworkID",
                        column: x => x.HomeworkID,
                        principalTable: "Homework",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Notes_Lessons_LessonID",
                        column: x => x.LessonID,
                        principalTable: "Lessons",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Notes_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Homework_StudentID",
                table: "Homework",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_StudentID",
                table: "Lessons",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_HomeworkID",
                table: "Notes",
                column: "HomeworkID");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_LessonID",
                table: "Notes",
                column: "LessonID");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_StudentID",
                table: "Notes",
                column: "StudentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Homework");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
