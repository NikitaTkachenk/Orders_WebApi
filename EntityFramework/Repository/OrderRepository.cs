using Application.Filters;
using EntityFramework.Repository;
using Microsoft.EntityFrameworkCore;
using Orders_WabApi.DTO.Requests;
using Orders_WabApi.Entity;

namespace EntityFramework.Repository;

public class OrderRepository(ApplicationContext context) : IOrderRepository
{
    public async Task<List<Order>> GetAll(OrderFilter orderFilter)
    {
        var _orders = await context.Orders.FilterByName(orderFilter)
                                                 .AsNoTracking()
                                                 .FilterFromDateTo(orderFilter)
                                                 .ToListAsync();
        return _orders;
    }

    public async Task<Order> GetById(int id)
    {
        var _order = await context.Orders.AsNoTracking()
                                         .FirstOrDefaultAsync(o => o.Id == id);
        return _order;
    }

    public async Task Insert(CreateOrderDTO order)
    {
        var _order = new Order
        {
            UserId = order.UserId,
            Name = order.Name,
            Description = order.Description,
            OrderDate =  DateTime.UtcNow,
            OrderItem = new OrderItem
            {
                Name = order.OrderItem.Name,
                Description = order.OrderItem.Description,
                Price = order.OrderItem.Price,
            }
        };
        
        context.Orders.Add(_order);
        await context.SaveChangesAsync();
    }

    public async Task Update(Order order)
    {
        var _orders = await context.Orders.FirstOrDefaultAsync(o => o.Id == order.Id);

        if (_orders is null)
            return;
        
        _orders.Name = order.Name;
        _orders.Description = order.Description;
    }

    public Task Delete(int id)
    {
         var order = context.Orders.Remove(context.Orders .FirstOrDefault(o => o.Id == id));
         return Task.CompletedTask;
    }

    public async Task Save()
    {
        await context.SaveChangesAsync();
    }
}