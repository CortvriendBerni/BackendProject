using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Formula1.Models
{
    public class Drivers
    {
        [Key]
        public Guid DriverId{ get; set; }
        public int Number { get; set; }
        public string DriverName { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public string Team { get; set; }
        
        [JsonIgnore]
        public List<DriverCircuits> FavoriteCircuits { get; set; }
    }
}
