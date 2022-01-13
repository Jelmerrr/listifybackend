using Microsoft.EntityFrameworkCore.Migrations;

namespace Listify_Backend.Migrations
{
    public partial class TestSystemForPlaylistSongSync : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlaylistCode",
                table: "Playlists",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlaylistCode",
                table: "Playlists");
        }
    }
}
