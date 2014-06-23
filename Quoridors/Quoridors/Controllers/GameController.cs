using System.Web.Mvc;
using Quoridors.Models;
using Quoridors.Models.DatabaseModels;

namespace Quoridors.Controllers
{
    public class GameController : Controller
    {
        public string[][] Board { get; set; }
        private readonly JsonToBoardMapper _boardMapper = new JsonToBoardMapper();

        public GameController(string[][] board)
        {
            Board = board;
        }

        [HttpGet]
        public JsonResult NewGame()
        {
            var player1 = new Player(1, "John");
            var player2 = new Player(2, "Samantha");
            var players = new Player[]
            {
                player1,
                player2
            };
            return Json(players, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public bool MovePlayer(Move move)
        {
            var newBoard = _boardMapper.MovePlayer(move, Board);
            return true;
        }

        [HttpPost]
        public bool PlaceWall(WallDb wall)
        {
            var newBoard = _boardMapper.AddWall(wall, Board);
            return true;
        }
    }
}