using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class Password
{
    public uint Id { get; set; }

    public string Hash { get; set; } = null!;

    public virtual ICollection<UserPassword> UserPasswords { get; set; } = new List<UserPassword>();
}
