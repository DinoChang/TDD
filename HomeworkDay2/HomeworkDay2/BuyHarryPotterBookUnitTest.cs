using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace HomeworkDay2
{
    [TestClass]
    public class BuyHarryPotterBookUnitTest
    {
        private Store _store;

        [TestInitialize]
        public void Init()
        {
            var discountSetting = new Dictionary<int, decimal>
            {
                {1, 1m},
                {2, 0.95m},
                {3, 0.9m},
                {4, 0.8m},
                {5, 0.75m}
            };

            this._store = new Store(discountSetting);
        }

        [TestCleanup]
        public void CleanUp()
        {
            _store = null;
        }

        [TestMethod]
        public void 第一集買了一本_其它都沒買_價格應為100()
        {
            var books = new List<Book>{
                new Book { Episode = 1, Quantity = 1, Amount = 100 }
            };

            var actual = _store.Buy(books);

            var excepted = 100m;

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void 第一集買了一本_第二集也買了一本_價格應為190()
        {
            var books = new List<Book>{
                new Book { Episode = 1, Quantity = 1, Amount = 100 },
                new Book { Episode = 2, Quantity = 1, Amount = 100 }
            };

            var actual = _store.Buy(books);

            var excepted = 190m;

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void 一二三集各買了一本_價格應該270()
        {
            var books = new List<Book>{
                new Book { Episode = 1, Quantity = 1, Amount = 100 },
                new Book { Episode = 2, Quantity = 1, Amount = 100 },
                new Book { Episode = 3, Quantity = 1, Amount = 100 }
            };

            var actual = _store.Buy(books);

            var excepted = 270m;

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void 一二三四集各買了一本_價格應該320()
        {
            var books = new List<Book>{
                new Book { Episode = 1, Quantity = 1, Amount = 100 },
                new Book { Episode = 2, Quantity = 1, Amount = 100 },
                new Book { Episode = 3, Quantity = 1, Amount = 100 },
                new Book { Episode = 4, Quantity = 1, Amount = 100 }
            };

            var actual = _store.Buy(books);

            var excepted = 320m;

            Assert.AreEqual(excepted, actual);
        }
    }
    #region Production Code

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

    #endregion

    #region DTO

    class Book
    {
        public int Episode { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
    }

    #endregion
}
