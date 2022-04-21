using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

namespace LogicTest
{
    [TestClass]
    public class BoardTest
    {
        [TestMethod]
        public void AddBallsTest()
        {
            Board board = new Board(100);

            board.AddBalls(1);
            Assert.AreEqual(board.Balls.Count, 1);
        }

        [TestMethod]
        public void StartMovingBallsTest()
        {
            Board board = new Board(100);

            board.AddBalls(1);

            double positionX = board.Balls[0].PositionX;
            double positionY = board.Balls[0].PositionY;

            board.StartMovingBalls();

            System.Threading.Thread.Sleep(5);
            Assert.AreNotEqual(board.Balls[0].PositionX, positionX);
            Assert.AreNotEqual(board.Balls[0].PositionY, positionY);

        }
    }
}