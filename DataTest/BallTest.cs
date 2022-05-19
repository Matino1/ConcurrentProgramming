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
            Assert.AreEqual(ball.PositionX, positionX + ball.MoveX);
            Assert.AreEqual(ball.PositionY, positionY + ball.MoveY);
        }

        [TestMethod]
        public void RandomPositionAndMoveTest()
        {
            Ball ball = new Ball(1);

            Assert.IsTrue(ball.PositionX <= 500 && ball.PositionX >= 1);
            Assert.IsTrue(ball.PositionY <= 500 && ball.PositionY >= 1);

            Assert.IsTrue(ball.MoveX <= 5 && ball.MoveX >= 2);
            Assert.IsTrue(ball.MoveY <= 5 && ball.MoveY >= 2);
        }
    }
}