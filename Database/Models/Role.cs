using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class Role
{
    public uint Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<RoleClaim> RoleClaims { get; set; } = new List<RoleClaim>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
