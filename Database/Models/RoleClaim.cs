using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class RoleClaim
{
    public uint Id { get; set; }

    public uint RoleId { get; set; }

    public uint ClaimId { get; set; }

    public virtual Claim Claim { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}
