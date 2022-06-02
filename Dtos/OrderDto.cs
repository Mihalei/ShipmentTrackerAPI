using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipmentTrackerAPI.Dtos
{
    public class OrderDto
    {
        public string Href { get; set; }
        public string Name { get; set; }
        public string ReferredType { get; set; }
    }
}
