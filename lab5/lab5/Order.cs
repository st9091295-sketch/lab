using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestaurantOrderSystem.Enums;
using RestaurantOrderSystem.Interfaces;

namespace RestaurantOrderSystem.Models
{
    public class Order : IHasId
    {
        private int id;
        private List<MenuItem> items = new();

        public int Id => id;
        public int TableNumber { get; set; }
        public OrderStatus Status { get; private set; }

        public IReadOnlyList<MenuItem> Items => items.AsReadOnly();

        public Order(int id, int tableNumber)
        {
            this.id = id;
            TableNumber = tableNumber;
            Status = OrderStatus.New;
        }

        public void AddItem(MenuItem item)
        {
            if (item != null) items.Add(item);
        }

        
        public void RemoveItem(int menuItemId)
        {
            MenuItem itemToRemove = null;

            // Шукаємо страву вручну
            foreach (var item in items)
            {
                if (item.Id == menuItemId)
                {
                    itemToRemove = item;
                    break; 
                }
            }

            // Якщо знайшли — видаляємо
            if (itemToRemove != null)
            {
                items.Remove(itemToRemove);
            }
        }

     
        public decimal GetTotal()
        {
            decimal sum = 0;

            // Рахуємо суму вручну
            foreach (var item in items)
            {
                sum += item.Price;
            }

            return sum;
        }

        public void ChangeStatus(OrderStatus status)
        {
            Status = status;
        }

        public void PrintShortInfo()
        {
            Console.WriteLine($"ID: {Id} | Стіл: {TableNumber} | Статус: {Status} | Сума: {GetTotal()} грн");
        }

        public void PrintDetailedInfo()
        {
            Console.WriteLine($"\n--- Замовлення #{Id} (стіл {TableNumber}) ---");
            foreach (var item in items)
            {
                item.PrintInfo();
            }
            Console.WriteLine($"--------------------------------");
            Console.WriteLine($"ЗАГАЛОМ: {GetTotal()} грн");
            Console.WriteLine($"Статус: {Status}\n");
        }
    }
}