using Orders_WabApi.Entity;

namespace Orders_WabApi.DTO.Requests;

public class RequestOnlyUserDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string SecondName { get; set; } = null!;
}