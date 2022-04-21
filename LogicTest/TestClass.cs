using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

namespace LogicTest
{
    [TestClass]
    public class BallTest
    {
        [TestMethod]
        public void ChangeBallPositionTest()
        {
            Ball ball = new Ball();

            double positionX = ball.PositionX;
            double positionY = ball.PositionY;
            ball.ChangeBallPosition(100);
            Assert.AreEqual(ball.PositionX, positionX + ball.MoveX);
            Assert.AreEqual(ball.PositionY, positionY + ball.MoveY);
        }

        [TestMethod]
        public void RandomPositionAndMoveTest()
        {
            Ball ball = new Ball();

            Assert.IsTrue(ball.PositionX <= 100 && ball.PositionX >= 1);
            Assert.IsTrue(ball.PositionY <= 100 && ball.PositionY >= 1);

            Assert.IsTrue(ball.MoveX <= 3.5 && ball.MoveX >= 1.5);
            Assert.IsTrue(ball.MoveY <= 3.5 && ball.MoveY >= 1.5);
        }
    }
}