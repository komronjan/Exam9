namespace Domain.Dtos;

public class OrderDto
{
    public int Id { get; set; }

    public DateTime OrderPlaced { get; set; }
    public DateTime OrderFullFilled { get; set; }
    public int CustomerId { get; set; }
   
}
