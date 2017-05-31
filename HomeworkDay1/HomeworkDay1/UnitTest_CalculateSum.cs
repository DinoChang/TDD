using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ExpectedObjects;

namespace HomeworkDay1
{
    [TestClass]
    public class UnitTest_CalculateSum
    {
        private List<Product> _products;

        [TestInitialize]
        public void Init()
        {
            this._products = new List<Product>
            {
                new Product{ ID =  1, Cost =  1, Revenue = 11, SellPrice = 21},
                new Product{ ID =  2, Cost =  2, Revenue = 12, SellPrice = 22},
                new Product{ ID =  3, Cost =  3, Revenue = 13, SellPrice = 23},
                new Product{ ID =  4, Cost =  4, Revenue = 14, SellPrice = 24},
                new Product{ ID =  5, Cost =  5, Revenue = 15, SellPrice = 25},
                new Product{ ID =  6, Cost =  6, Revenue = 16, SellPrice = 26},
                new Product{ ID =  7, Cost =  7, Revenue = 17, SellPrice = 27},
                new Product{ ID =  8, Cost =  8, Revenue = 18, SellPrice = 28},
                new Product{ ID =  9, Cost =  9, Revenue = 19, SellPrice = 29},
                new Product{ ID = 10, Cost = 10, Revenue = 20, SellPrice = 30},
                new Product{ ID = 12, Cost = 11, Revenue = 21, SellPrice = 31}
            };
        }

        [TestMethod]

        public void 測試_指定三筆一組_Cost總和_依循應為_6_15_24_21()
        {
            var target = new CalculateSum(_products);

            var expected = new List<int> { 6, 15, 24, 21 };

            var actual = target.GetCostSumByGroupCount(3);

            expected.ToExpectedObject().ShouldEqual(actual);

        }

        [TestMethod]

        public void 測試_指定四筆一組_Revenue總和_依循應為_50_66_60()
        {
            var target = new CalculateSum(_products);

            var expected = new List<int> { 50, 66, 60 };

            var actual = target.GetRevenueSumByGroupCount(4);

            expected.ToExpectedObject().ShouldEqual(actual);

        }

        [TestMethod]

        public void 測試_指定ID_126為一組_Cost總和_應為9()
        {
            var target = new CalculateSum(_products);

            var expected = 9;

            var ids = new List<int> { 1, 2, 6 };

            var actual = target.GetCostSumByIdGroup(ids);

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void 測試_指定ID_347為一組_Revenue總和_應為44()
        {
            var target = new CalculateSum(_products);

            var expected = 44;

            var ids = new List<int> { 3, 4, 7 };

            var actual = target.GetRevenueSumByIdGroup(ids);

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void 測試_Products_為NULL_應該丟出_NullReferenceException()
        {
            var target = new CalculateSum(null);

            var expected = new List<int> { 50, 66, 60 };

            var actual = target.GetRevenueSumByGroupCount(4);

            expected.ToExpectedObject().ShouldEqual(actual);
        }
    }
}
