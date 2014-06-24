﻿using Moq;
using NUnit.Framework;
using Quoridors.Models.Database.Interfaces;
using Quoridors.Models.DatabaseModels;
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
            Assert.That(newgame.Players.Count == 2 );
        } 
    }
}
