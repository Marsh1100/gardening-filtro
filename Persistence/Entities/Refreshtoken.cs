﻿using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class Refreshtoken
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Token { get; set; }

    public DateTime Expires { get; set; }

    public DateTime Created { get; set; }

    public DateTime? Revoked { get; set; }

    public virtual User User { get; set; }
}
