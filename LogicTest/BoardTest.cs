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
           /* Board board = new Board(100);

            board.AddBalls(1);
            Assert.AreEqual(board.Balls.Count, 1);*/

            LogicAPI api = LogicAPI.CreateLayer();

            api.StartMovingBalls();

        }

        /*[TestMethod]
        public void MovingBallsTest()
        {
            Board board = new Board(100);

            board.AddBalls(2);

            double positionX1 = board.Balls[0].PositionX;
            double positionY1 = board.Balls[0].PositionY;

            double positionX2 = board.Balls[1].PositionX;
            double positionY2 = board.Balls[1].PositionY;

            board.MoveBalls();

            Assert.AreNotEqual(board.Balls[0].PositionX, positionX1);
            Assert.AreNotEqual(board.Balls[0].PositionY, positionY1);

            Assert.AreNotEqual(board.Balls[1].PositionX, positionX2);
            Assert.AreNotEqual(board.Balls[1].PositionY, positionY2);

        } */
    }
}