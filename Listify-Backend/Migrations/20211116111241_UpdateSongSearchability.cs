using Microsoft.EntityFrameworkCore.Migrations;

namespace Listify_Backend.Migrations
{
    public partial class UpdateSongSearchability : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SongLocationInPlaylist",
                table: "Songs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SongLocationInPlaylist",
                table: "Songs");
        }
    }
}
