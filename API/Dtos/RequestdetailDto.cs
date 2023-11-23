namespace API.Dtos;

public class RequestdetailDto{

    public int Id { get; set; }
    public int IdRequest { get; set; }

    public int IdProduct { get; set; }

    public int Quantity { get; set; }

    public decimal? UnitPrice { get; set; }

    public short LineNumber { get; set; }
}