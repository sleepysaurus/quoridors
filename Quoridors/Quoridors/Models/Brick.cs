namespace Quoridors.Models
{
    public class Brick
    {
        public Brick(int xPos, int yPos, BrickAlignment topOrLeft)
        {
            XPos = xPos;
            YPos = yPos;
            BrickAlignment = topOrLeft;
        }

        public int XPos { get; private set; }
        public int YPos { get; private set; }
        public BrickAlignment BrickAlignment { get; private set; }
    }
}