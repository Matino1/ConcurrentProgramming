namespace Logic
{
    public class Ball
    {
        public double PositionX { get; private set; }
        public double PositionY { get; private set; }

        public double MoveX { get; private set; }
        public double MoveY { get; private set; }


        public Ball()
        {
            Random random = new Random();
            
            this.PositionX = random.NextDouble() % (100 - 1) + 1;
            this.PositionY = random.NextDouble() % (100 - 1) + 1;

            this.MoveX = random.NextDouble() % (1 - 0.1) + 0.1;
            this.MoveY = random.NextDouble() % (1 - 0.1) + 0.1; 
        }

        public void ChangeBallPosition(int maxBorder)
        {
            double newX = PositionX + MoveX;
            double newY = PositionY + MoveY;

            if (newX > maxBorder || newX < 0)
            {
                MoveX = -MoveX;
            } 

            if (newY > maxBorder || newY < 0)
            {
                MoveY = -MoveY;
            }

            PositionX = PositionX + MoveX;
            PositionY = PositionY + MoveY;
        }
    }
}