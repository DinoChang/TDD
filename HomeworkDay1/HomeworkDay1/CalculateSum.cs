using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkDay1
{
    public class CalculateSum
    {
        private List<Product> GetProducts()
        {
            var products = new List<Product>
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


            return products;
        }

        public List<int> GetCostSumBy3Count()
        {
            return GetCostSumByGroupCount(3);
        }

        public List<int> GetRevenueSumBy4Count()
        {
            return GetRevenueSumByGroupCount(4);
        }


        public List<int> GetCostSumByGroupCount(int count)
        {
            var result = new List<int>();

            var products = GetProducts();

            if (products.Any() == false)
            {
                result.Add(0);
                return result;
            }

            var step = (int)Math.Ceiling(Convert.ToDouble(products.Count) / count);

            products = products.OrderBy(r => r.ID).ToList();

            for (int i = 0; i < step; i++)
            {
                var groupSum = products
                    .Skip(i * count)
                    .Take(count)
                    .Sum(r => r.Cost);

                result.Add(groupSum);
            }

            return result;

        }

        public List<int> GetRevenueSumByGroupCount(int count)
        {
            var result = new List<int>();

            var products = GetProducts();

            if (products.Any() == false)
            {
                result.Add(0);
                return result;
            }

            var step = (int)Math.Ceiling(Convert.ToDouble(products.Count) / count);

            products = products.OrderBy(r => r.ID).ToList();

            for (int i = 0; i < step; i++)
            {
                var groupSum = products
                    .Skip(i * count)
                    .Take(count)
                    .Sum(r => r.Revenue);

                result.Add(groupSum);
            }

            return result;

        }

        public int GetCostSumByIdGroup(List<int> ids)
        {
            var result = new List<int>();

            var products = GetProducts()
                .Where(r => ids.Contains(r.ID));

            return products.Sum(r => r.Cost);
        }

        public int GetRevenueSumByIdGroup(List<int> ids)
        {
            var result = new List<int>();

            var products = GetProducts()
                .Where(r => ids.Contains(r.ID));

            return products.Sum(r => r.Revenue);
        }
    }
}
