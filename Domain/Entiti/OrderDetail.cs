namespace Domain.Entiti;

public class OrderDetail
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public int OrderId { get; set; }
    public List<Order> Order { get; set; }
    public int ProductId { get; set; }
    public List<Product> Product { get; set; }
}
