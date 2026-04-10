namespace Orders_WabApi.DTO.Requests;

public class CreateOrderDTO
{
    public int UserId { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public CreateOrderItemDTO OrderItem { get; set; } = new();
}