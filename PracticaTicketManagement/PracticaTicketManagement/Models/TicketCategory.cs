using System;
using System.Collections.Generic;

namespace PracticaTicketManagement.Models;

public partial class TicketCategory
{
    public int TicketCategoryId { get; set; }

    public int? EventId { get; set; }

    public string? Description { get; set; } = null!;

    public double? Price { get; set; }

    public virtual Event? Event { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();


    public override string ToString()
    {
        return Description;
    }
}
