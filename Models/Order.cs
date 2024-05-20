using System;
using System.Collections.Generic;

namespace AHRestAPI.Models;

public partial class Order
{
    public int OrderNoteid { get; set; }

    public int OrderId { get; set; }

    public int? AnimalId { get; set; }

    public int? RoomId { get; set; }

    public DateOnly? IssueDate { get; set; }

    public DateOnly? AdmissionDate { get; set; }

    public int? OrderStatusid { get; set; }

    public decimal? ClientPhone { get; set; }

    public virtual Animal? Animal { get; set; }

    public virtual OrderStatus? OrderStatus { get; set; }

    public virtual Room? Room { get; set; }
}
