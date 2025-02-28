using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class ClaimType
{
    public uint Id { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<Claim> Claims { get; set; } = new List<Claim>();
}
