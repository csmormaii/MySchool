using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MySchool.Migrations
{
    public partial class PopulaTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "COURSE",
                columns: new[] { "IdCourse", "classes", "course", "horary", "registration" },
                values: new object[] { 1, "Sala A1", "Sistema da Informação", new DateTime(2022, 6, 21, 0, 0, 0, 0, DateTimeKind.Local), "456789" });

            migrationBuilder.InsertData(
                table: "TEACHER",
                columns: new[] { "IdTeacher", "name", "register", "subjects", "telephone" },
                values: new object[] { 1, "Claudio", "34567", "Programação Backend", "2140028855" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "COURSE",
                keyColumn: "IdCourse",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TEACHER",
                keyColumn: "IdTeacher",
                keyValue: 1);
        }
    }
}
