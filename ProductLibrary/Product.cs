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
        public string Size { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }

        public Product(string name, double price, string size, Category cat)
        {
            Name = name;
            Price = price;
            Size = size;
            Category = cat;
        }
    }
}
