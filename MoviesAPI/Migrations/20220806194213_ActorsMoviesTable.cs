using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesAPI.Migrations
{
    public partial class ActorsMoviesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageURI",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "TrailerURL",
                table: "Movies");

            migrationBuilder.AlterColumn<string>(
                name: "Budget",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "BoxOffice",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Budget",
                table: "Movies",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "BoxOffice",
                table: "Movies",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ImageURI",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrailerURL",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
