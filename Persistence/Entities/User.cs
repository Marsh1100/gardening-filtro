using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class User
{
    public int Id { get; set; }

    public string IdenNumber { get; set; }

    public string Username { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public virtual ICollection<Refreshtoken> Refreshtokens { get; set; } = new List<Refreshtoken>();

    public virtual ICollection<Rol> IdRols { get; set; } = new List<Rol>();
}
