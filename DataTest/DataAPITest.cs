using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTest
{
    [TestClass]
    public class DataAPITest
    {

        [TestMethod]
        public void CreateBallsTest()
        {
            DataAbstractAPI dataApi = DataAbstractAPI.CreateDataApi();

            dataApi.createBalls(2);

            Assert.AreEqual(dataApi.getBallsAmount(), 2);
        }

        [TestMethod]
        public void SpeedSetterTest()
        {
            DataAbstractAPI dataApi = DataAbstractAPI.CreateDataApi();

            dataApi.createBalls(1);

            dataApi.setBallSpeed(1, 2, 2);

            Assert.AreEqual(dataApi.getBallSpeedX(1), 2);
            Assert.AreEqual(dataApi.getBallSpeedY(1), 2);
        }
    }
}
