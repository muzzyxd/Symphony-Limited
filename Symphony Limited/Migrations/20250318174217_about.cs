using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Symphony_Limited.Migrations
{
    /// <inheritdoc />
    public partial class about : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_faqs",
                table: "faqs");

            migrationBuilder.RenameTable(
                name: "faqs",
                newName: "Faqs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Faqs",
                table: "Faqs",
                column: "Faq_Id");

            migrationBuilder.CreateTable(
                name: "abouts",
                columns: table => new
                {
                    About_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abouts", x => x.About_Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "abouts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Faqs",
                table: "Faqs");

            migrationBuilder.RenameTable(
                name: "Faqs",
                newName: "faqs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_faqs",
                table: "faqs",
                column: "Faq_Id");
        }
    }
}
