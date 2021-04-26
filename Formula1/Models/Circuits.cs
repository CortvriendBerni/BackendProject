using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Formula1.Models
{
    public class Circuits
    {
        [Required]
        public string CircuitId { get; set; }
        public string CircuitName { get; set; }
        public string Url { get; set; }
        public string Country { get; set; }
        public List<DriverCircuits> DriversFavorite { get; set; }
    }
}
