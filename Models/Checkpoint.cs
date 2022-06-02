using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShipmentTrackerAPI.Models
{
    public class Checkpoint
    {
        [Key]
        public long Id { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public string CheckPost { get; set; }
        public string City { get; set; }
        public string StateOrProvince { get; set; }
        public string Country { get; set; }
        public List<Characteristic> Characteristics { get; set; } = new();
    }
}