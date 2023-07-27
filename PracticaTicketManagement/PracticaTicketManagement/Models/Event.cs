using System;
using System.Collections.Generic;

namespace PracticaTicketManagement.Models;

public partial class Event
{
    public int EventId { get; set; }

    public int? VenueId { get; set; }

    public int? EventTypeId { get; set; }

    public string? EventDescription { get; set; } = null!;

    public string? EventName { get; set; } = null!;

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual EventType? EventType { get; set; } = null!;

    public virtual ICollection<TicketCategory> TicketCategories { get; set; } = new List<TicketCategory>();

    public virtual Venue? Venue { get; set; } = null!;
}
