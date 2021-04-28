using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Formula1.Models
{
    public class Ranking
    {
        [Key]
        public int Place { get; set; }
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
        public int Points { get; set; }
    }
}
