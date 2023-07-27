using System;
using System.Collections.Generic;

namespace PracticaTicketManagement.Models;

public partial class TotalNumberOfTicketsPerCategory
{
    public int? Ticketcategoryid { get; set; }

    public int? Nroftickets { get; set; }

    public decimal? TotalOrderAmount { get; set; }
}
