using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;

namespace DataTest
{
    [TestClass]
    public class BallTest
    {
        [TestMethod]
        public void TestBallMovement()
        {
            /*Ball ball = new Ball(0);
            double x = ball.PositionX;
            double y = ball.PositionY;
            ball.MoveBall();
            Assert.AreEqual(ball.PositionX, x + ball.MoveX);
            Assert.AreEqual(ball.PositionY, y + ball.MoveY);*/


            DataAbstractAPI api = DataAbstractAPI.CreateDataApi();

            api.createBalls(10);
        }

/*        [TestMethod]
        public void TestSpawnPosition()
        {
            Ball ball = new Ball(0);

            Assert.IsTrue(ball.PositionX <= 100 && ball.PositionX >= 1);
            Assert.IsTrue(ball.PositionY <= 100 && ball.PositionY >= 1);

            Assert.IsTrue(ball.MoveX <= 3.5 && ball.MoveX >= 1.5);
            Assert.IsTrue(ball.MoveY <= 3.5 && ball.MoveY >= 1.5);
        }*/
    }
}