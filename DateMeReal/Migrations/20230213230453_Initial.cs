using Microsoft.EntityFrameworkCore.Migrations;

namespace DateMeReal.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "responses",
                columns: table => new
                {
                    EntryId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MovieName = table.Column<string>(nullable: false),
                    Category = table.Column<string>(nullable: false),
                    Year = table.Column<string>(nullable: false),
                    Director = table.Column<string>(nullable: false),
                    Rating = table.Column<string>(nullable: false),
                    LentTo = table.Column<string>(nullable: true),
                    Edited = table.Column<bool>(nullable: false),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_responses", x => x.EntryId);
                });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "EntryId", "Category", "Director", "Edited", "LentTo", "MovieName", "Notes", "Rating", "Year" },
                values: new object[] { 1, "Romance", "Damien Chazelle", false, null, "La La Land", "A really good movie that makes you think.", "PG-13", "2016" });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "EntryId", "Category", "Director", "Edited", "LentTo", "MovieName", "Notes", "Rating", "Year" },
                values: new object[] { 2, "Action/Adventure", "Brad Bird", false, null, "Ratatouille", "Vibes are unmatched.", "PG", "2007" });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "EntryId", "Category", "Director", "Edited", "LentTo", "MovieName", "Notes", "Rating", "Year" },
                values: new object[] { 3, "Action/Adventure", "Morten Tyldum", false, null, "The Imitation Game", "", "PG-13", "2014" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "responses");
        }
    }
}
