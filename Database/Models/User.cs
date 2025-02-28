﻿using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class User
{
    public uint Id { get; set; }

    public string Identifier { get; set; } = null!;

    public virtual ICollection<UserPassword> UserPasswords { get; set; } = new List<UserPassword>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
