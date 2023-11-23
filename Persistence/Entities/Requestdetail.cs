using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class Requestdetail
{
    public int Id { get; set; }

    public int IdRequest { get; set; }

    public int IdProduct { get; set; }

    public int Quantity { get; set; }

    public decimal? UnitPrice { get; set; }

    public short LineNumber { get; set; }

    public virtual Product IdProductNavigation { get; set; }

    public virtual Request IdRequestNavigation { get; set; }
}
