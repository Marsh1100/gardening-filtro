using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class Rol
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<User> IdUsers { get; set; } = new List<User>();
}
