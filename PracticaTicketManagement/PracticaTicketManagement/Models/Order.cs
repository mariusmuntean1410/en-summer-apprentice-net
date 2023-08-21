﻿using System;
using System.Collections.Generic;

namespace PracticaTicketManagement.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int? CustomerId { get; set; }

    public int? TicketCategoryId { get; set; }

    public DateTime? OrderedAt { get; set; }

    public int? NumberOfTickets { get; set; }

    public double? TotalPrice { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual TicketCategory TicketCategory { get; set; } = null!;
}
