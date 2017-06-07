using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HomeworkDay2
{
    [TestClass]
    public class BuyHarryPotterBookUnitTest
    {
        [TestMethod]
        public void 第一集買了一本其它都沒買價格應為100()
        {
            var store = new Store();

            var book = new Book { Episode = 1, Quantity = 1 };

            var actual = store.Buy(book);

            var excepted = 100;

            Assert.AreEqual(excepted, actual);
        }
    }

    internal class Store
    {
        public Store()
        {
        }

        internal int Buy(Book book)
        {
            throw new NotImplementedException();
        }
    }

    #region DTO

    class Book
    {
        public int Episode { get; set; }
        public int Quantity { get; set; }
    }

    #endregion
}
