using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantOrderSystem.Models;

namespace RestaurantOrderSystem.Services
{
    public class Restaurant
    {
        private List<MenuItem> menu = new();
        private List<Order> orders = new();

        public void AddMenuItem(MenuItem item)
        {
            if (item != null) menu.Add(item);
        }

        public void PrintMenu()
        {
            Console.WriteLine("--- МЕНЮ ---");
            foreach (var item in menu)
            {
                Console.Write($"{item.Id}. ");
                item.PrintInfo();
            }
        }

        public List<MenuItem> SearchMenuByName(string name)
        {
            return menu.Where(m => m.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<MenuItem> SearchMenuByCategory(string category)
        {
            return menu.Where(m => m.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public Order CreateOrder(int id, int table)
        {
            Order o = new Order(id, table);
            orders.Add(o);
            return o;
        }

        public Order? FindOrderById(int id)
        {
            return orders.FirstOrDefault(o => o.Id == id);
        }

        public void PrintAllOrders()
        {
            if (orders.Count == 0)
            {
                Console.WriteLine("Замовлень немає.");
                return;
            }

            foreach (var o in orders)
                o.PrintShortInfo();
        }
    }
}
