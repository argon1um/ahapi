using System;
using System.Collections.Generic;

namespace AHRestAPI.Models;

public partial class OrderStatus
{
    public int OrderstatusId { get; set; }

    public string? OrderstatusName { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
