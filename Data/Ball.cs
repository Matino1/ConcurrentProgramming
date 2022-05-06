using System;
using System.Collections.Generic;
using System.Threading;

namespace Data
{
    public class Ball
    {
        public int id { get;}
        public double PositionX { get; private set; }
        public double PositionY { get; private set; }

        public int Radius { get; }
        public double Mass { get;}
        public double Speed { get; set; }

        public double MoveX { get; private set; }
        public double MoveY { get; private set; }

        public int BoardSize { get; set; } = 100;

        private Thread BallThread;


        public Ball(int id)
        {
            this.id = id;

            Random random = new Random();

            this.PositionX = Convert.ToDouble(random.Next(1, 100));
            this.PositionY = Convert.ToDouble(random.Next(1, 100));

            this.Radius = random.Next(1,6);
            this.Mass = Convert.ToDouble(random.Next(1, 10)) * 0.1;

            this.Speed = (random.NextDouble() % (5 - 1.5) + 1.5) / Mass;

            if( Speed % 2 == 0)
            {
                this.Speed = - this.Speed;
            } 

            this.MoveX = Speed;
            this.MoveY = Speed;
        }

        public void StartMoving()
        {
            this.BallThread = new Thread(MoveBall);
            BallThread.Start();
        }

        private void MoveBall()
        {
            while(true)
            {
                double newX = PositionX + MoveX;
                double newY = PositionY + MoveY;

                if (newX > BoardSize || newX < 0)
                {
                    MoveX = -MoveX;
                }

                if (newY > BoardSize || newY < 0)
                {
                    MoveY = -MoveY;
                }

                PositionX += MoveX;
                PositionY += MoveY;
            }
        }

        public bool Collision(Ball ball)
        {
            double distance = Math.Sqrt(Math.Pow(this.PositionX - ball.PositionX, 2) + Math.Pow(this.PositionY - ball.PositionY, 2));

            if (distance <= this.Radius + ball.Radius)
            {
                Speed = ball.Speed;
                ball.Speed = Speed;
                return true;
            }

            return false;
        }
    }
}
