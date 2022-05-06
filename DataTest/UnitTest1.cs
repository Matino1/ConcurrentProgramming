using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;

namespace DataTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCreateBallsinRepository()
        {
            BallRepository BallRepo = new BallRepository();
            Assert.IsNotNull(BallRepo);
            Assert.IsNull(BallRepo.getBallList());
            BallRepo.CreateBalls(1);
            Assert.AreEqual(1, BallRepo.getBallList().Count);
        }
    }
}