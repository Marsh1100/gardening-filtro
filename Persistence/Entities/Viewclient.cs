using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class Viewclient
{
    public int Id { get; set; }

    public string NameClient { get; set; }

    public string NameContact { get; set; }

    public string LastnameContact { get; set; }

    public string PhoneNumber { get; set; }

    public string Fax { get; set; }

    public string Address1 { get; set; }

    public string Address2 { get; set; }

    public string City { get; set; }

    public string Region { get; set; }

    public string Country { get; set; }

    public string ZipCode { get; set; }

    public int? IdEmployee { get; set; }

    public decimal? CreditLimit { get; set; }
}
