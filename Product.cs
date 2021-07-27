using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FizzBuzz
{
    public class Product
    {
        public string Name { get; set; }

        public ProductCategory Category { get; set; }

        public decimal Stock { get; set; }

        public Product(string name, ProductCategory category, decimal stock)
        {
            Name = name;
            Category = category;
            Stock = stock;
        }
    }

    public enum ProductCategory
    {
        CLOTHES = 0,
        ELECTRONICS = 1,
        FOOD = 2,
    }
}
