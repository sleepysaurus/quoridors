using System.Linq.Expressions;
using System.Web.Mvc;
using Quoridors.Models;
using Quoridors.Models.Database;
using Quoridors.Models.DatabaseModels;

namespace Quoridors.Controllers
{
    public class GameController : Controller
    {
        private readonly BoardStateUpdater _boardStateUpdater = new BoardStateUpdater();

        [HttpGet]
        public JsonResult NewGame()
        {
            var player1 = new Player(1, "John");
            var player2 = new Player(2, "Samantha");
            var players = new[]
            {
                player1,
                player2
            };
            // TODO use gamefactory to create a new game, save it to the DB, send it back to the client

            return Json(players, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public bool MovePlayer(Move move) // BA not a bool return; send back the board state
        {
            
           // TODO load game
            // TODO map a GameDb to game???

            var newBoard = _boardStateUpdater.MovePlayer(move, game);

            // TODO get the gamerepository to save the new state - probably just save the new move
            // TODO get the BoardToJsonMapper to serialize the board to Json
            // TODO send the bugger back to the client

            return true;
        }

        [HttpPost]
        public bool PlaceWall(WallDb wall)
        {
            var newBoard = _boardStateUpdater.AddWall(wall, someBoard);

            // TODO ditto all the stuff in MovePlayer
            return true;
        }
    }
}