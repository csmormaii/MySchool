using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MySchool.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "COURSE",
                columns: table => new
                {
                    IdCourse = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    registration = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    course = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    classes = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    horary = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COURSE", x => x.IdCourse);
                });

            migrationBuilder.CreateTable(
                name: "TEACHER",
                columns: table => new
                {
                    IdTeacher = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    subjects = table.Column<string>(type: "nvarchar(75)", nullable: true),
                    register = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    telephone = table.Column<string>(type: "nvarchar(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TEACHER", x => x.IdTeacher);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "COURSE");

            migrationBuilder.DropTable(
                name: "TEACHER");
        }
    }
}
