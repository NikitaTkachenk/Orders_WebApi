using System.ComponentModel.DataAnnotations;

namespace Orders_WabApi.Entity;

public class User
{
    public int Id { get; set; }
    
    [ConcurrencyCheck] // Потрібен для того, щоб при коригуванні, видаленні інформації не можна було змінити ці поля! видасть Ексцепшн!
    public string Name { get; set; } = null!;
    [ConcurrencyCheck]
    public string SecondName { get; set; } = null!;
    
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}