using System;

namespace Quoridors.Models
{
    [Serializable]
    public class Position// BA kill either this class or PositionJson?
    {
        public int Vertical { get; set; }
        public int Horizontal { get; set; }
        
        public Position(int x, int y)
        {
            Vertical = x;
            Horizontal = y;
        }
    }
}