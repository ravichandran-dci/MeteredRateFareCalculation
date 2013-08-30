using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FareCalculationLibrary;

namespace TestFareCalculation
{
    [TestClass]
    public class UnitTestFareCalculation
    {
        [TestMethod]
        public void TestMethod1()
        {

        }

        [TestMethod]
        public void TestFareCalculation()
        {
            using (Travel objTravel = new Travel(5, 2, DateTime.Now.AddHours(-4)))
            {
                Double totalFare = objTravel.CalculateFare();
                Assert.Fail("Total Fare: " + totalFare.ToString(".##"));
            }
        }
    }
}
