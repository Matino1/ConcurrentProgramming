using System;

namespace Logic
{
    internal class Ball
    {
        public double PositionX { get; private set; }
        public double PositionY { get; private set; }
        public double Speed { get; set; } = 5;
        public int Radious { get; set; }

        public double MoveX { get; private set; }
        public double MoveY { get; private set; }


        public Ball()
        {
            Random random = new Random();
            
            this.PositionX = Convert.ToDouble(random.Next(1, 100));
            this.PositionY = Convert.ToDouble(random.Next(1, 100));

            /*this.MoveX = random.NextDouble() % (3.5 - 1.5) + 1.5;
            this.MoveY = random.NextDouble() % (3.5 - 1.5) + 1.5; */

            this.Speed = random.NextDouble() % (5 - 1.5) + 1.5;

            this.MoveX = Speed;
            this.MoveY = Speed;
        }

        public bool isCollision(Ball ball)
        {
            double distance = Math.Sqrt(Math.Pow(this.PositionX - ball.PositionX, 2) + Math.Pow(this.PositionY - ball.PositionY, 2));

            if (distance <= this.Radious + ball.Radious)
            {
                this.Speed = ball.Speed;
                ball.Speed = this.Speed;
                return true;
            }

            return false;
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

            PositionX += MoveX;
            PositionY += MoveY;
        }
    }
}