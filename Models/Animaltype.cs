using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AHRestAPI.Models;

public partial class Animaltype
{
    public int AnimaltypeId { get; set; }

    public string? AnimaltypeName { get; set; }

    [JsonIgnore]
    public virtual ICollection<Animalbreed> Animalbreeds { get; set; } = new List<Animalbreed>();
}
