using System;
using System.ComponentModel.DataAnnotations;

namespace Formula1.Models
{
    public class DriverCircuit
    {   
        [Key]
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
        public string CircuitId { get; set; }
        public Circuit Circuit { get; set; }
    }
}
