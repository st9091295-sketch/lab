using System;
using System.Collections.Generic;
using System.Linq;
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
            var item = items.FirstOrDefault(i => i.Id == menuItemId);
            if (item != null) items.Remove(item);
        }

        public decimal GetTotal()
        {
            return items.Sum(i => i.Price);
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
            Console.WriteLine($"Сума: {GetTotal()} грн");
            Console.WriteLine("--------------------------------");
        }
    }
}
