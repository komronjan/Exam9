namespace Domain.Entiti;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public List<OrderDetail> OrderDetail { get; set; }
}
