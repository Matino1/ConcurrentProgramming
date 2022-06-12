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
            ball.ChangeBallPosition();
            Assert.AreEqual(ball.PositionX, positionX + ball.SpeedX);
            Assert.AreEqual(ball.PositionY, positionY + ball.SpeedY);
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