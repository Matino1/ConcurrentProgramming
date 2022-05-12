using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;

namespace DataTest
{
    [TestClass]
    public class BallRepoTest
    {
        [TestMethod]
        public void CreateBallsTest()
        {
            BallRepository ballRepository = new BallRepository();

            ballRepository.CreateBalls(2);

            Assert.AreEqual(ballRepository.balls.Count, 2);
            Assert.AreEqual(ballRepository.balls[0].Id, 1);
            Assert.AreEqual(ballRepository.balls[1].Id, 2);
        }

        [TestMethod]
        public void GetBallTest()
        {
            BallRepository ballRepository = new BallRepository();

            ballRepository.CreateBalls(2);

            Assert.AreEqual(ballRepository.GetBall(1), ballRepository.balls[0]);
            Assert.AreEqual(ballRepository.GetBall(2), ballRepository.balls[1]);
        }
    }
}