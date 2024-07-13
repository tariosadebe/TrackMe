namespace TrackMe.Models.Entities
{
    public class TrackingEvent
    {
        public int Id { get; set; }
        public int ShipmentId { get; set; }
        public TrackingStatus Status { get; set; }
        public string Location { get; set; }
        public DateTime Timestamp { get; set; }
        public string Description { get; set; }
    }
}
