using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using Quoridors.Models;
using Quoridors.Models.Database.Interfaces;
using Quoridors.Models.DatabaseModels;
using Quoridors.Models.Interfaces;
using Quoridors.Models.Services;

namespace QuoridorsTests.Models.Services
{
    [TestFixture]
    public class GameFactory_Tests
    {
        [Test]
        public void The_New_method_emits_the_expected_array_length()
        {
            // Arrange
            var gameRepo = new Mock<IGameRepository>();
            var playerRepo = new Mock<IPlayerRepository>();
            var playerMapper = new Mock<IPlayerDbToPlayerMapper>();
            var boardFactory = new BoardFactory();
            var gameFactory = new GameFactory(gameRepo.Object, null, boardFactory, playerRepo.Object, playerMapper.Object);
            var playerList = new []{"Jan", "Sue"};


            gameRepo.Setup(x => x.CreateGame()).Returns(new GameDb() {Id = 1});
            playerRepo.Setup(x => x.CreatePlayer(It.IsAny<PlayerDb>())).Returns(new PlayerDb("joe", 0, 0));
            playerMapper.Setup(x => x.MappingPlayer(It.IsAny<PlayerDb>())).Returns(new Player(0, "joejoe", null));

            // Act
            var newgame = gameFactory.New(playerList);

            // Assert
            Assert.That(newgame.Board.Length == 17);
        }

        [Test]
        public void The_arrays_inside_the_game_instance_returned_by_the_New_method_are_also_the_correct_length()
        {
            // Arrange
            var gameRepo = new Mock<IGameRepository>();
            var playerRepo = new Mock<IPlayerRepository>();
            var playerMapper = new Mock<IPlayerDbToPlayerMapper>();
            var boardFactory = new BoardFactory();
            var gameFactory = new GameFactory(gameRepo.Object, null, boardFactory, playerRepo.Object, playerMapper.Object);
            var playerList = new[] { "Jan", "Sue" };


            gameRepo.Setup(x => x.CreateGame()).Returns(new GameDb() { Id = 1 });
            playerRepo.Setup(x => x.CreatePlayer(It.IsAny<PlayerDb>())).Returns(new PlayerDb("joe", 0, 0));
            playerMapper.Setup(x => x.MappingPlayer(It.IsAny<PlayerDb>())).Returns(new Player(0, "joejoe", null));

            // Act
            var newgame = gameFactory.New(playerList);

            // Assert
            Assert.That(newgame.Board[0].Length == 17);
        }

        [Test]
        public void The_New_method_creates_a_game_with_an_id_of_a_given_gameDB()
        {
            //Arrange
            var gameRepo = new Mock<IGameRepository>();
            var playerRepo = new Mock<IPlayerRepository>();
            var playerMapper = new Mock<IPlayerDbToPlayerMapper>();
            var boardFactory = new BoardFactory();
            var gameFactory = new GameFactory(gameRepo.Object, null, boardFactory, playerRepo.Object, playerMapper.Object);
            var playerList = new[] { "Jan", "Sue" };
            const int gameid = 7;

            gameRepo.Setup(x => x.CreateGame()).Returns(new GameDb() { Id = gameid });
            playerRepo.Setup(x => x.CreatePlayer(It.IsAny<PlayerDb>())).Returns(new PlayerDb("joe", 0, 0));
            playerMapper.Setup(x => x.MappingPlayer(It.IsAny<PlayerDb>())).Returns(new Player(0, "joejoe", null));

            //Act
            var newgame = gameFactory.New(playerList);

            //Assert
            Assert.That(newgame.Id == gameid);
        }

        [Test]
        public void The_New_method_creates_a_game_with_turns_at_1()
        {
            //Arrange
            var gameRepo = new Mock<IGameRepository>();
            var playerRepo = new Mock<IPlayerRepository>();
            var playerMapper = new Mock<IPlayerDbToPlayerMapper>();
            var boardFactory = new BoardFactory();
            var gameFactory = new GameFactory(gameRepo.Object, null, boardFactory, playerRepo.Object, playerMapper.Object);
            var playerList = new[] { "Jan", "Sue" };


            gameRepo.Setup(x => x.CreateGame()).Returns(new GameDb() { Id = 1 });
            playerRepo.Setup(x => x.CreatePlayer(It.IsAny<PlayerDb>())).Returns(new PlayerDb("joe", 0, 0));
            playerMapper.Setup(x => x.MappingPlayer(It.IsAny<PlayerDb>())).Returns(new Player(0, "joejoe", null));

            // Act
            var newgame = gameFactory.New(playerList);

            // Assert
            Assert.That(newgame.Turn == 1);
        }

        [Test]
        public void The_New_method_creates_a_game_with_a_correct_list_of_players()
        {
            //Arrange
            var gameRepo = new Mock<IGameRepository>();
            var playerRepo = new Mock<IPlayerRepository>();
            var playerMapper = new Mock<IPlayerDbToPlayerMapper>();
            var boardFactory = new BoardFactory();
            var gameFactory = new GameFactory(gameRepo.Object, null, boardFactory, playerRepo.Object, playerMapper.Object);
            var playerList = new[] { "Jan", "Sue" };


            gameRepo.Setup(x => x.CreateGame()).Returns(new GameDb() { Id = 1 });
            playerRepo.Setup(x => x.CreatePlayer(It.IsAny<PlayerDb>())).Returns(new PlayerDb("joe", 0, 0));
            playerMapper.Setup(x => x.MappingPlayer(It.IsAny<PlayerDb>())).Returns(new Player(0, "joejoe", null));

            // Act
            var newgame = gameFactory.New(playerList);

            // Assert
            Assert.That(newgame.Players.Count() == playerList.Count());
        }

        [Test]
        public void The_Load_method_creates_a_Game_object()
        {
            //Arrange
            var gameRepo = new Mock<IGameRepository>();
            var playerRepo = new Mock<IPlayerRepository>();
            var playerMapper = new Mock<IPlayerDbToPlayerMapper>();
            var boardFactory = new BoardFactory();
            var gameFactory = new GameFactory(gameRepo.Object, null, boardFactory, playerRepo.Object, playerMapper.Object);
            var playerList = new[] { "Jan", "Sue" };


            gameRepo.Setup(x => x.CreateGame()).Returns(new GameDb() { Id = 1 });
            playerRepo.Setup(x => x.CreatePlayer(It.IsAny<PlayerDb>())).Returns(new PlayerDb("joe", 0, 0));
            playerMapper.Setup(x => x.MappingPlayer(It.IsAny<PlayerDb>())).Returns(new Player(0, "joejoe", null));

            // Act
            var newgame = gameFactory.New(playerList);

            //Assert
            Assert.IsInstanceOf<Game>(newgame);
        }
    }
}
