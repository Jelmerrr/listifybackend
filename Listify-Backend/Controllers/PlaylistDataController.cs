using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Listify_Backend.DataModels;
using Listify_Backend.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;

namespace Listify_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors]
    public class PlaylistDataController : ControllerBase
    {
        public static HubConnection _connection;

        public PlaylistDataController()
        {  
            if (_connection == null || _connection.State == HubConnectionState.Disconnected)
            {
                _connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:44337/playlistHub")
                .Build();
                _connection.StartAsync();
                _connection.On<String>("SendMethod", a =>
                {
                    Console.WriteLine(a);
                });
            }
        }
        [HttpGet]
        public IActionResult getPlaylist()
        {
            DAL.PlaylistDataDAL playlistDataDAL = new DAL.PlaylistDataDAL();
            var playlists = playlistDataDAL.GetPlaylists();
            return Ok(playlists);
        }

        [HttpPost]
        public IActionResult makePlaylist()
        {
            DAL.PlaylistDataDAL playlistDataDAL = new DAL.PlaylistDataDAL();
            int playlistCode = playlistDataDAL.GeneratePlaylistCode();
            var songsList = new List<Songs>()
                {
                    new Songs()
                    {
                        SongArtist = "Marco Borsato",
                        SongTitle = "Rood",
                        SongGenre = Enums.Genre.Classical,
                        SongLocationInPlaylist = playlistCode
                    },
                    new Songs()
                    {
                        SongArtist = "a",
                        SongTitle = "b",
                        SongGenre = Enums.Genre.Classical,
                        SongLocationInPlaylist = playlistCode
                    }
                };

            playlistDataDAL.CreatePlaylist("Test", songsList, playlistCode, "Placeholder 1", "Placeholder 2");
            return Ok();
        }

        [HttpPost]
        [Route("api/[controller]/{playlistName}")]
        public async Task<IActionResult> latestList(string playlistName)
        {
            await _connection.InvokeAsync("SendPlaylist", playlistName);
            return Ok();
        }


    }
}
