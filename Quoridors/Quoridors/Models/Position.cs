using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quoridors.Models
{
    [Serializable]
    public class Position
    {
        public int Horizontal { get; set; }
        public int Vertical { get; set; }
    }
}