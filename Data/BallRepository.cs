using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class BallRepository
    {
        public List<Ball> balls { get; set; }
        public int BoardSize { get; private set; } = 520;

        public BallRepository()
        {
            balls = new List<Ball>();
        }

        public void CreateBalls(int ballsAmount)
        {
            for (int i = 0; i < ballsAmount; i++)
            {
                balls.Add(new Ball(i + 1));
                balls[i].StartMoving();
            }
            balls[0].MoveX = 7;
            balls[0].MoveY = 7;
        }

        public Ball GetBall(int ballId)
        {
            return balls[ballId - 1];
        }
    }
}
