using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Quoridors.Controllers;
using Quoridors.Models;
using Quoridors.Models.Database;
using Quoridors.Models.Database.Interfaces;
using Quoridors.Models.DatabaseModels;
using Quoridors.Models.Interfaces;
using Quoridors.Models.Services;

namespace QuoridorsTests.Models.Services
{
    [TestFixture]
    public class GameFactory_Tests
    {
        public static IGameRepository GameRepo = Mock.Of<IGameRepository>();
        public GameFactory Gamefactory = new GameFactory(null, GameRepo, null);

        [Test]
        public void The_New_method_emits_the_expected_array_length()
        {
            // Arrange

            // Act
            var newgame = Gamefactory.New();

            // Assert
            Assert.That(newgame.Board.Length == 17);
        }

        [Test]
        public void The_arrays_for_the_game_inside_the_New_method_are_also_the_correct_length()
        {
            // Arrange

            // Act
            var newgame = Gamefactory.New();

            // Assert
            Assert.That(newgame.Board[0].Length == 17);
        }

        [Test]
        public void The_New_method_creates_a_game_with_an_id_of_a_given_gameID()
        {
            //Arrange
            var testgame = new GameDb {Id = 7};
            var gameRepoforId = Mock.Of<IGameRepository>();
            Mock.Get(gameRepoforId).Setup(game => game.CreateGame()).Returns(7);
            var gamefactory = new GameFactory(null, gameRepoforId, null);

            //Act
            var newgame = gamefactory.New();

            //Assert
            Assert.That(newgame.Id == 7);
        }

        [Test]
        public void The_New_method_creates_a_game_with_turns_at_1()
        {
            //Arrange

            // Act
            var newgame = Gamefactory.New();

            // Assert
            Assert.That(newgame.Turn == 1);
        }

        [Test]
        public void The_New_method_creates_a_game_with_a_correct_list_of_players()
        {
            //Arrange

            // Act
            var newgame = Gamefactory.New();

            // Assert
            Assert.That(newgame.Players.Count == 2);
        }

        [Test]
        public void The_Load_method_creates_a_Game_object()
        {
            //Arrange
            var placeholderGame = new Game() {Id = 7};
            var gameRepoforId = Mock.Of<IGameRepository>();
            Mock.Get(gameRepoforId).Setup(game => game.CreateGame()).Returns(7);
            var gameMapper = Mock.Of<IGameDbMapperToGame>();
            Mock.Get(gameMapper)
                .Setup(mapper => mapper.MappingGameFromDatabase(It.IsAny<GameDb>()))
                .Returns(placeholderGame);
            var gameStateUpdater = Mock.Of<IBoardStateUpdater>();
            var gamefactory = new GameFactory(gameStateUpdater, gameRepoforId, gameMapper);

            //Act
            var newgame = gamefactory.Load(7);

            //Assert
            Assert.IsInstanceOf<Game>(newgame);

        }
    }
}
