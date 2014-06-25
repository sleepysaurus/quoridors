using System.Threading;
using System.Web.Mvc;
using Quoridors.Models.Database;
using Quoridors.Models.Database.Interfaces;
using Quoridors.Models.DatabaseModels;
using Quoridors.Models.Interfaces;

namespace Quoridors.Controllers
{
    public class GameController : Controller
    {
        private readonly IBoardStateUpdater _boardStateUpdater;
        private readonly IGameFactory _gameFactory;
        private readonly IBoardToJsonMapper _boardToJsonMapper;
        private readonly IWallRepository _wallRepository;
        private readonly IPositionRepository _positionRepository;

        public GameController(IBoardStateUpdater boardStateUpdater, IGameFactory gameFactory,
            IBoardToJsonMapper boardToJsonMapper, IWallRepository wallRepository, IPositionRepository positionRepository)
        {
            _boardStateUpdater = boardStateUpdater;
            _gameFactory = gameFactory;
            _boardToJsonMapper = boardToJsonMapper;
            _wallRepository = wallRepository;
            _positionRepository = positionRepository;
        }

        [HttpGet]
        public JsonResult NewGame()
        {            
            var game = _gameFactory.New();           
            return Json(game, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult MovePlayer(PositionDb position)
        {
            var game = _gameFactory.Load(position.GameId);
            game.Board = _boardStateUpdater.MovePlayer(position, game).Board;
            
            _positionRepository.Update(position);
            var boardToReturn = _boardToJsonMapper.CreateBoardObject( game);
            return Json(boardToReturn, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult PlaceWall(WallDb wall)
        {
            var game = _gameFactory.Load(wall.GameId);
            game.Board = _boardStateUpdater.AddWall(wall, game).Board;
            _wallRepository.CreateWall(wall);
            var boardToReturn = _boardToJsonMapper.CreateBoardObject(game);
            return Json(boardToReturn, JsonRequestBehavior.AllowGet);
        }
    }
}