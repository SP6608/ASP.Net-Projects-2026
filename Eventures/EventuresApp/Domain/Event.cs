namespace EventuresApp.Domain
{
    public class Event
    {
        //Sled event user sazdavame Event
        public Guid Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string Place { get; set; }=string.Empty ;
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int TotalTickets { get; set; }
        public decimal PricePerTicket { get; set; }
        public EventuresUser Owner { get; set; } = null!;

        public string OwnerId { get; set; } = string.Empty;
    }
}
