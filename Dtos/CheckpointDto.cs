using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipmentTrackerAPI.Dtos
{
    public class CheckpointDto
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string Date { get; set; }
        public string CheckPost { get; set; }
        public string City { get; set; }
        public string StateOrProvince { get; set; }
        public string Country { get; set; }
        public List<CharacteristicDto> Characteristics { get; set; }
    }
}
