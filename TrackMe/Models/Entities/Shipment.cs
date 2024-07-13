using System.Threading;

namespace TrackMe.Models.Entities
{
    public class Shipment
    {
        public int Id { get; set; }
        public string TrackingNumber { get; set; }
        public int CarrierId { get; set; }
        public int UserId { get; set; }
        public ShipmentStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
