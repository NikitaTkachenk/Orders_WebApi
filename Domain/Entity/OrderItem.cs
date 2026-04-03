namespace Orders_WabApi.Entity;

public class OrderItem
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    
    public Order? Order { get; set; }
}