using System;
using System.ComponentModel.DataAnnotations;

namespace ShipmentTrackerAPI.Models
{
    public class Customer
    {
        [Key]
        public long Id { get; set; }
        public string Href { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}