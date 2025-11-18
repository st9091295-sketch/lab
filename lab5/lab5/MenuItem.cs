using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestaurantOrderSystem.Interfaces;

namespace RestaurantOrderSystem.Models
{
    public abstract class MenuItem : IHasId
    {
        private int id;
        private string name;
        private decimal price;
        private string category;

        public int Id => id;

        public string Name
        {
            get => name;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    name = value;
            }
        }

        public decimal Price
        {
            get => price;
            set
            {
                if (value >= 0) price = value;
            }
        }

        public string Category
        {
            get => category;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    category = value;
            }
        }

        protected MenuItem(int id, string name, decimal price, string category)
        {
            this.id = id;
            Name = name;
            Price = price;
            Category = category;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"{Name} ({Category}) — {Price} грн");
        }
    }
}

