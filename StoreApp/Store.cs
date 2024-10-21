using Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StoreApp
{
    public class Store
    {
        private List<Product> _products;
      
    

        public Store()
        {
            _products = new List<Product>();
            
        }

        // Добавить товар в магазин
        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        // Получить список товаров
        public List<Product> GetProducts()
        {
            return _products;
        }

        // Загрузить товары из JSON файла
        public void getProductsFromFile(string path)
        {
            _products = JsonUtil.LoadProductsFromJson(path);
        }
        // Сохранить товары в JSON файл
        public void setProductsToFile(string path, List<Product> products)
        {
            JsonUtil.SaveProductsToJson(path, products);
        }

    }
}
