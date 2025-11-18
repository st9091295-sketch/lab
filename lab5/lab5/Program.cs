using System;
using RestaurantOrderSystem.Services;
using RestaurantOrderSystem.Models;
using RestaurantOrderSystem.Enums;

namespace RestaurantOrderSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Restaurant restaurant = new Restaurant();

            Drink cola = new Drink(1, "Кола", 45m, "Напій", 250, false);
            MenuItem colaAsMenuItem = cola; // upcast

            restaurant.AddMenuItem(colaAsMenuItem);
            restaurant.AddMenuItem(new Drink(2, "Латте", 70m, "Кава", 200, false));
            restaurant.AddMenuItem(new Drink(3, "Пиво", 65m, "Алкогольний напій", 300, true));
            restaurant.AddMenuItem(new Dish(4, "Борщ", 120m, "Перше"));
            restaurant.AddMenuItem(new Dish(5, "Вареники", 95m, "Основна страва"));
            restaurant.AddMenuItem(new Dish(6, "Цезар", 110m, "Салат"));

            restaurant.PrintMenu();

            Console.WriteLine("\nДемонстрація downcast:");
            if (colaAsMenuItem is Drink drinkFromBase)
            {
                Console.WriteLine($"Напій: {drinkFromBase.Name}, {drinkFromBase.VolumeMl} мл");
            }

            Order order1 = restaurant.CreateOrder(101, 5);
            order1.AddItem(colaAsMenuItem);
            order1.AddItem(restaurant.SearchMenuByName("Борщ")[0]);
            order1.AddItem(restaurant.SearchMenuByName("Латте")[0]);

            order1.PrintDetailedInfo();

            order1.ChangeStatus(OrderStatus.InProgress);
            order1.ChangeStatus(OrderStatus.Ready);
            order1.ChangeStatus(OrderStatus.Paid);

            Console.WriteLine("\nУсі замовлення:");
            restaurant.PrintAllOrders();

            Console.WriteLine("\nПошук у меню за категорією 'Перше':");
            foreach (var item in restaurant.SearchMenuByCategory("Перше"))
                item.PrintInfo();

            Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}
