using Orders_WabApi.Entity;

namespace Orders_WabApi.DTO.Requests;

public class RequestUserDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string SecondName { get; set; } = null!;
    public List<RequestOrderDTO> Orders { get; set; } = new();
}