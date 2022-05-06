using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Data
{
    internal class Ball
    {
        public int id { get;}
        public double PositionX { get; private set; }
        public double PositionY { get; private set; }

        public int Radious { get; } = 5;
        public double Mass { get;} = 10;
        public double Speed { get; set; } = 5;

        public double MoveX { get; private set; }
        public double MoveY { get; private set; }

        public int BoardSize { get; set; } = 100;

        private Thread positionUpdater;


        public Ball(int id)
        {
            this.id = id;

            Random random = new Random();

            this.PositionX = Convert.ToDouble(random.Next(1, 100));
            this.PositionY = Convert.ToDouble(random.Next(1, 100));

            this.Speed = random.NextDouble() % (5 - 1.5) + 1.5;

            if( Speed % 2 == 0)
            {
                this.Speed = - this.Speed;
            } 

            this.MoveX = Speed;
            this.MoveY = Speed;
        }

        public bool isCollision(Ball ball)
        {
            double distance = Math.Sqrt(Math.Pow(this.PositionX - ball.PositionX, 2) + Math.Pow(this.PositionY - ball.PositionY, 2));

            if (distance <= this.Radious + ball.Radious)
            {
                Speed = ball.Speed;
                ball.Speed = Speed;
                return true;
            }

            return false;
        }

        public void StartMoving()
        {
            this.positionUpdater = new Thread(MovingBall);
            positionUpdater.Start();
        }

        private void MovingBall()
        {
            while(true)
            {
                ChangeBallPosition(BoardSize);
            }
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
