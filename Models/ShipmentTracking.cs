using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShipmentTrackerAPI.Models
{
    public class ShipmentTracking
    {
        [Key]
        public long Id { get; set; }
        public string Href { get; set; }
        public string Carrier { get; set; }
        public string TrackingCode { get; set; }
        public string CarrierTrackingUrl { get; set; }
        public DateTime TrackingDate { get; set; }
        public ShipmentStatus Status { get; set; }
        public DateTime StatusChangeDate { get; set; }
        public string StatusChangeReason { get; set; }
        public float Weight { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
        public string AddressFrom { get; set; }
        public string AddressTo { get; set; }
        public Checkpoint Checkpoint { get; set; }
        public Order Order { get; set; }
        public Customer RelatedCustomer { get; set; }
        public DateTime CreateDate { get; set; }
        public List<Characteristic> Characteristics { get; set; } = new();
    }
}
