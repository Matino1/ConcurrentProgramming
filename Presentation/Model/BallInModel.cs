using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace Model
{

    public class BallInModel
    {
        private Ball ball;

        public BallInModel(Ball ball)
        {
            this.ball = ball;
        }

        private double positionX;

        public double PositionX
        {
            get { return ball.PositionX; }
        }

        private double positionY;

        public double PositionY
        {
            get { return ball.PositionY; }
        }

    }
}
