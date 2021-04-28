using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Formula1.Models
{
    public class Driver
    {
        [Key]
        public int DriverId { get; set; }
        public string DriverName { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public string Team { get; set; }
        public Ranking Rank { get; set; }
        
        [JsonIgnore]
        public List<DriverCircuit> FavoriteCircuits { get; set; }
    }
}
