using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestClass
{
    [TestClass]
    public class ClassTest
    {
        [TestMethod]
        public void TestPrintHello()
        {
            ConcurrentProgramming.Class TestClass = new ConcurrentProgramming.Class();

            Assert.AreEqual(TestClass.printHello(), "Hello World!");

        }
    }
}