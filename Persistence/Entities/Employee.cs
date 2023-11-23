using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string FirstSurname { get; set; }

    public string SecondSurname { get; set; }

    public string Extension { get; set; }

    public string Email { get; set; }

    public int IdOffice { get; set; }

    public int? IdBoss { get; set; }

    public string Position { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual Employee IdBossNavigation { get; set; }

    public virtual Office IdOfficeNavigation { get; set; }

    public virtual ICollection<Employee> InverseIdBossNavigation { get; set; } = new List<Employee>();
}
