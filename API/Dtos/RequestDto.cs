namespace API.Dtos;

public class RequestDto{

    public int Id { get; set; }
    public DateOnly RequestDate { get; set; }

    public DateOnly ExpectedDate { get; set; }

    public DateOnly? DeliveryDate { get; set; }

    public string State { get; set; }

    public string Feedback { get; set; }

    public int IdClient { get; set; }
}