using System;

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
            
            this.PositionX = Convert.ToDouble(random.Next(1, 100));
            this.PositionY = Convert.ToDouble(random.Next(1, 100));

            this.MoveX = random.NextDouble() * (3.5 - 1.5) + 1.5;
            this.MoveY = random.NextDouble() * (3.5 - 1.5) + 1.5; 
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