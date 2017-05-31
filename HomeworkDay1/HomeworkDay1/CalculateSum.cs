using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkDay1
{
    public class CalculateSum
    {
        private List<Product> _products;

        public CalculateSum(List<Product> products)
        {
            this._products = products;
        }


        public List<int> GetCostSumByGroupCount(int count)
        {
            Expression<Func<Product, int>> sumPredicate = r => r.Cost;

            return GetSumResultByCount<Product>(_products, count, sumPredicate);

        }

        public List<int> GetRevenueSumByGroupCount(int count)
        {
            Expression<Func<Product, int>> sumPredicate = r => r.Revenue;

            return GetSumResultByCount<Product>(_products, count, sumPredicate);

        }

        private List<int> GetSumResultByCount<T>(List<T> data, int count, Expression<Func<T,int>> predicate)
        {
            var result = new List<int>();

            var step = (int)Math.Ceiling(Convert.ToDouble(data.Count) / count);

            for (int i = 0; i < step; i++)
            {
                var groupSum = data.AsQueryable()
                    .Skip(i * count)
                    .Take(count)
                    .Sum(predicate);

                result.Add(groupSum);
            }

            return result;
        }

        public int GetCostSumByIdGroup(List<int> ids)
        {
            var result = new List<int>();

            var products = _products
                .Where(r => ids.Contains(r.ID));

            return products.Sum(r => r.Cost);
        }

        public int GetRevenueSumByIdGroup(List<int> ids)
        {
            var result = new List<int>();

            var products = _products
                .Where(r => ids.Contains(r.ID));

            return products.Sum(r => r.Revenue);
        }

    }
}
