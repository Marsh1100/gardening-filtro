namespace API.Dtos;

public class EmployeeDto{

     public string Name { get; set; }

    public string FirstSurname { get; set; }

    public string SecondSurname { get; set; }

    public string Extension { get; set; }

    public string Email { get; set; }

    public int IdOffice { get; set; }

    public int? IdBoss { get; set; }

    public string Position { get; set; }
}