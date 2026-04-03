using Orders_WabApi.Entity;

namespace Orders_WabApi.DTO.Requests;

public class RequestOrderItemDTO
{
    public int Id { get; set; }               
    public int OrderId { get; set; }         
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
}