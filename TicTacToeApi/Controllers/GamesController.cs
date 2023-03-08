using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using TicTacToe;
using TicTacToeApi.Data;
using TicTacToeApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TicTacToeApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase {

        /// <summary>
        /// Get all games
        /// </summary>
        /// <returns>List of all games</returns>
        [HttpGet]
        public List<GameModel> Get() {
            List<GameModel> games;

            using (var db = new ApiDbContext()) {
                games = db.Games.ToList();
            }

            return games;
        }

        /// <summary>
        /// Get particular game
        /// </summary>
        /// <param name="id">Id of game you want to get</param>
        /// <returns>Game with given Id</returns>
        [HttpGet("{id}")]
        public GameModel Get(int id) {
            GameModel? game;
            using (var db = new ApiDbContext()) {
                game = db.Games.Find(id);
            }

            if(game == null) {
                BadRequest();
            }

            return game;
        }

        /// <summary>
        /// Creates a new game
        /// </summary>
        /// <returns>Id of the game you created</returns>
        [HttpPost("new")]
        public string Post() {
            int id;

            using (var db = new ApiDbContext()) {
                GameModel game = new GameModel();
                db.Games.Add(game);
                db.SaveChanges();
                id = game.Id;
            }

            return "{\"Id\": " + id + "}";
        }

        /// <summary>
        /// Makes a turn in specified game
        /// </summary>
        /// <param name="id">Id of a game</param>
        /// <param name="turn">Position of your turn</param>
        /// <returns>Game condition after given turn</returns>
        [HttpPut("{id}")]
        public GameModel Put(int id, [FromBody] TurnModel turn) {
            (bool, string) result;

            using (var db = new ApiDbContext()) {
                GameModel game = db.Games.Find(id);
                if (game != null) {
                    char[][] field = game.FieldArray;
                    result = GameManager.NewTurn(field, game.Status, turn.PosX, turn.PosY);
                    if (result.Item1) {
                        field[turn.PosX][turn.PosY] = (game.Status == GameStatus.PlayerOneTurn ? 'X' : '0');
                        game.FieldArray = field;
                        game.Status = result.Item2;
                        db.SaveChanges();
                    }
                }
                return game;
            }
        }

        /// <summary>
        /// Deletes a specified game
        /// </summary>
        /// <param name="id">Of a game to delete</param>
        [HttpDelete("{id}")]
        public void Delete(int id) {
            GameModel model;
            using (var db = new ApiDbContext()) {
                model = db.Games.Find(id);
                if (model != null) {
                    db.Remove(model);
                    db.SaveChanges();
                }
            }
        }
    }
}
