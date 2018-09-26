using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CreditCardInterestCalculator;

namespace CreditCardInterestCalculatorTests
{
    [TestClass]
    public class SimpleInterestCalculatorTest
    {
        private SimpleInterestCalculator interestCalculator = new SimpleInterestCalculator();

        [TestMethod]
        public void ShouldCalculateSimpleInterest()
        {
            var principle = 100m;
            var rate = 0.15m;
            var numMonths = 5;

            var interest = interestCalculator.CalculateInterest(principle, rate, numMonths);

            Assert.AreEqual(principle * rate * numMonths, interest);
        }
    }
}
