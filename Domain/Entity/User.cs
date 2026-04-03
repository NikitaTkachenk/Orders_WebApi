namespace Orders_WabApi.Entity;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string SecondName { get; set; } = null!;
    
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}