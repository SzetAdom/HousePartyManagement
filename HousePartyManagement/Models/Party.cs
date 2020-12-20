using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HousePartyManagement.Models
{
    public class Party
    {
        public int Id { get; set; }
        public string Host { get; set; }
        public string Location { get; set; }
        public DateTimeOffset Time { get; set; }

        public List<string> Members { get; set; }
        public int Capacity { get; set; }
        public int Price { get; set; }
        public List<Snack> Snacks { get; set; }

        public Dictionary<int, int> ConsumedSnacks { get; set; }

        public List<Drink> Drinks { get; set; }

        public Dictionary<int, double> ConsumedDrinks { get; set; }
    }
}
