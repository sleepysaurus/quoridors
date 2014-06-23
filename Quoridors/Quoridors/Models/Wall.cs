using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quoridors.Models
{
    public class Wall
    {
        public Position Origin { get; set; }
        public Direction Direction { get; set; }
    }
}