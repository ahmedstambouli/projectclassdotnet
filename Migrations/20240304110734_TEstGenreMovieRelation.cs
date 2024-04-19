using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace seance2.Migrations
{
    public partial class TEstGenreMovieRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "genersId",
                table: "movies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CustomerMovie",
                columns: table => new
                {
                    customersId = table.Column<int>(type: "int", nullable: false),
                    movieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerMovie", x => new { x.customersId, x.movieId });
                    table.ForeignKey(
                        name: "FK_CustomerMovie_customers_customersId",
                        column: x => x.customersId,
                        principalTable: "customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerMovie_movies_movieId",
                        column: x => x.movieId,
                        principalTable: "movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Geners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Geners", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_movies_genersId",
                table: "movies",
                column: "genersId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerMovie_movieId",
                table: "CustomerMovie",
                column: "movieId");

            migrationBuilder.AddForeignKey(
                name: "FK_movies_Geners_genersId",
                table: "movies",
                column: "genersId",
                principalTable: "Geners",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movies_Geners_genersId",
                table: "movies");

            migrationBuilder.DropTable(
                name: "CustomerMovie");

            migrationBuilder.DropTable(
                name: "Geners");

            migrationBuilder.DropIndex(
                name: "IX_movies_genersId",
                table: "movies");

            migrationBuilder.DropColumn(
                name: "genersId",
                table: "movies");
        }
    }
}
