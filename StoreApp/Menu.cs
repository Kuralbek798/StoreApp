using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp
{
    public class Menu
    {
        private Store _store;
        private Cart _cart;

        public Menu(Store store, Cart cart)
        {
            _store = store;
            _cart = cart;
        }

        // Вывод главного меню
        public void ShowMainMenu()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Главное меню:");
            Console.WriteLine("1. Просмотр списка товаров");
            Console.WriteLine("2. Добавить товар в корзину");
            Console.WriteLine("3. Удалить товар из корзины");
            Console.WriteLine("4. Просмотреть корзину");
            Console.WriteLine("5. Выход");
        }

        // Обработка выбора меню
        public void HandleMenuChoice()
        {
            while (true)
            {
                ShowMainMenu();
                Console.WriteLine("Выберите действие:");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Некорректный ввод.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        ViewProducts();
                        break;
                    case 2:
                        AddProductToCart();
                        break;
                    case 3:
                        RemoveProductFromCart();
                        break;
                    case 4:
                        ViewCart();
                        break;
                    case 5:
                        Console.WriteLine("Выход из программы.");
                        return;
                    default:
                        Console.WriteLine("Неверный выбор.");
                        break;
                }
            }
        }

        // Просмотреть список товаров
        private void ViewProducts()
        {
            Console.WriteLine("Список товаров:");
            foreach (var product in _store.GetProducts())
            {
                Console.WriteLine($"- {product.Id}. {product.Name} - {product.Price:C}");
            }
        }

        // Добавить товар в корзину
        private void AddProductToCart()
        {
            ViewProducts();
            Console.WriteLine("Введите ID товара, который хотите добавить в корзину:");

            int productId;
            if (!int.TryParse(Console.ReadLine(), out productId))
            {
                Console.WriteLine("Некорректный ввод.");
                return;
            }

            var product = _store.GetProducts().FirstOrDefault(p => p.Id == productId);
            if (product == null)
            {
                Console.WriteLine("Товар не найден.");
                return;
            }

            Console.WriteLine("Введите количество:");
            int quantity;
            if (!int.TryParse(Console.ReadLine(), out quantity))
            {
                Console.WriteLine("Некорректный ввод.");
                return;
            }

            _cart.AddItem(product, quantity);
            Console.WriteLine("Товар добавлен в корзину.");
        }

        // Удалить товар из корзины
        private void RemoveProductFromCart()
        {
            _cart.ViewCart();

            Console.WriteLine("Введите ID товара, который хотите удалить из корзины:");
            int productId;
            if (!int.TryParse(Console.ReadLine(), out productId))
            {
                Console.WriteLine("Некорректный ввод.");
                return;
            }

            var product = _store.GetProducts().FirstOrDefault(p => p.Id == productId);
            if (product == null)
            {
                Console.WriteLine("Товар не найден.");
                return;
            }

            _cart.RemoveItem(product);
            Console.WriteLine("Товар удален из корзины.");
        }

        // Просмотреть корзину
        private void ViewCart()
        {
            _cart.ViewCart();
            Console.WriteLine($"Общая стоимость: {_cart.GetTotalCost():C}");
        }
    }
}
