using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quoridors.Models
{
    public enum BoardCellStatus
    {
        NoPlayer,
        Wall,
        NoWall,
        Player1,
        Player2
    }
}