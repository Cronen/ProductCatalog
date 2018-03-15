using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLibrary
{
    public static class DBProvider
    {
        public static void SetupDB(string pathCat, string pathPro)
        {
            Category Tshirt = new Category(1, "T-shirt");
            Category Sweater = new Category(2, "Sweater");
            Category Hoodie = new Category(3, "Hoodie");
            List<Category> CatList = new List<Category>() { Tshirt, Sweater, Hoodie };

            Product p1 = new Product(1, "Jack and Jones", 149.00, "S", Tshirt);
            Product p2 = new Product(2, "Solid", 149.00, "M", Tshirt);
            Product p3 = new Product(3, "H&M", 99.00, "L", Tshirt);
            Product p4 = new Product(4, "H&M", 119.00, "XXL", Tshirt);
            Product p5 = new Product(5, "H&M", 199.00, "L", Sweater);
            Product p6 = new Product(6, "Jack and Jones", 249.00, "XL", Sweater);
            Product p7 = new Product(7, "Solid", 219.00, "M", Sweater);
            Product p8 = new Product(8, "Solid", 249.00, "M", Hoodie);
            Product p9 = new Product(9, "Jack and Jones", 199.00, "S", Hoodie);
            Product p10 = new Product(10, "SuperDry", 175.00, "M", Tshirt);
            List<Product> prodList = new List<Product>() { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10 };

            WriteJsonData(pathCat, new List<object>(CatList));
            WriteJsonData(pathPro, new List<object>(prodList));
        }
        public static void WriteJsonData(string path, List<object> theList)
        {
            //serirliaze the list of Students ==> as json
            var jsonData = JsonConvert.SerializeObject(theList, Formatting.Indented);
            //save the json to the file
            File.WriteAllText(path, jsonData);
        }
        public static List<Category> GetCategories(string path)
        {
            //read the content from the json file
            var jsonData = File.ReadAllText(path);
            var format = "yyyy-MM-dd"; // your datetime format 2003-02-29
            var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = format };
            //deserialize the json data, convert it to a List of objects of type Student
            List<Category> result = JsonConvert.DeserializeObject<List<Category>>(jsonData, dateTimeConverter);
            return result;
        }
        public static List<Product> GetProducts(string path)
        {
            //read the content from the json file
            var jsonData = File.ReadAllText(path);
            var format = "yyyy-MM-dd"; // your datetime format 2003-02-29
            var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = format };
            //deserialize the json data, convert it to a List of objects of type Student
            List<Product> result = JsonConvert.DeserializeObject<List<Product>>(jsonData, dateTimeConverter);
            return result;
        }
        public static List<Product> GetProductsOrdered(string path)
        {
            var proList = GetProducts(path);
            return proList.OrderBy(p => p.Name).ToList(); ;
        }
        public static Product GetProduct(int id, string path)
        {
            var productList = GetProducts(path);
            return productList.SingleOrDefault(pr => pr.ID == id);
        }
        public static List<Product> GetProductsFromCategory(string cat, string path)
        {
            var proList = GetProducts(path);
            return proList.Where(p => p.Category.Name == cat).ToList();
        }
    }
}
