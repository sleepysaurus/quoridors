using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Quoridors.Controllers;
using Quoridors.Models.Interfaces;

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
            // TODO

            // Assert
            mock.Verify(blah blah blah);
        }

        // MovePlayer
        // The game is loaded from the repository
        // The board state is onlyupdated once
        // The new position is saved to the repository exactly once
        // The board mapper is used to create the return value
    }
}
