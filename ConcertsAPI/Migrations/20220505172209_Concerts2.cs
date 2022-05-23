using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConcertsAPI.Migrations
{
    public partial class Concerts2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtistConcert_Concert_ConcertsId",
                table: "ArtistConcert");

            migrationBuilder.DropForeignKey(
                name: "FK_Concert_City_CityId",
                table: "Concert");

            migrationBuilder.DropForeignKey(
                name: "FK_Concert_Genre_GenreId",
                table: "Concert");

            migrationBuilder.DropForeignKey(
                name: "FK_Concert_Venue_VenueId",
                table: "Concert");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Concert",
                table: "Concert");

            migrationBuilder.RenameTable(
                name: "Concert",
                newName: "Concerts");

            migrationBuilder.RenameIndex(
                name: "IX_Concert_VenueId",
                table: "Concerts",
                newName: "IX_Concerts_VenueId");

            migrationBuilder.RenameIndex(
                name: "IX_Concert_GenreId",
                table: "Concerts",
                newName: "IX_Concerts_GenreId");

            migrationBuilder.RenameIndex(
                name: "IX_Concert_CityId",
                table: "Concerts",
                newName: "IX_Concerts_CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Concerts",
                table: "Concerts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistConcert_Concerts_ConcertsId",
                table: "ArtistConcert",
                column: "ConcertsId",
                principalTable: "Concerts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Concerts_City_CityId",
                table: "Concerts",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Concerts_Genre_GenreId",
                table: "Concerts",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Concerts_Venue_VenueId",
                table: "Concerts",
                column: "VenueId",
                principalTable: "Venue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtistConcert_Concerts_ConcertsId",
                table: "ArtistConcert");

            migrationBuilder.DropForeignKey(
                name: "FK_Concerts_City_CityId",
                table: "Concerts");

            migrationBuilder.DropForeignKey(
                name: "FK_Concerts_Genre_GenreId",
                table: "Concerts");

            migrationBuilder.DropForeignKey(
                name: "FK_Concerts_Venue_VenueId",
                table: "Concerts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Concerts",
                table: "Concerts");

            migrationBuilder.RenameTable(
                name: "Concerts",
                newName: "Concert");

            migrationBuilder.RenameIndex(
                name: "IX_Concerts_VenueId",
                table: "Concert",
                newName: "IX_Concert_VenueId");

            migrationBuilder.RenameIndex(
                name: "IX_Concerts_GenreId",
                table: "Concert",
                newName: "IX_Concert_GenreId");

            migrationBuilder.RenameIndex(
                name: "IX_Concerts_CityId",
                table: "Concert",
                newName: "IX_Concert_CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Concert",
                table: "Concert",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistConcert_Concert_ConcertsId",
                table: "ArtistConcert",
                column: "ConcertsId",
                principalTable: "Concert",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Concert_City_CityId",
                table: "Concert",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Concert_Genre_GenreId",
                table: "Concert",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Concert_Venue_VenueId",
                table: "Concert",
                column: "VenueId",
                principalTable: "Venue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
