using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace HomeworkDay2
{
    [TestClass]
    public class BuyHarryPotterBookUnitTest
    {
        [TestMethod]
        public void 第一集買了一本其它都沒買價格應為100()
        {
            var discountSetting = new Dictionary<int, decimal>
            {
                {1, 1m},
                {2, 0.95m},
                {3, 0.9m},
                {4, 0.8m},
                {5, 0.75m}
            };

            var store = new Store(discountSetting);

            var books = new List<Book>{
                new Book { Episode = 1, Quantity = 1, Amount = 100 }
            };

            var actual = store.Buy(books);

            var excepted = 100m;

            Assert.AreEqual(excepted, actual);
        }
    }

    internal class Store
    {
        private Dictionary<int, decimal> _discountSetting;
        public Store(Dictionary<int, decimal> discountSetting)
        {
            this._discountSetting = discountSetting;
        }

        internal decimal Buy(List<Book> books)
        {
            var totalAmount = books
                .Sum(r => r.Quantity * r.Amount) * this._discountSetting[books.Count];

            return totalAmount;
        }
    }

    #region DTO

    class Book
    {
        public int Episode { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
    }

    #endregion
}
