using System;

namespace Formula1.Models
{
    public class DriverCircuits
    {   
        public int DriverId { get; set; }
        public Drivers Driver { get; set; }
        public string CircuitId { get; set; }
        public Circuits Circuits { get; set; }
    }
}
