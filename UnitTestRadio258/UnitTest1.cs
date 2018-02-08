using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Radio258;

namespace UnitTestRadio258
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckMaxTemp()
        {
            Measurement m = new Measurement();
            m.FirstDateOfWeek = new DateTime(2017, 4, 3);
            m.AddTemperature(DayOfWeek.Monday, 13.3);
            m.AddTemperature(DayOfWeek.Tuesday, 16.1);
            m.AddTemperature(DayOfWeek.Wednesday, 15.6);
            m.AddTemperature(DayOfWeek.Thursday, 14.7);
            m.AddTemperature(DayOfWeek.Friday, 15.0);
            m.AddTemperature(DayOfWeek.Saturday, 17.2);
            m.AddTemperature(DayOfWeek.Sunday, 16.3);
            Assert.AreEqual(m.Max, 17.2);
        }
        [TestMethod]
        public void CheckMinTemp()
        {
            Measurement m = new Measurement();
            m.FirstDateOfWeek = new DateTime(2017, 4, 3);
            m.AddTemperature(DayOfWeek.Monday, 13.3);
            m.AddTemperature(DayOfWeek.Tuesday, 16.1);
            m.AddTemperature(DayOfWeek.Wednesday, 15.6);
            m.AddTemperature(DayOfWeek.Thursday, 14.7);
            m.AddTemperature(DayOfWeek.Friday, 15.0);
            m.AddTemperature(DayOfWeek.Saturday, 17.2);
            m.AddTemperature(DayOfWeek.Sunday, 16.3);
            Assert.AreEqual(m.Min, 13.3);
        }

        [TestMethod]
        public void CheckHottestDay()
        {
            Measurement m = new Measurement();
            m.FirstDateOfWeek = new DateTime(2017, 4, 3);
            m.AddTemperature(DayOfWeek.Monday, 13.3);
            m.AddTemperature(DayOfWeek.Tuesday, 16.1);
            m.AddTemperature(DayOfWeek.Wednesday, 15.6);
            m.AddTemperature(DayOfWeek.Thursday, 14.7);
            m.AddTemperature(DayOfWeek.Friday, 15.0);
            m.AddTemperature(DayOfWeek.Saturday, 17.2);
            m.AddTemperature(DayOfWeek.Sunday, 16.3);
            Assert.AreEqual(m.HottestDate, new DateTime(2017, 4, 8));
        }

        [TestMethod]
        public void CheckColdestDay()
        {
            Measurement m = new Measurement();
            m.FirstDateOfWeek = new DateTime(2017, 4, 3);
            m.AddTemperature(DayOfWeek.Monday, 13.3);
            m.AddTemperature(DayOfWeek.Tuesday, 16.1);
            m.AddTemperature(DayOfWeek.Wednesday, 15.6);
            m.AddTemperature(DayOfWeek.Thursday, 14.7);
            m.AddTemperature(DayOfWeek.Friday, 15.0);
            m.AddTemperature(DayOfWeek.Saturday, 17.2);
            m.AddTemperature(DayOfWeek.Sunday, 16.3);

            Assert.AreEqual(m.ColdestDate, new DateTime(2017, 4, 3));
        }

        [TestMethod]
        public void CheckAverageTemp()
        {
            Measurement m = new Measurement();
            m.FirstDateOfWeek = new DateTime(2017, 4, 3);
            m.AddTemperature(DayOfWeek.Monday, 13.3);
            m.AddTemperature(DayOfWeek.Tuesday, 16.1);
            m.AddTemperature(DayOfWeek.Wednesday, 15.6);
            m.AddTemperature(DayOfWeek.Thursday, 14.7);
            m.AddTemperature(DayOfWeek.Friday, 15.0);
            m.AddTemperature(DayOfWeek.Saturday, 17.2);
            m.AddTemperature(DayOfWeek.Sunday, 16.3);
            Assert.AreEqual(Math.Round(m.AverageTemperature, 2), 15.46);
        }

        [TestMethod]
        public void CheckStdevTemp()
        {
            Measurement m = new Measurement();
            m.FirstDateOfWeek = new DateTime(2017, 4, 3);
            m.AddTemperature(DayOfWeek.Monday, 13.3);
            m.AddTemperature(DayOfWeek.Tuesday, 16.1);
            m.AddTemperature(DayOfWeek.Wednesday, 15.6);
            m.AddTemperature(DayOfWeek.Thursday, 14.7);
            m.AddTemperature(DayOfWeek.Friday, 15.0);
            m.AddTemperature(DayOfWeek.Saturday, 17.2);
            m.AddTemperature(DayOfWeek.Sunday, 16.3);
            Assert.AreEqual(Math.Round(m.StandardDeviationOfTemperatures, 2), 1.17);
        }
    }
}
