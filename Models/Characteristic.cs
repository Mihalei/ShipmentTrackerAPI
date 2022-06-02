using System;
using System.ComponentModel.DataAnnotations;

namespace ShipmentTrackerAPI.Models
{
    public class Characteristic
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}