using System;
using System.Collections.Generic;

namespace AHRestAPI.Models;

public partial class Client
{
    public int ClientId { get; set; }

    public string ClientName { get; set; } = null!;

    public decimal ClientPhone { get; set; }

    public string? ClientEmail { get; set; }

    public int? ClientCountoforders { get; set; }

    public string? ClientPassword { get; set; }
}
