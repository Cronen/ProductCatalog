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
            Category Tshirt = new Category("T-shirt");
            Category Sweater = new Category("Sweater");
            Category Hoodie = new Category("Hoodie");
            List<Category> CatList = new List<Category>();
            CatList.Add(Tshirt);
            CatList.Add(Sweater);
            CatList.Add(Hoodie);

            Product p1 = new Product("Jack and Jones",149.00,"S", Tshirt);
            Product p2 = new Product("Solid",149.00,"M", Tshirt);
            Product p3 = new Product("H&M",99.00,"L", Tshirt);
            Product p4 = new Product("H&M",119.00,"XXL", Tshirt);
            Product p5 = new Product("H&M",199.00,"L", Sweater);
            Product p6 = new Product("Jack and Jones", 249.00, "XL", Sweater);
            Product p7 = new Product("Solid", 219.00, "M", Sweater);
            Product p8 = new Product("Solid", 249.00, "M", Hoodie);
            Product p9 = new Product("Jack and Jones", 199.00, "S", Hoodie);
            Product p10 = new Product("SuperDry", 175.00, "M", Tshirt);
            List<Product> prodList = new List<Product>();
            prodList.Add(p1);
            prodList.Add(p2);
            prodList.Add(p3);
            prodList.Add(p4);
            prodList.Add(p5);
            prodList.Add(p6);
            prodList.Add(p7);
            prodList.Add(p8);
            prodList.Add(p9);
            prodList.Add(p10);

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



    }
}
