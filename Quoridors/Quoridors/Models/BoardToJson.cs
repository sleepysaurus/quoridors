using System.Collections.Generic;

namespace Quoridors.Models
{
    public class BoardToJson
    {
        public List<PositionJson> ListOfPlayerPositions { get; set; }
        public List<Brick> ListOfBricks { get; set; }
    }
}