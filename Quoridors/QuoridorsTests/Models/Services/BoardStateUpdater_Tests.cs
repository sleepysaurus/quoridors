﻿using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Quoridors.Models;
using Quoridors.Models.Database;
using Quoridors.Models.Database.Interfaces;
using Quoridors.Models.DatabaseModels;
using Quoridors.Models.Services;

namespace QuoridorsTests.Models.Services
{
    [TestFixture]
    class BoardStateUpdater_Tests
    {
        private Game game; // BA either have this as the expected values, or don't
        private BoardFactory boardFactory;

        [TestFixtureSetUp]
        public void TestSetup()
        {
            boardFactory = new BoardFactory();
            game = new Game(1, 1, boardFactory.CreateBoard());
            game.Board[6][7] = BoardCellStatus.Wall;
            game.Board[8][7] = BoardCellStatus.Wall;
        }

        [Test]
        public void AddWall_method_adds_a_wall_in_the_correct_position()
        {
            // Arrange
            var cut = new BoardStateUpdater(null, null, null);
            var wall = new WallDb(3,4,0,1);
            
            // Act
            var newGame = cut.AddWall(wall, new Game(1,1, boardFactory.CreateBoard()));

            // Assert
            Assert.That(newGame.Board, Is.EqualTo(game.Board));
        }

        [Test]
        public void MovePlayer_method_removes_original_player_position()
        {
            // Arrange
            game.Board[6][8] = BoardCellStatus.Player1;
            var playerRepo = new Mock<IPlayerRepository>();
            var position = new PositionDb(1, 3, 4, 1);
            playerRepo.Setup(x => x.GetPosition(It.IsAny<int>())).Returns(position);
            var cut = new BoardStateUpdater(null, null, playerRepo.Object);

            // Act
            var newPositon = new PositionDb(1, 3, 3, 1);
            var newGame = cut.MovePlayer(newPositon, game);

            // Assert
            Assert.That(newGame.Board[6][8], Is.EqualTo(BoardCellStatus.NoPlayer));
        }

        [Test]
        public void MovePlayer_correctly_adds_new_player_position()
        {
            // Arrange
            var playerRepo = new Mock<IPlayerRepository>();
            var position = new PositionDb(1, 3, 4, 1);
            playerRepo.Setup(x => x.GetPosition(It.IsAny<int>())).Returns(position);
            var cut = new BoardStateUpdater(null, null, playerRepo.Object);

            // Act
            var newPositon = new PositionDb(1, 3, 3, 1);
            var newGame = cut.MovePlayer(newPositon, game);

            // Assert
            Assert.That(newGame.Board[6][6], Is.EqualTo(BoardCellStatus.Player1).Or.EqualTo(BoardCellStatus.Player2));
        }

        [Test]
        public void UpdateBoardToSavedState_correctly_updates_a_board_with_one_wall_and_one_player()
        {
            // Arrange
            var testGame = new Game(1,1, boardFactory.CreateBoard());
            testGame.Board[6][7] = BoardCellStatus.Wall;
            testGame.Board[8][7] = BoardCellStatus.Wall;
            testGame.Board[6][8] = BoardCellStatus.Player1;

            var positonRepo = new Mock<IPositionRepository>();
            var wallRepository = new Mock<IWallRepository>();
            positonRepo.Setup(x => x.GetByGame(It.IsAny<int>()))
                .Returns(new List<PositionDb>() {new PositionDb(1, 3, 4, 1)});
            wallRepository.Setup(x => x.GetByGameId(It.IsAny<int>())).Returns(new List<WallDb> {new WallDb(3, 4, 0, 1)});
            var cut = new BoardStateUpdater(positonRepo.Object, wallRepository.Object, null);

            // Act
            var newGame = new Game(1, 1, boardFactory.CreateBoard());
            cut.UpdateBoardToSavedState(newGame);

            // Assert
            Assert.That(newGame.Board, Is.EqualTo(testGame.Board));
        }
    }
}