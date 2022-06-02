using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable enable
namespace ShipmentTrackerAPI.Dtos
{
    public class ShipmentTrackingDto
    {
        public string? Href { get; set; }
        public string? Carrier { get; set; }
        public string? TrackingCode { get; set; }
        public string? CarrierTrackingUrl { get; set; }
        public string? TrackingDate { get; set; }
        public int? Status { get; set; }
        public string? StatusChangeDate { get; set; }
        public string? StatusChangeReason { get; set; }
        public float? Weight { get; set; }
        public string? EstimatedDeliveryDate { get; set; }
        public string? AddressFrom { get; set; }
        public string? AddressTo { get; set; }
        public CheckpointDto? Checkpoint { get; set; }
        public OrderDto? Order { get; set; }
        public CustomerDto? RelatedCustomer { get; set; }
        public string? CreateDate { get; set; }
        public List<CharacteristicDto>? Characteristics { get; set; }
    }
}
