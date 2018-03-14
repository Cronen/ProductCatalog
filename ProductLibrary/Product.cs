using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLibrary
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public Category Category { get; set; }

        public Product(string name, double price, int amount, Category cat)
        {
            Name = name;
            Price = price;
            Amount = amount;
            Category = cat;
        }
    }
}
