using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLibrary
{
    class DBProvider
    {
        public void SetupDB(string path)
        {
            Category Tshirt = new Category("T-shirt");
            Category Sweater = new Category("Sweater");
            Category Hoodie = new Category("Hoodie");
            List<Category> CatList = new List<Category>();
            CatList.Add(Tshirt);
            CatList.Add(Sweater);
            CatList.Add(Hoodie);

            Product Jack = new Product("Jack and jones",149,"S", Tshirt);
            Product Jack1 = new Product("Solid",149,"M", Tshirt);
            Product Jack2 = new Product("H&M",99,"L", Tshirt);


        }
        public static void WriteJsonData(string path, List<object> theList)
        {
            //serirliaze the list of Students ==> as json
            var jsonData = JsonConvert.SerializeObject(theList, Formatting.Indented);
            //save the json to the file
            File.WriteAllText(path, jsonData);
        }
    }
}
