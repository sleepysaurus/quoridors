using System.Collections.Generic;
using System.Linq;
using Microsoft.Ajax.Utilities;
using Quoridors.Models.Database;
using Quoridors.Models.Database.Interfaces;
using Quoridors.Models.DatabaseModels;

namespace Quoridors.Models
{
    public class Game
    {
        public int Id { get; set; }
        public int Turn { get; set; }
        public Player Winner { get; set; }
        public string[][] Board { get; set; }

        public Game()
        {

            // TODO DRY this shit up
            // TODO do you want to do this every time a board is created, you'll end up with a new, empty board for every HttpRequest. You will need to do this somewhere? BoardFactory? Maybe?
            Board = new string[][]{};
            //{
                //new string[]{"0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0"},
                //new string[]{string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty},
                //new string[]{"0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0"},
                //new string[]{string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty},
                //new string[]{"0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0"},
                //new string[]{string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty},
                //new string[]{"0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0"},
                //new string[]{string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty},
                //new string[]{"0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0"},
                //new string[]{string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty},
                //new string[]{"0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0"},
                //new string[]{string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty},
                //new string[]{"0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0"},
                //new string[]{string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty},
                //new string[]{"0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0"},
                //new string[]{string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty},
                //new string[]{"0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0"}
            //};

            for (int i = 0; i < 17; i++)
            {
                if (i%2 == 0)
                {
                    Board[i] = new string[]
                    {
                        "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0", string.Empty, "0",
                        string.Empty, "0", string.Empty, "0", string.Empty, "0"
                    };
                }
                if (i%2 == 1)
                {
                    Board[i] = new string[]
                    {
                        string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
                        string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
                        string.Empty, string.Empty, string.Empty
                    };
                }
            }

        }


  
    }
}