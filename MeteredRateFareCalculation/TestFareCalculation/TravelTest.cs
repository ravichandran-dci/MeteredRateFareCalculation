using FareCalculationLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestFareCalculation
{


    /// <summary>
    ///This is a test class for TravelTest and is intended
    ///to contain all TravelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TravelTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        /// <summary>
        ///A test for CalculateFare
        ///</summary>
        [TestMethod()]
        public void CalculateFareTest()
        {
            DateTime dtStart = DateTime.Parse("2010-10-08 5:30 pm");
            Travel target = new Travel(5, 2, dtStart.Date, dtStart.ToString("HH:mm"));
            Fare expectedFare = new Fare(3,3.5,1.75,0,1,0.5);
            Fare actualFare = target.CalculateFare();
            Assert.AreEqual(expectedFare.MinimumFare, actualFare.MinimumFare);
            Assert.AreEqual(expectedFare.OneFifthOfMileFare, actualFare.OneFifthOfMileFare);
            Assert.AreEqual(expectedFare.AdditionalFare, actualFare.AdditionalFare);
            Assert.AreEqual(expectedFare.NightSurcharge, actualFare.NightSurcharge);
            Assert.AreEqual(expectedFare.PeakHourSurcharge, actualFare.PeakHourSurcharge);
            Assert.AreEqual(expectedFare.NewyorkStateTaxSurcharge, actualFare.NewyorkStateTaxSurcharge);
        }

        /// <summary>
        ///A test for Travel Constructor
        ///</summary>
        [TestMethod()]
        public void TravelConstructorTest()
        {
            DateTime dtStart = DateTime.Parse("2010-10-08 5:30 pm");
            int numberOfMinutes = 2;
            int numberOfMiles = 2;
            DateTime dtJourneyStart = dtStart.Date;
            String strStartTime = dtStart.ToString("HH:mm");
            Travel target = new Travel(numberOfMinutes, numberOfMiles, dtJourneyStart, strStartTime);
            Assert.AreEqual(numberOfMinutes, target.NumberOfMilesTraveled);
            Assert.AreEqual(numberOfMiles, target.NumberOfMilesTraveled);
            Assert.AreEqual(dtJourneyStart, target.JourneyStartDateTime);
            Assert.AreEqual(strStartTime, target.JourneyStartTime);
        }
    }
}
