using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Board
    {
        public int Size { get; private set; }
        public List<Ball> Balls { get; private set; }

        public Board(int size, int BallsAmount)
        {
            Size = size;


            Balls = new List<Ball>();
            for(int i = 0; i < BallsAmount; i++)
            {
                Balls.Add(new Ball());
            }
        }

        public void MoveBalls()
        {
            while(true)
            {
                foreach(Ball ball in Balls)
                {
                    ball.ChangeBallPosition(Size);
                }
            }
        }
    }
}
