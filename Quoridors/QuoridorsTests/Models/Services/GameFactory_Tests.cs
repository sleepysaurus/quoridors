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
            var boardFactory = new BoardFactory();
            gameRepo.Setup(x => x.CreateGame()).Returns(new GameDb() {Id = 1});
            var gameFactory = new GameFactory(null, gameRepo.Object, null, boardFactory);

            // Act
            var newgame = gameFactory.New();

            // Assert
            Assert.That(newgame.Board.Length == 17);
        }

        [Test]
        public void The_arrays_for_the_game_inside_the_New_method_are_also_the_correct_length()
        {
            // Arrange
            var gameRepo = new Mock<IGameRepository>();
            gameRepo.Setup(x => x.CreateGame()).Returns(new GameDb() { Id = 1 });
            var boardFactory = new BoardFactory();
            
            var gameFactory = new GameFactory(null, gameRepo.Object, null, boardFactory);
            var testgame = new GameDb { Id = 7 };
            

            // Act
            var newgame = gameFactory.New();

            // Assert
            Assert.That(newgame.Board[0].Length == 17);
        }

        [Test]
        public void The_New_method_creates_a_game_with_an_id_of_a_given_gameID()
        {
            //Arrange
            var gameRepoforId = Mock.Of<IGameRepository>();
            var boardFactory = new BoardFactory();
            Mock.Get(gameRepoforId).Setup(game => game.CreateGame()).Returns(new GameDb() {Id = 7});
            var gamefactory = new GameFactory(null, gameRepoforId, null, boardFactory);

            //Act
            var newgame = gamefactory.New();

            //Assert
            Assert.That(newgame.Id == 7);
        }

        [Test]
        public void The_New_method_creates_a_game_with_turns_at_1()
        {
            //Arrange
            var gameRepo = new Mock<IGameRepository>();
            var boardFactory = new BoardFactory();
            gameRepo.Setup(game => game.CreateGame()).Returns(new GameDb() {Id = 7});
            var gameFactory = new GameFactory(null, gameRepo.Object, null, boardFactory);

            // Act
            var newgame = gameFactory.New();

            // Assert
            Assert.That(newgame.Turn == 1);
        }

        [Test]
        public void The_New_method_creates_a_game_with_a_correct_list_of_players()
        {
            //Arrange
            var gameRepo = new Mock<IGameRepository>();
            var boardFactory = new BoardFactory();
            gameRepo.Setup(game => game.CreateGame()).Returns(new GameDb() {Id = 7});
            var gameFactory = new GameFactory(null, gameRepo.Object, null, boardFactory);

            // Act
            var newgame = gameFactory.New();

            // Assert
            Assert.That(newgame.Players.Count == 2);
        }

        [Test]
        public void The_Load_method_creates_a_Game_object()
        {
            //Arrange
            var placeholderGame = new Game(1,1,new BoardFactory().CreateBoard()) {Id = 7};
            var testgame = new GameDb { Id = 7 };

            var gameRepoforId = Mock.Of<IGameRepository>();
            Mock.Get(gameRepoforId).Setup(game => game.CreateGame()).Returns(testgame);
            var gameMapper = Mock.Of<IGameDbMapperToGame>();
            Mock.Get(gameMapper)
                .Setup(mapper => mapper.MappingGameFromDatabase(It.IsAny<GameDb>()))
                .Returns(placeholderGame);
            var gameStateUpdater = Mock.Of<IBoardStateUpdater>();
            var gamefactory = new GameFactory(gameStateUpdater, gameRepoforId, gameMapper, null);

            //Act
            var newgame = gamefactory.Load(7);

            //Assert
            Assert.IsInstanceOf<Game>(newgame);
        }
    }
}
