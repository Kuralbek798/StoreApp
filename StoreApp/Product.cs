using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Store
{
    // Класс для представления товара
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }  
}
