using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quoridors.Models.DatabaseModels;

namespace Quoridors.Models
{
    public class GameDbMapperToGame
    {
        private readonly BoardStateUpdater _boardStateUpdater = new BoardStateUpdater(); //Ninject section!!

        public Game MappingGameFromDatabase(GameDb gameDb)
        {
            Game game = new Game
            {
                Id = gameDb.Id
            };

            _boardStateUpdater.UpdateBoardToSavedState(game);
            
            return game;
        }
    }
}