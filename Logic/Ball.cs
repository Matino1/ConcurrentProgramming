namespace Logic
{
    public class Ball
    {
        public int PositionX { get; private set; }
        public int PositionY { get; private set; }


        public Ball(int positionX, int positionY)
        {
            this.PositionX = positionX;
            this.PositionY = positionY;
        }

        public void ChangeBallPosition(int positionX, int positionY)
        {
            PositionX = positionX;
            PositionY = positionY;
        }
    }
}