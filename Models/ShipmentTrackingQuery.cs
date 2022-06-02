using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable enable
namespace ShipmentTrackerAPI.Models
{
    public class ShipmentTrackingQuery
    {
        public int? Status { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
    }
}
