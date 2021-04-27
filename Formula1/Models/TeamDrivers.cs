using System;

namespace Formula1.Models
{
    public class TeamDrivers
    {
        public int DriverId { get; set; }
        public Drivers Driver { get; set; }
        public string TeamId { get; set; }
        public Teams Teams { get; set; }
    }
}
