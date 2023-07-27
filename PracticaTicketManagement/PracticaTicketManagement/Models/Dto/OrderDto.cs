namespace PracticaTicketManagement.Models.Dto
{
    public class OrderDto
    {
        public int OrderId { get; set; }

        public int? NumberOfTickets { get; set; }

        public DateTime? OrderedAt { get; set; }

        public string? Customer { get; set; }

        public string? TicketCategory { get; set; }

        public double? TotalPrice { get; set; }
    }
}
