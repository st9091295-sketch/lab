using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderSystem.Models
{
    public class Dish : MenuItem
    {
        public Dish(int id, string name, decimal price, string category)
            : base(id, name, price, category)
        {
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"{Name} (страва, {Category}) — {Price} грн");
        }
    }
}

