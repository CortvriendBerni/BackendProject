using System;

namespace Formula1.Models
{
    public class TeamDriver
    {
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
        public string TeamId { get; set; }
        public Team Team { get; set; }
    }
}
