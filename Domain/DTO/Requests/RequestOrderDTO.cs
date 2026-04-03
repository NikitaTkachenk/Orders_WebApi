using Orders_WabApi.Entity;

namespace Orders_WabApi.DTO.Requests;

public class RequestOrderDTO
{
    public int Id { get; set; }
    public int UserId { get; set; } 
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime OrderDate { get; set; }
    public RequestOrderItemDTO OrderItem { get; set; } = new();
}

