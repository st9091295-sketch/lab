using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderSystem.Models
{
    public class Drink : MenuItem
    {
        public int VolumeMl { get; set; }
        public bool IsAlcoholic { get; set; }

        public Drink(int id, string name, decimal price, string category, int volumeMl, bool isAlcoholic)
            : base(id, name, price, category)
        {
            VolumeMl = volumeMl;
            IsAlcoholic = isAlcoholic;
        }

        public override void PrintInfo()
        {
            string alc = IsAlcoholic ? "алкогольний" : "без алкоголю";
            Console.WriteLine($"{Name} ({Category}, {VolumeMl} мл, {alc}) — {Price} грн");
        }
    }
}

