using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Formula1.Models
{
    public class Circuit
    {
        [Key]
        public string CircuitId { get; set; }
        public string CircuitName { get; set; }
        public string Country { get; set; }
        public List<DriverCircuit> DriversFavorite { get; set; }
        public string Url { get; set; }
    }
}
