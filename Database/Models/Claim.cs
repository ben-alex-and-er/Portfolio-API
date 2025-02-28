using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class Claim
{
    public uint Id { get; set; }

    public uint ClaimTypeId { get; set; }

    public uint ClaimValueId { get; set; }

    public Guid Guid { get; set; }

    public virtual ClaimType ClaimType { get; set; } = null!;

    public virtual ClaimValue ClaimValue { get; set; } = null!;

    public virtual ICollection<RoleClaim> RoleClaims { get; set; } = new List<RoleClaim>();
}
