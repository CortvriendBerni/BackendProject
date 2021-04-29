using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Formula1.Models
{
    public class Ranking
    {
        [Key]
        public int Place { get; set; }
        
        [JsonIgnore]
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
        public int Points { get; set; }
    }
}
