using System.Text.Json.Serialization;

namespace Orders_WabApi.Entity;

public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime OrderDate { get; set; }
    
    public User? User { get; set; }
    public OrderItem OrderItem { get; set; }
}