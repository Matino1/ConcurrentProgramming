using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Threading;

namespace Logic
{
    internal class Board
    {
        public int Size { get; private set; }
        public List<Ball> Balls { get; private set; }
        private Task positionUpdater;

        public Board(int size)
        {
            Size = size;
        }

        public void AddBalls(int ballsAmount)
        {
            Balls = new List<Ball>();
            for (int i = 0; i < ballsAmount; i++)
            {
                Balls.Add(new Ball());
            }
        }

        public void StartMovingBalls()
        {
            positionUpdater = new Task(MoveBallsInLoop);
            positionUpdater.Start();
        }


        public void MoveBallsInLoop()
        {
            while(true)
            {
                foreach (Ball ball in Balls)
                {
                    ball.ChangeBallPosition(Size);
                }
                Thread.Sleep(1);
            }
        }
    }
}
