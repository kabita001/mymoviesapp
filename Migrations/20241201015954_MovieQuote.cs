using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieList.Migrations
{
    /// <inheritdoc />
    public partial class MovieQuote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Trivia",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 1,
                column: "Trivia",
                value: "Something weired happens!");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 2,
                column: "Trivia",
                value: "Wow, what a wonder woman");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 3,
                columns: new[] { "Director", "Trivia" },
                values: new object[] { "Mula", "Jackie Chan rocks" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Trivia",
                table: "Movies");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 3,
                column: "Director",
                value: "Buddha Mula");
        }
    }
}
