using Store;

namespace StoreApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создать магазин
            Store store = new Store();

            // Загрузить товары из JSON файла (опционально)
         //  store.getProductsFromFile("products.json");

            // Создать корзину покупок
            Cart cart = new Cart();

            // Создать меню
            Menu menu = new Menu(store, cart);

            // Заполнить магазин товарами
            store.AddProduct(new Product(1, "Молоко", 2.5m));
            store.AddProduct(new Product(2, "Хлеб", 1.5m));
            store.AddProduct(new Product(3, "Яйца", 3.0m));

            // Запустить меню
         
            menu.HandleMenuChoice();
        }
    }
}
