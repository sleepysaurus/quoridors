using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quoridors.Models
{
    public class Move
    {
        public int PlayerNumber { get; set; }
        public string NewPosition { get; set; }

        public Move()
        {
            
        }
    }
}