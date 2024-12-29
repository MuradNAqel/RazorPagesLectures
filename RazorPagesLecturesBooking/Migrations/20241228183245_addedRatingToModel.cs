using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RazorPagesLecturesBooking.Migrations
{
    /// <inheritdoc />
    public partial class addedRatingToModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Rating",
                table: "Lecture",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Lecture");
        }
    }
}
