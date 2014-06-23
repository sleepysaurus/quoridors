using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quoridors.Models
{
    public class Game
    {
        public int Turn { get; set; }
        public Player Winner { get; set; }
    }
}