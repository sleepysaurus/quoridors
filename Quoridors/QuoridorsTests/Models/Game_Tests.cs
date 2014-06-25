using NUnit.Framework;
using Quoridors.Models;
using Quoridors.Models.Services;

namespace QuoridorsTests.Models
{
    [TestFixture]
    class Game_Tests
    {
        [Test]
        public void that_createboard_creates_a_board_of_correct_size()
        {
            // Arrange
            var game = new Game(1,1, new BoardFactory().CreateBoard());

            // Act


            // Assert
            Assert.That(game.Board.Length, Is.EqualTo(17));
        }

        [Test]
        public void createboard_creates_a_board_with_nowall_in_correct_places()
        {
            // Arrange
            var game = new Game(1,1, new BoardFactory().CreateBoard());

            // Act

            // Assert
            Assert.That(game.Board[1][0], Is.EqualTo(BoardCellStatus.NoWall));
            Assert.That(game.Board[5][3], Is.EqualTo(BoardCellStatus.NoWall));
        }

        [Test]
        public void createboard_creates_a_board_with_noPlayer_in_correct_place()
        {
            // Arrange
            var game = new Game(1,1, new BoardFactory().CreateBoard());

            // Act

            // Assert
            Assert.That(game.Board[0][0], Is.EqualTo(BoardCellStatus.NoPlayer));
            Assert.That(game.Board[6][8], Is.EqualTo(BoardCellStatus.NoPlayer));
        }
    }
}
