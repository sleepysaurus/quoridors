using System.Collections.Generic;
using System.Runtime.InteropServices;
using Moq;
using NUnit.Framework;
using Quoridors.Models;
using Quoridors.Models.Database;
using Quoridors.Models.Database.Interfaces;
using Quoridors.Models.DatabaseModels;

namespace QuoridorsTests
{
    [TestFixture]
    public class Game_Tests
    {

        

        [Test]
        public void The_GetPlayerPositions_method_returns_the_positions_from_the_repository()
        {           
            // Arrange
            var mock = new Mock<IPositionRepository>();
            //var expectedResult = new List<PositionDb>();

            //mock.Setup(x => x.GetByGame(It.IsAny<int>())).Returns(expectedResult);

            var classUnderTest = new Game(mock.Object, Mock.Of<IWallRepository>());

            // Act
            //var result = classUnderTest.GetPlayerPositions(It.IsAny<int>());
            classUnderTest.GetPlayerPositions(It.IsAny<int>());

            // Assert
            //Assert.That(result, Is.EqualTo(expectedResult));
            mock.Verify(x => x.GetByGame(It.IsAny<int>()), Times.Once);
        }
    }
}
