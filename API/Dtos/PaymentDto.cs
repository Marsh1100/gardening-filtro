namespace API.Dtos;

public class PaymentDto{

    public int Id { get; set; }
    
    public int IdClient { get; set; }

    public string TransactionId { get; set; }

    public string PaymentMethod { get; set; }

    public DateOnly PaymentDate { get; set; }

    public decimal Total { get; set; }
}