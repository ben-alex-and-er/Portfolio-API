using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class UserRole
{
    public uint Id { get; set; }

    public uint UserId { get; set; }

    public uint RoleId { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
