using System;
using System.Collections.Generic;

namespace AHRestAPI.Models;

public partial class Order
{
    public int OrderNoteid { get; set; }

    public int OrderId { get; set; }

    public int? ClientId { get; set; }

    public int? AnimalId { get; set; }

    public int? RoomId { get; set; }

    public DateOnly? IssueDate { get; set; }

    public DateOnly? AdmissionDate { get; set; }

    public int? WorkerId { get; set; }

    public int? OrderStatusid { get; set; }

    public int? ServiceId { get; set; }

    public int? TotalPrice { get; set; }

    public virtual Animal? Animal { get; set; }

    public virtual Client? Client { get; set; }

    public virtual OrderStatus? OrderStatus { get; set; }

    public virtual Room? Room { get; set; }

    public virtual Service? Service { get; set; }

    public virtual Worker? Worker { get; set; }
}
