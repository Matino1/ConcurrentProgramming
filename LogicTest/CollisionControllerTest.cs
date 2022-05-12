using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

namespace LogicTest
{
    [TestClass]
    public class CollisionControllerTest
    {
        [TestMethod]
        public void IsCollisionTest()
        {
            CollisionControler collisionControler = new CollisionControler(1, 1, 5, 5, 10, 10);

            Assert.IsTrue(collisionControler.IsCollision(21, 1, 10, true));
            Assert.IsTrue(collisionControler.IsCollision(20, 1, 10, false));

            Assert.IsFalse(collisionControler.IsCollision(26, 1, 10, true));
            Assert.IsFalse(collisionControler.IsCollision(22, 1, 10, false));

        }

        [TestMethod]
        public void IsTouchingBoundariesXandYTest()
        {
            CollisionControler collisionControler = new CollisionControler(1, 1, 3, 3, 10, 10);

            Assert.IsTrue(collisionControler.IsTouchingBoundariesX(3));
            Assert.IsTrue(collisionControler.IsTouchingBoundariesY(3));

            Assert.IsFalse(collisionControler.IsTouchingBoundariesX(5));
            Assert.IsFalse(collisionControler.IsTouchingBoundariesY(5));
        }

    }
}