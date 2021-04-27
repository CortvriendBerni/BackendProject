using System;
using System.ComponentModel.DataAnnotations;

namespace Formula1.Models
{
    public class Ranking
    {
        [Key]
        public string Place { get; set; }
        public Drivers DriverName { get; set; }
    }
}
