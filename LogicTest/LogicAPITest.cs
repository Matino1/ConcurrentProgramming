using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace LogicTest
{
    [TestClass]
    internal class LogicAPITest
    {
        [TestMethod]
        public void IsCollisionTest()
        {
            LogicAPI logic = LogicAPI.CreateLayer();

            logic.AddBallsAndStart(1);
        }


    }
}
