using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class defaultvalueupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullMark",
                table: "Courses",
                newName: "FullMarks");

            migrationBuilder.RenameColumn(
                name: "CreditHour",
                table: "Courses",
                newName: "CreditHours");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullMarks",
                table: "Courses",
                newName: "FullMark");

            migrationBuilder.RenameColumn(
                name: "CreditHours",
                table: "Courses",
                newName: "CreditHour");
        }
    }
}
