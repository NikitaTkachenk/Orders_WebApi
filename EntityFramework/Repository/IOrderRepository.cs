using Application.Filters;
using Orders_WabApi.DTO.Requests;
using Orders_WabApi.Entity;

namespace EntityFramework.Repository;

public interface IOrderRepository
{
    Task<List<Order>> GetAll(OrderFilter orderFilter);
    Task<Order> GetById(int id);
    Task Insert(CreateOrderDTO order);
    Task Update(Order order);
    Task Delete(int id);
    Task Save();

}