using System;
using System.Collections.Generic;

namespace AHRestAPI.Models;

public partial class Servicecategory
{
    public int ServicecategoryId { get; set; }

    public string? ServicecategoryName { get; set; }

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
