using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Formula1.Models
{
    public class DriverCircuit
    {   
        [Key]
        [JsonIgnore]
        public int DriverId { get; set; }

        [JsonIgnore]
        public Driver Driver { get; set; }
        
        [JsonIgnore]
        public string CircuitId { get; set; }
        public Circuit Circuit { get; set; }
    }
}
