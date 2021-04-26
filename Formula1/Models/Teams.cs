using System;
using System.Collections.Generic;

namespace Formula1.Models
{
    public class Teams
    {
        public string TeamId { get; set; }
        public string TeamName { get; set; }
        public List<TeamDrivers> Drivers { get; set; }
    }
}
