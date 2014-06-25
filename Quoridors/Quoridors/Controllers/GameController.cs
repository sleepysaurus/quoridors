using System.Web.Mvc;
using Antlr.Runtime;
using Quoridors.Models;
using Quoridors.Models.Database;
using Quoridors.Models.Database.Interfaces;
using Quoridors.Models.DatabaseModels;
using Quoridors.Models.Interfaces;
using Quoridors.Models.Services;

namespace Quoridors.Controllers
{
    public class GameController : Controller
    {
        private readonly IBoardStateUpdater _boardStateUpdater;
        private readonly IGameFactory _gameFactory;
        private readonly IBoardToJsonMapper _boardToJsonMapper;
        private readonly IWallRepository _wallRepository;
        private readonly IPositionRepository _positionRepository;
        private readonly IGameRepository _gameRepository;

        public GameController(IBoardStateUpdater boardStateUpdater, IGameFactory gameFactory,
            IBoardToJsonMapper boardToJsonMapper, IWallRepository wallRepository, IPositionRepository positionRepository, IGameRepository gameRepository)
        {
            _boardStateUpdater = boardStateUpdater;
            _gameFactory = gameFactory;
            _boardToJsonMapper = boardToJsonMapper;
            _wallRepository = wallRepository;
            _positionRepository = positionRepository;
            _gameRepository = gameRepository;
        }

        [HttpGet]
        public JsonResult NewGame() 
        {  
            
            Game game = _gameFactory.New(new []{"Jim", "Barry"});

            foreach (var player in game.Players)
            {
                var positionDb = new PositionDb(player.Id, player.Position.Horizontal, player.Position.Vertical, game.Id);
                _positionRepository.Create(positionDb);
            }            

            var convertedgame = _boardToJsonMapper.CreateBoardObject(game);
            return Json(convertedgame, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult MovePlayer(PositionDb position)
        {
            var game = _gameFactory.Load(position.GameId);
            game.Board = _boardStateUpdater.MovePlayer(position, game).Board;
            game.Turn += 1;
            _gameRepository.UpdateGame(game);
            _positionRepository.Update(position);
            var boardToReturn = _boardToJsonMapper.CreateBoardObject( game);
            return Json(boardToReturn, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult PlaceWall(WallDb wall)
        {
            var game = _gameFactory.Load(wall.GameId);
            game.Board = _boardStateUpdater.AddWall(wall, game).Board;
            game.Turn += 1;
            _gameRepository.UpdateGame(game);
            _wallRepository.CreateWall(wall);
            var boardToReturn = _boardToJsonMapper.CreateBoardObject(game);
            return Json(boardToReturn, JsonRequestBehavior.AllowGet);
        }
    }
}