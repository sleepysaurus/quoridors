using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Ninject;
using NUnit.Framework;
using Quoridors.App_Start;
using Quoridors.Models;
using Quoridors.Models.Database;
using Quoridors.Models.Database.Interfaces;
using Quoridors.Models.DatabaseModels;

namespace QuoridorsTests.Integration
{
    class GameController
    {
        [Test]
        public void Given_a_positionDB_object_the_MovePlayer_method_will_move_the_player_and_correctly_update_DB()
        {
            //Arrange
            var _ninjectKernel = NinjectWebCommon.GetKernelForTesting();
            var gameController = (Quoridors.Controllers.GameController)_ninjectKernel.Get(typeof(Quoridors.Controllers.GameController));

            //var gameController = new Quoridors.Controllers.GameController(boardStateUpdater, gameFactory, boardToJsonMapper, wallRepository, positionRepository, gameRepository);
            var position = new PositionDb(36, 2, 2, 60);

            //Act
            var something = gameController.MovePlayer(position);

            //Assert
            Assert.IsInstanceOf<JsonResult>(something);
        }

        [Test]
        public void Given_a_wallDB_object_the_Place_method_will_move_the_player_and_correctly_update_DB()
        {
            //Arrange
            var _ninjectKernel = NinjectWebCommon.GetKernelForTesting();
            var gameController = (Quoridors.Controllers.GameController)_ninjectKernel.Get(typeof(Quoridors.Controllers.GameController));

            //var gameController = new Quoridors.Controllers.GameController(boardStateUpdater, gameFactory, boardToJsonMapper, wallRepository, positionRepository, gameRepository);
            var wall = new WallDb(2, 2, 1, 60);

            //Act
            var something = gameController.PlaceWall(wall);

            //Assert
            Assert.IsInstanceOf<JsonResult>(something);
        }
    }
}
