using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Symphony_Limited.Migrations
{
    /// <inheritdoc />
    public partial class student : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Examinations",
                columns: table => new
                {
                    ExamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamName = table.Column<string>(name: "Exam Name", type: "varchar(255)", nullable: false),
                    ExamDate = table.Column<DateTime>(name: "Exam Date", type: "datetime", nullable: false),
                    Fees = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Createdat = table.Column<DateTime>(name: "Created at", type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examinations", x => x.ExamId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Student_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RollNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StudentName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Marks = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Class_Assigned = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Fees_Paid = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Student_Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Examinations");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
