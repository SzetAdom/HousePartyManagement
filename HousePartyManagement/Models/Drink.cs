using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HousePartyManagement.Models
{
    public class Drink
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public double Bottle { get; set; }
        public double AlcoholPercentage { get; set; }
        public int Price { get; set; }
        public string Comment { get; set; }
        public bool IsActive { get; set; }

        public string AlcoholString()
        {
            return this.AlcoholPercentage.ToString() + "%";
        }

        public string BottleString()
        {
            return this.Bottle.ToString() + "l";
        }

        public string PriceString()
        {
            return this.Price.ToString() + " Ft;";
        }
    }
}
