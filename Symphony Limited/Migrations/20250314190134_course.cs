using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Symphony_Limited.Migrations
{
    /// <inheritdoc />
    public partial class course : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    Course_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(name: "Course Name", type: "varchar(255)", nullable: false),
                    CourseDescription = table.Column<string>(name: "Course Description", type: "text", nullable: false),
                    Duration = table.Column<string>(type: "varchar(50)", nullable: false),
                    Fees = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    CourseImg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.Course_Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "courses");
        }
    }
}
