using Application.Filters;
using Orders_WabApi.Entity;

namespace EntityFramework.Repository;

public interface IOrderRepository
{
    Task<List<Order>> GetAll(OrderFilter orderFilter);
    Task<Order> GetById(int id);
    Task Insert(Order order);
    Task Update(Order order);
    Task Delete(int id);
    Task Save();

}