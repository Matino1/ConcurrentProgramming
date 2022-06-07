using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using Data;
using System;

namespace LogicTest
{
    [TestClass]
    public class CollisionControllerTest
    {
        public class Ball : IBall
        {
            public int Id { get; }

            public Ball(double x, double y, double moveX, double moveY, int radius )
            {
                PositionX = x;
                PositionY = y;  
                Radius = radius;
                MoveX = moveX;
                MoveY = moveY;  
            }

            public double PositionX { get; }
            public double PositionY { get; }

            public int Radius { get; }
            public double Mass { get; }

            public double SpeedX { get; set; }
            public double SpeedY { get; set; }

            public double MoveX { get; set; }
            public double MoveY { get; set; }

            public IDisposable Subscribe(IObserver<IBall> observer)
            {
                throw new NotImplementedException();
            }
        }



        [TestMethod]
        public void IsCollisionTest()
        {
            IBall ball = new Ball(1, 1, 5, 5, 10);
            IBall otherBall = new Ball(21, 1, 5, 5, 10);

            Assert.IsTrue(CollisionControler.IsCollision(ball, otherBall));

            otherBall = new Ball(20, 1, 5, 5, 10);
            Assert.IsTrue(CollisionControler.IsCollision(ball, otherBall));

            otherBall = new Ball(26, 1, 5, 5, 10);
            Assert.IsFalse(CollisionControler.IsCollision(ball, otherBall));
        }

        [TestMethod]
        public void IsTouchingBoundariesXandYTest()
        {
            IBall ball = new Ball(1, 1, 5, 5, 10);
            double speedX = ball.SpeedX;
            double speedY = ball.SpeedY;

            CollisionControler.IsTouchingBoundaries(ball, 100);

            Assert.AreEqual(-speedX, ball.SpeedX);
            Assert.AreEqual(-speedY, ball.SpeedY);
        }

    }
}