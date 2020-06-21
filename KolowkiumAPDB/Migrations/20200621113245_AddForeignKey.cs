using Microsoft.EntityFrameworkCore.Migrations;

namespace KolowkiumAPDB.Migrations
{
    public partial class AddForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Albums_AlbumIdAlbum",
                table: "Tracks");

            migrationBuilder.DropIndex(
                name: "IX_Tracks_AlbumIdAlbum",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "AlbumIdAlbum",
                table: "Tracks");

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_IdMusicAlbum",
                table: "Tracks",
                column: "IdMusicAlbum");

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Albums_IdMusicAlbum",
                table: "Tracks",
                column: "IdMusicAlbum",
                principalTable: "Albums",
                principalColumn: "IdAlbum",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Albums_IdMusicAlbum",
                table: "Tracks");

            migrationBuilder.DropIndex(
                name: "IX_Tracks_IdMusicAlbum",
                table: "Tracks");

            migrationBuilder.AddColumn<int>(
                name: "AlbumIdAlbum",
                table: "Tracks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_AlbumIdAlbum",
                table: "Tracks",
                column: "AlbumIdAlbum");

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Albums_AlbumIdAlbum",
                table: "Tracks",
                column: "AlbumIdAlbum",
                principalTable: "Albums",
                principalColumn: "IdAlbum",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
