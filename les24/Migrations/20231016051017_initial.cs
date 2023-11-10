using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaTheater.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Director = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Style = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShowTime = table.Column<string>(type: "VARCHAR(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieShows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "INT", nullable: false),
                    ShowId = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieShows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieShows_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieShows_Shows_ShowId",
                        column: x => x.ShowId,
                        principalTable: "Shows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Name", "Style" },
                values: new object[,]
                {
                    { 1, "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.", "Frank Darabont", "The Shawshank Redemption", "Drama" },
                    { 2, "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.", "Francis Ford Coppola", "The Godfather", "Crime, Drama" },
                    { 3, "When the menace known as The Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham.", "Christopher Nolan", "The Dark Knight", "Action, Crime, Drama" },
                    { 4, "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.", "Quentin Tarantino", "Pulp Fiction", "Crime, Drama" },
                    { 5, "The presidencies of Kennedy and Johnson, the events of Vietnam, Watergate, and other historical events unfold through the perspective of an Alabama man with an IQ of 75.", "Robert Zemeckis", "Forrest Gump", "Drama, Romance" },
                    { 6, "A computer programmer who discovers that reality as he knows it is a simulation created by machines to subjugate humanity.", "The Wachowskis", "The Matrix", "Action, Sci-Fi" },
                    { 7, "A thief who enters the dreams of others to obtain information is tasked with planting an idea into the mind of a CEO.", "Christopher Nolan", "Inception", "Action, Adventure, Sci-Fi" },
                    { 8, "A young hobbit, Frodo, who has been entrusted with an ancient ring, must journey to Mount Doom to destroy it.", "Peter Jackson", "The Lord of the Rings: The Fellowship of the Ring", "Action, Adventure, Drama" },
                    { 9, "The early life and career of Vito Corleone in 1920s New York is portrayed while his son, Michael, expands and tightens his grip on the family crime syndicate.", "Francis Ford Coppola", "The Godfather: Part II", "Crime, Drama" },
                    { 10, "In German-occupied Poland during World War II, Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.", "Steven Spielberg", "Schindler's List", "Biography, Drama, History" }
                });

            migrationBuilder.InsertData(
                table: "Shows",
                columns: new[] { "Id", "ShowTime" },
                values: new object[,]
                {
                    { 1, "11" },
                    { 2, "13" },
                    { 3, "15" },
                    { 4, "17" },
                    { 5, "19" },
                    { 6, "21" }
                });

            migrationBuilder.InsertData(
                table: "MovieShows",
                columns: new[] { "Id", "MovieId", "ShowId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 2, 2 },
                    { 4, 3, 3 },
                    { 5, 3, 4 },
                    { 6, 4, 5 },
                    { 7, 5, 6 },
                    { 8, 6, 1 },
                    { 9, 7, 3 },
                    { 10, 8, 4 },
                    { 11, 8, 6 },
                    { 12, 9, 2 },
                    { 13, 9, 5 },
                    { 14, 10, 1 },
                    { 15, 10, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieShows_MovieId",
                table: "MovieShows",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieShows_ShowId",
                table: "MovieShows",
                column: "ShowId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieShows");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Shows");
        }
    }
}
