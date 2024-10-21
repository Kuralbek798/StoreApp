using Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp
{
    public class Cart
    {
        private List<CartItem> _items;

        public Cart()
        {
            _items = new List<CartItem>();
        }

        // Добавить товар в корзину
        public void AddItem(Product product, int quantity)
        {
            // Проверить, есть ли товар уже в корзине
            var existingItem = _items.FirstOrDefault(item => item.Product.Id == product.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                _items.Add(new CartItem(product, quantity));
            }
        }

        // Удалить товар из корзины
        public void RemoveItem(Product product)
        {
            _items.RemoveAll(item => item.Product.Id == product.Id);
        }

        // Просмотреть текущее состояние корзины
        public void ViewCart()
        {
            if (_items.Count == 0)
            {
                Console.WriteLine("Корзина пуста.");
                return;
            }

            Console.WriteLine("Товары в корзине:");
            foreach (var item in _items)
            {
                Console.WriteLine($"- {item.Product.Name} x {item.Quantity}");
            }
        }

        // Получить общую стоимость товаров в корзине
        public decimal GetTotalCost()
        {
            return _items.Sum(item => item.Product.Price * item.Quantity);
        }
    }
}
