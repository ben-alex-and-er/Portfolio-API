using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class ClaimValue
{
    public uint Id { get; set; }

    public string Value { get; set; } = null!;

    public virtual ICollection<Claim> Claims { get; set; } = new List<Claim>();
}
