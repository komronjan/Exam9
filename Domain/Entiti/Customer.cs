using System.ComponentModel.DataAnnotations;

namespace Domain.Entiti;

public class Customer
{
    [Key]
    public int Id { get; set; }
    [MaxLength(50)]
    public string FirstName { get; set; }
    [MaxLength(50)]
    public string LastName { get; set; }
    [MaxLength(255)]
    public string Address { get; set; }
    [MaxLength(20)]
    public string Phone { get; set; }    
    
    [MaxLength(255)]
    public string Email { get; set; }
    public List<Order> Order { get; set; }
    
}
