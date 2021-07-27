using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FizzBuzz
{
    class ProductOperations
    {
        //Order a list of products by category and after that by name
        public List<Product> OrderByCategoryAndByName(List<Product> products)
        {
            var sortedcategory = products.OrderBy(x => x.Category).ThenBy(x => x.Name);

            List<Product> sorted = new List<Product>();

            //Make a copy of the products list in order to not modify the initial list
            foreach (Product product in sortedcategory)
            {
                sorted.Add(product);
            }

            return sorted;
        }


        //Check all the products where stock is zero
        public List<Product> CheckProductsWithoutStock(List<Product> products)
        {
            List<Product> productsWithoutStock = new List<Product>();

            //Make a copy of the products list in order to not modify the initial list
            foreach (Product product in products)
            {
                if (product.Stock == 0)
                    productsWithoutStock.Add(product);
            }

            return productsWithoutStock;
        }
    }
}
