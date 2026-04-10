using Application.Filters;
using EntityFramework.Repository;
using Microsoft.EntityFrameworkCore;
using Orders_WabApi.Entity;

namespace EntityFramework.Repository;

public class OrderRepository(ApplicationContext context) : IOrderRepository
{
    public Task<List<Order>> GetAll(OrderFilter orderFilter)
    {
        var orders = context.Orders.FilterByName(orderFilter)
                                                 .AsNoTracking()
                                                 .FilterFromDateTo(orderFilter)
                                                 .ToListAsync();
        return orders;
    }

    public Task<Order> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Insert(Order order)
    {
        throw new NotImplementedException();
    }

    public Task Update(Order order)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task Save()
    {
        throw new NotImplementedException();
    }
}