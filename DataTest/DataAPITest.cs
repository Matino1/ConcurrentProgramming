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
    }
}
