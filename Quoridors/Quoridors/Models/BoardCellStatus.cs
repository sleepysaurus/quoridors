using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quoridors.Models
{
    public enum BoardCellStatus // BA unused outside of Wall. Wall is unused
    {
        Empty,
        Wall,
        Player1,
        Player2
    }
}