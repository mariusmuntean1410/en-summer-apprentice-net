namespace PracticaTicketManagement.Models.Dto
{
    public class EventPatchDto
    {
        public long EventId { get; set; }   
        public string EventName { get; set; } = string.Empty;

        public string? EventDescription { get; set; } 
    }
}
