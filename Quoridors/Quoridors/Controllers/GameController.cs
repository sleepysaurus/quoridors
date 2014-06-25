using System.Web.Mvc;
using Quoridors.Models;
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
        private readonly IPlayerRepository _playerRepository;

        public GameController(IBoardStateUpdater boardStateUpdater, IGameFactory gameFactory,
            IBoardToJsonMapper boardToJsonMapper, IWallRepository wallRepository, IPositionRepository positionRepository, IPlayerRepository playerRepository)
        {
            _boardStateUpdater = boardStateUpdater;
            _gameFactory = gameFactory;
            _boardToJsonMapper = boardToJsonMapper;
            _wallRepository = wallRepository;
            _positionRepository = positionRepository;
            _playerRepository = playerRepository;
        }

        [HttpGet]
        public JsonResult NewGame()
        {
            
            Game game = _gameFactory.New();


            var player1 = new PlayerDb(game.Players[0].PlayerName, game.Id);
            var player2 = new PlayerDb(game.Players[1].PlayerName, game.Id);

            player1.Id = _playerRepository.CreatePlayer(player1).Id;
            player2.Id = _playerRepository.CreatePlayer(player2).Id;

            var position1 = new PositionDb(game.Players[0].Id, game.Players[0].Position.Horizontal, game.Players[0].Position.Vertical, game.Id);
            var position2 = new PositionDb(game.Players[1].Id, game.Players[1].Position.Horizontal, game.Players[1].Position.Vertical, game.Id);

            _positionRepository.Create(position1);
            _positionRepository.Create(position2);

            var convertedgame = _boardToJsonMapper.CreateBoardObject(game.Board, game);
            return Json(convertedgame, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult MovePlayer(PositionDb position)
        {
            var game = _gameFactory.Load(position.GameId);
            var newBoard = _boardStateUpdater.MovePlayer(position, game).Board;
            
            _positionRepository.Update(position);
            var boardToReturn = _boardToJsonMapper.CreateBoardObject(newBoard, game);
            return Json(boardToReturn, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult PlaceWall(WallDb wall)
        {
            var game = _gameFactory.Load(wall.GameId);
            var newBoard = _boardStateUpdater.AddWall(wall, game).Board;
            _wallRepository.CreateWall(wall);
            var boardToReturn = _boardToJsonMapper.CreateBoardObject(newBoard, game);
            return Json(boardToReturn, JsonRequestBehavior.AllowGet);
        }
    }
}