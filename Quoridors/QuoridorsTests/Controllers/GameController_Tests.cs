using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using Quoridors.Controllers;
using Quoridors.Models;
using Quoridors.Models.Database;
using Quoridors.Models.DatabaseModels;
using Quoridors.Models.Interfaces;
using Quoridors.Models.Services;

namespace QuoridorsTests.Controllers
{
    [TestFixture]
    public class GameController_Tests
    {
        [Test]
        public void The_NewGame_method_gets_a_new_game_from_the_gameFactory()
        {
            // Arrange
            var mock = new Mock<IGameFactory>();
            var sut = new GameController(null, mock.Object, null, null, null);

            // Act
            mock.Setup(x => x.New()).Returns(new Game());
            sut.NewGame();

            // Assert
            mock.Verify(x=>x.New(), Times.Exactly(1));
        }

        [Test]
        public void The_move_player_method_hits_each_method_within_it_once()
        {
            // Arrange
            var gameMock = new Mock<IGameFactory>();
            var boardMock = new Mock<IBoardStateUpdater>();
            var positionMock = new Mock<IPositionRepository>();
            var boardToJsonMock = new Mock<IBoardToJsonMapper>();
            boardMock.Setup(x => x.MovePlayer(It.IsAny<PositionDb>(), It.IsAny<Game>())).Returns(new Game());
            var sut = new GameController(boardMock.Object, gameMock.Object, boardToJsonMock.Object, null, positionMock.Object);
            
            // Act
            sut.MovePlayer(new PositionDb(1,0,4,2));

            // Assert
            gameMock.Verify(x => x.Load(It.IsAny<int>()), Times.Exactly(1));
            boardMock.Verify(x => x.MovePlayer(It.IsAny<PositionDb>(), It.IsAny<Game>()), Times.Exactly(1));
            positionMock.Verify(x => x.Update(It.IsAny<PositionDb>()), Times.Exactly(1));
            boardToJsonMock.Verify(x => x.CreateBoardObject(It.IsAny<BoardCellStatus[][]>(), It.IsAny<Game>()),Times.Exactly(1));
        }
    }
}
