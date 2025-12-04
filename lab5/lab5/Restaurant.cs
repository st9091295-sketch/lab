using System;
using System.Collections.Generic;
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
            List<MenuItem> result = new List<MenuItem>();

            foreach (var m in menu)
            {
               
                if (m.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(m);
                }
            }

            return result;
        }

        
        public List<MenuItem> SearchMenuByCategory(string category)
        {
            List<MenuItem> result = new List<MenuItem>();

            foreach (var m in menu)
            {
                
                if (m.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(m);
                }
            }

            return result;
        }

        public Order CreateOrder(int id, int table)
        {
            Order o = new Order(id, table);
            orders.Add(o);
            return o;
        }

        
        public Order? FindOrderById(int id)
        {
            foreach (var o in orders)
            {
                if (o.Id == id)
                {
                    return o; 
                }
            }

            return null; 
        }

        public void PrintAllOrders()
        {
            if (orders.Count == 0)
            {
                Console.WriteLine("Замовлень немає.");
                return;
            }

            foreach (var order in orders)
            {
                order.PrintShortInfo();
            }
        }
    }
}