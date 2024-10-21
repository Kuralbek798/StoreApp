using Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StoreApp
{
   public class JsonUtil
    {
        // Загрузить товары из JSON файла
        public static List<Product> LoadProductsFromJson(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Файл не найден.");
                return null;
            }

            string json = File.ReadAllText(filePath);
            var products = JsonSerializer.Deserialize<List<Product>>(json);
            return products;
        }

        // Сохранить товары в JSON файл
        public static  void SaveProductsToJson(string filePath, List<Product> products)
        {
            string json = JsonSerializer.Serialize(products);
            File.WriteAllText(filePath, json);
        }
    }
}
