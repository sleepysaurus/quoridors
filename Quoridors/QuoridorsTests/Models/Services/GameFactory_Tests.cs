using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Quoridors.Controllers;
using Quoridors.Models.Database;
using Quoridors.Models.Database.Interfaces;
using Quoridors.Models.Services;

namespace QuoridorsTests.Models.Services
{
    [TestFixture]
    public class GameFactory_Tests
    {
        [Test]
        public void The_new_method_emits_the_expected_array()
        {
            // Arrange
            var gameRepo = Mock.Of<IGameRepository>();
            var gamefactory = new GameFactory(null, gameRepo, null);

            // Act
            var newgame = gamefactory.New();

            // Assert
            Assert.That(newgame.Board.Length == 17);
        }
    }
}
