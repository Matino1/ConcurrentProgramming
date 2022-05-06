using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class BallRepository
    {
        private List<Ball> balls;
        private Task StartMovingTask;

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
        }

        public Ball getBall(int ballId)
        {
          /*  foreach (Ball ball in balls)
            {
                if (ball.id == ballId)
                {
                    return ball;
                }
            }
            return null; */
            return balls[ballId];
        }

        public List<Ball> getBallList()
        {
            return balls;
        }
    }
}
