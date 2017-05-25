using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ExpectedObjects;

namespace HomeworkDay1
{
    [TestClass]
    public class UnitTest_CalculateSum
    {
        [TestMethod]
        public void 三筆一組_CostSum()
        {
            var target = new CalculateSum();

            var expected = new List<int> { 6, 15, 24, 21 };

            var actual = target.GetCostSumBy3Count();

            expected.ToExpectedObject().ShouldEqual(actual);

        }


        [TestMethod]
        public void 四筆一組_RevenueSum()
        {
            var target = new CalculateSum();

            var expected = new List<int> { 50, 66, 60 };

            var actual = target.GetRevenueSumBy4Count();

            expected.ToExpectedObject().ShouldEqual(actual);

        }

        [TestMethod]

        public void 指定三筆一組_CostSum()
        {
            var target = new CalculateSum();

            var expected = new List<int> { 6, 15, 24, 21 };

            var actual = target.GetCostSumByGroupCount(3);

            expected.ToExpectedObject().ShouldEqual(actual);

        }

        [TestMethod]

        public void 指定四筆一組_RevenueSum()
        {
            var target = new CalculateSum();

            var expected = new List<int> { 50, 66, 60 };

            var actual = target.GetRevenueSumByGroupCount(4);

            expected.ToExpectedObject().ShouldEqual(actual);

        }

        [TestMethod]

        public void 指定126為一組_CostSum()
        {
            var target = new CalculateSum();

            var expected = 9;

            var ids = new List<int> { 1, 2, 6 };

            var actual = target.GetCostSumByIdGroup(ids);

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void 指定347為一組_RevenueSum()
        {
            var target = new CalculateSum();

            var expected = 44;

            var ids = new List<int> { 3, 4, 7 };

            var actual = target.GetRevenueSumByIdGroup(ids);

            Assert.AreEqual(expected, actual);

        }
    }
}
