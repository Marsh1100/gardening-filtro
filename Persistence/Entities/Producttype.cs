using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class Producttype
{
    public int Id { get; set; }

    public string Type { get; set; }

    public string DescriptionText { get; set; }

    public string DescriptionHtml { get; set; }

    public string Image { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
