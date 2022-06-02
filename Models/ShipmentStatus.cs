namespace ShipmentTrackerAPI.Models
{
    public enum ShipmentStatus
    {
        Initialized = 0,
        InProcess = 1,
        Processed = 2,
        Shipped = 3,
        InCustoms = 4,
        Delivered = 5,
        Returned = 6,
        Error = 7,
    }
}