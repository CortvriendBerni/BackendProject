using System;

namespace Formula1.Models
{
    public class DriverCircuit
    {   
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
        public string CircuitId { get; set; }
        public Circuit Circuit { get; set; }
    }
}
