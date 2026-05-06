using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Modul10_103022400086;


namespace Modul10_103022400086
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private static List<Game> _games = new List<Game>
        {
            new Game { id = 1, nama = "Valorant", developer = "Riot Games", tahun = 2020, genre = "FPS", rating = 8.5, platform = ["PC"], mode = ["Multiplayer"], isonline = true, harga = 0  },
            new Game { id = 2, nama = "GTA V", developer = "Rockstar Games", tahun = 2013, genre = "Open World", rating = 9.5, platform = ["PC", "PS4", "PS5", "Xbox"], mode = ["Multiplayer", "Singleplayer"], isonline = true, harga = 300000  },
            new Game { id = 3, nama = "The Witcher 3", developer = "CD Projekt Red", tahun = 2015, genre = "RPG", rating = 9.5, platform =  ["PC", "PS4", "PS5", "Xbox"], mode = ["SinglePlayer"], isonline = false, harga = 250000  },

        };

        [HttpGet]
        public IEnumerable<Game> Get()
        {
            return _games;
        }

        [HttpGet("{id}")]

        public ActionResult<Game> Get(int id)
        {
            var game = _games.FirstOrDefault(g => g.id == id);
            if (game == null) return NotFound();
            return game;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Game newgame)
        {
            _games.Add(newgame);
            return Ok();

        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var game = _games.FirstOrDefault(g => g.id == id);
            if (game == null) return NotFound();

            _games.Remove(game);
            return Ok();
        }
    }
}
