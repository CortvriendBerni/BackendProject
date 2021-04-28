using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Formula1.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public ICollection<Driver> Drivers { get; set; }
    }
}
