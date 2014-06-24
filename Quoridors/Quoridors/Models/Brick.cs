namespace Quoridors.Models
{
    public class Brick
    {
        public Brick(int xPos, int yPos, BrickDirection topOrLeft)
        {
            XPos = xPos;
            YPos = yPos;
            BrickDirection = topOrLeft;
        }

        public int XPos { get; private set; }
        public int YPos { get; private set; }
        public BrickDirection BrickDirection { get; private set; }
    }
}