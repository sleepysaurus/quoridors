namespace Quoridors.Models
{
    public class Brick
    {
        public Brick(int xPos, int yPos, string topOrLeft)
        {
            XPos = xPos;
            YPos = yPos;
            TopOrLeft = topOrLeft;
        }

        public int XPos { get; private set; }
        public int YPos { get; private set; }
        public string TopOrLeft { get; private set; }
    }
}