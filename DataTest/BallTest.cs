using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;

namespace DataTest
{
    [TestClass]
    public class BallTest
    {
        [TestMethod]
        public void ChangeBallPositionTest()
        {
            Ball ball = new Ball(1);

            double positionX = ball.PositionX;
            double positionY = ball.PositionY;
            ball.ChangeBallPosition(0);
            Assert.AreEqual(ball.PositionX, positionX + ball.SpeedX/5);
            Assert.AreEqual(ball.PositionY, positionY + ball.SpeedY/5);

            positionX = ball.PositionX;
            positionY = ball.PositionY;
            ball.ChangeBallPosition(2);
            Assert.AreEqual(ball.PositionX, positionX + (ball.SpeedX / 5) * 2);
            Assert.AreEqual(ball.PositionY, positionY + (ball.SpeedY / 5) * 2);
        }

        [TestMethod]
        public void RandomPositionAndMoveTest()
        {
            Ball ball = new Ball(1);

            Assert.IsTrue(ball.PositionX <= 500 && ball.PositionX >= 1);
            Assert.IsTrue(ball.PositionY <= 500 && ball.PositionY >= 1);

        }
    }
}