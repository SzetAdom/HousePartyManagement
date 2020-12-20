using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HousePartyManagement.Models
{
    public class Snack
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Weight { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public bool IsActive { get; set; }

        public string PriceString()
        {
            return this.Price.ToString() + " Ft;";
        }
    }
}
