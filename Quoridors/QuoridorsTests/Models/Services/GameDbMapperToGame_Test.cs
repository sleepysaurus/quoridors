using System.CodeDom;
using System.Collections.Specialized;
using Moq;
using NUnit.Framework;
using Quoridors.Models;
using Quoridors.Models.DatabaseModels;
using Quoridors.Models.Interfaces;
using Quoridors.Models.Services;

namespace QuoridorsTests.Models.Services
{
    [TestFixture]
    class GameDbMapperToGame_Test
    {
        [Test]
        public void Checking_if_the_methods_within_MappingGameFromDatabase_are_being_called()
        {
            // Arrange
            var boardMock = new Mock<IBoardStateUpdater>();
            var factoryMock = new Mock<IBoardFactory>();

            var cut = new GameDbMapperToGame(boardMock.Object, factoryMock.Object);
            var game = new GameDb();
            // Act
            cut.MappingGameFromDatabase(game);
            // Assert
            boardMock.Verify(x => x.UpdateBoardToSavedState(It.IsAny<Game>()), Times.Exactly(1));
        }
    }
}
