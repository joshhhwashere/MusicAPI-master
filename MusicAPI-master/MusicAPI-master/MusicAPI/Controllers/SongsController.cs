using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicAPI.Models;
using System.Runtime.CompilerServices;

namespace MusicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private static List<Song> _songs = new List<Song>
        {
            new Song
            {
                ID = 1,
                Title = "Almost Home",
                Language = "English"
            },
            new Song
            {
                ID = 2,
                Title = "Yeah",
                Language = "English"
            },
            new Song
            {
                ID = 3,
                Title = "Entre Nosotros",
                Language = "Español"
            }


        };

        [HttpGet]//Mediante este controlador podemos hacer la petición
        public IEnumerable<Song> GetAllSongs()
        {
            return _songs;
        }
        //Get api/songscontroller/0
        [HttpGet("{ID}")]
        //Al consultar por el ID, nos devuelva una canción en específico
        public Song GetSongByID(int ID)
        {
            return _songs.Find(song => song.ID == ID);
        }
        [HttpPost]
        //Vamos a usar algo llamado ActionResulta
        public IActionResult SaveOneSong([FromBody] Song newsong)
        {
            _songs.Add(newsong);
            return Ok();
        }
        [HttpPut("{ID}/{newTitle}")]
        public IActionResult UpdateSong(int ID, string newTitle)
        {
            var song = _songs.Find(song => song.ID == ID);
            song.Title = newTitle;

            return Ok();
        }

        //Put api/song/0
        [HttpPut("{ID}")]
        public IActionResult UpdateSong(int ID,[FromBody] Song updatedSong)
        {
            var song = _songs.Find(song => song.ID == ID);

            song.Title = updatedSong.Title;
            song.Language = updatedSong.Language; 

            return Ok();
        }
        //Debemos de hacer el método eliminar


        [HttpDelete("{ID}")]
        public ActionResult DeleteSong(int ID)
        {
            var song = _songs.Find(song => song.ID == ID);
            _songs.Remove(song);

            return Ok();
        }

    }
}
