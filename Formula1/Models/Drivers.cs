using System;
using System.Collections.Generic;

namespace Formula1.Models
{
    public class Drivers
    {
        public int DriverId{ get; set; }
        public int Number { get; set; }
        public string DriverName { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public string Team { get; set; }
        public List<DriverCircuits> FavoriteCircuits { get; set; }
    }
}
