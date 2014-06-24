using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quoridors.Models
{
    public class Board
    {
        public List<PositionJson> ListOfPlayerPositions { get; set; }
        public List<Brick> ListOfBricks { get; set; }
    }
}