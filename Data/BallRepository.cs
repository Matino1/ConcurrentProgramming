﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class BallRepository
    {
        public List<Ball> balls { get; set; }
        public int BoardSize { get; private set; } = 515;
        Logger dao;

        public BallRepository()
        {
            balls = new List<Ball>();
            dao = new Logger();
        }

        public void CreateBalls(int ballsAmount)
        {
            for (int i = 0; i < ballsAmount; i++)
            {
                Ball newBall = new Ball(i + 1);
                balls.Add(newBall);
                newBall.logger = dao;
            }
        }

        public Ball GetBall(int ballId)
        {
            return balls[ballId - 1];
        }
    }
}
