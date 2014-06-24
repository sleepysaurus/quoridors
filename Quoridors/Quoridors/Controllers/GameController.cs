using System.Linq.Expressions;
using System.Web.Mvc;
using Quoridors.Models;
using Quoridors.Models.Database;
using Quoridors.Models.DatabaseModels;

namespace Quoridors.Controllers
{
    public class GameController : Controller
    {
        private readonly IBoardStateUpdater _boardStateUpdater;
        private readonly IGameFactory _gameFactory;
        private readonly BoardToJsonMapper _boardToJsonMapper = new BoardToJsonMapper();
        private readonly WallRepository _wallRepo = new WallRepository();
        private readonly PositionRepository _positionRepo = new PositionRepository();

        public GameController(IBoardStateUpdater boardStateUpdater)
        {
            _boardStateUpdater = boardStateUpdater;
        }
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
        public JsonResult MovePlayer(PositionDb position)
        {
            var game = _gameFactory.Load(position.GameId);
            var newBoard = _boardStateUpdater.MovePlayer(position, game).Board;
            _positionRepo.Update(position);
            var boardToReturn = _boardToJsonMapper.CreateBoardObject(newBoard);
            return Json(boardToReturn, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult PlaceWall(WallDb wall)
        {
            var game = _gameFactory.Load(wall.GameId);
            var newBoard = _boardStateUpdater.AddWall(wall, game).Board;
            _wallRepo.CreateWall(wall);
            var boardToReturn = _boardToJsonMapper.CreateBoardObject(newBoard);
            return Json(boardToReturn, JsonRequestBehavior.AllowGet);
        }
    }
}