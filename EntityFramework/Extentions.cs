using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EntityFramework;

public static class Extentions
{
    public static void AddDataBase(this IServiceCollection servicesCollection)
    {
        servicesCollection.AddDbContext<ApplicationContext>(options =>
        {
            options.UseNpgsql("Host=localhost;Port=5432;Database=orders_db;Username=postgres;Password=Nik2006151984_;");
        });
    }
}