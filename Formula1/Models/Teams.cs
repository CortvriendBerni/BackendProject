using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Formula1.Models
{
    public class Teams
    {
        [Key]
        public Guid TeamId { get; set; }
        public string TeamName { get; set; }
        public List<TeamDrivers> Drivers { get; set; }
    }
}
