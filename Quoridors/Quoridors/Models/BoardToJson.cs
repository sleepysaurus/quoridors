using System.Collections.Generic;
using System.Security.AccessControl;

namespace Quoridors.Models
{
    public class BoardToJson // BA BoardIntendedToBeSerialisedToJson??
    {
        public List<PositionJson> ListOfPlayerPositions { get; set; }
        public List<Brick> ListOfBricks { get; set; }
        public int Turn { get; set; }
        public int GameId { get; set; }
    }
}