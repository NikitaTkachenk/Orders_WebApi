namespace Orders_WabApi.DTO.Requests;

public class CreateOrderItemDTO
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
}