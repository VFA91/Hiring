namespace FraudPrevention.Test
{
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using FraudPrevention.Core.Entities;
    using FraudPrevention.Core;

    [TestClass]
    public class FraudRadarTests
    {
        [TestMethod]
        public void CheckFraud_OneLineFile_NoFraudExpected()
        {
            var result = ExecuteTest(MockFile.OneLineFile);

            result.Should().NotBeNull("The result should not be null.");
            result.Count().ShouldBeEquivalentTo(0, "The result should not contains fraudulent lines");
        }

        [TestMethod]
        public void CheckFraud_TwoLines_SecondLineFraudulent()
        {
            var result = ExecuteTest(MockFile.TwoLines_FraudulentSecond);

            result.Should().NotBeNull("The result should not be null.");
            result.Count().ShouldBeEquivalentTo(1, "The result should contains the number of lines of the file");
            result.First().IsFraudulent.Should().BeTrue("The first line is not fraudulent");
            result.First().OrderId.Should().Be(2, "The first line is not fraudulent");
        }

        [TestMethod]
        public void CheckFraud_ThreeLines_SecondLineFraudulent()
        {
            var result = ExecuteTest(MockFile.ThreeLines_FraudulentSecond);

            result.Should().NotBeNull("The result should not be null.");
            result.Count().ShouldBeEquivalentTo(1, "The result should contains the number of lines of the file");
            result.First().IsFraudulent.Should().BeTrue("The first line is not fraudulent");
            result.First().OrderId.Should().Be(2, "The first line is not fraudulent");
        }

        [TestMethod]
        public void CheckFraud_FourLines_MoreThanOneFraudulent()
        {
            var result = ExecuteTest(MockFile.FourLines_MoreThanOneFraudulent);

            result.Should().NotBeNull("The result should not be null.");
            result.Count().ShouldBeEquivalentTo(2, "The result should contains the number of lines of the file");

            var orderId2 = result.First(o => o.OrderId == 2);
            orderId2.IsFraudulent.Should().BeTrue("The first line is not fraudulent");
            orderId2.OrderId.Should().Be(2, "The first line is not fraudulent");

            var orderId4 = result.First(o => o.OrderId == 4);
            orderId4.IsFraudulent.Should().BeTrue("The first line is not fraudulent");
            orderId4.OrderId.Should().Be(4, "The first line is not fraudulent");
        }
        
        private static IEnumerable<FraudResult> ExecuteTest(string[] lines)
        {
            var fraudRadar = new FraudRadar(lines);
            return fraudRadar.Check();
        }
    }
}
