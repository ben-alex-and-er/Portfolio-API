using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class UserPassword
{
    public uint Id { get; set; }

    public uint UserId { get; set; }

    public uint PasswordId { get; set; }

    public virtual Password Password { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
