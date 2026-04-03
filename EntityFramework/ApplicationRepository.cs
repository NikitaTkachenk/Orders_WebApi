using Microsoft.EntityFrameworkCore;
using Orders_WabApi.DTO.Requests;
using Orders_WabApi.Entity;

namespace EntityFramework;

public class ApplicationRepository(ApplicationContext context)
{
    public async Task<User> GetUserByIdAsync(int id)
    {
        var user = await context.User.Where(u => u.Id == id)
                                     .FirstOrDefaultAsync();
        return user;
    }
    
    public async Task<RequestUserDTO> GetUserByIdWithOrdersAsync(int id)
    {
        if (id <= 0)
            return null;
        
        var user = await context.User.Include(u => u.Orders)
                                     .ThenInclude(u => u.OrderItem)
                                     .AsNoTracking()
                                     .Where(u => u.Id == id)
                                     .FirstOrDefaultAsync();

        var userDto = new RequestUserDTO
        {
            Id = user.Id,
            Name = user.Name,
            SecondName = user.SecondName,
            Orders = user.Orders.Select(o => new RequestOrderDTO
            {
                Id = o.Id, UserId = o.UserId, Name = o.Name, Description = o.Description, OrderDate = o.OrderDate,
                OrderItem = o.OrderItem == null
                    ? null
                    : new RequestOrderItemDTO
                    {
                        Id = o.OrderItem.Id, Name = o.OrderItem.Name, Description = o.OrderItem.Description,
                        OrderId = o.OrderItem.OrderId, Price = o.OrderItem.Price
                    }
            }).ToList()
        };

        return userDto;
    }
    
    public async Task<User> AddOnlyUserAsync(string userName, string secondName)
    {   
        var user = new User
        {
            Name = userName
            , SecondName = secondName
        };

        await context.AddAsync(user);
        await context.SaveChangesAsync();

        return user;

    }
    
    public async Task<User> AddUserAsync(string userName, string secondName, string orderName
        , string orderDescription, string orderItemName, string orderItemDescription, decimal orderItemPrice)
    {   
        var user = new User
        {
            Name = userName
            , SecondName = secondName
            , Orders = new List<Order>
            {
                new Order
                {
                    Name = orderName
                    , Description = orderDescription
                    , OrderDate =  DateTime.Now
                    ,OrderItem = new OrderItem()
                    {
                        Name = orderItemName
                        ,Description = orderItemDescription
                        , Price = orderItemPrice
                    }
                }
            }
        };
        
        await context.AddAsync(user);
        await context.SaveChangesAsync();
        return user;
    }

    public async Task<List<RequestUserDTO>> GetAllUsersWithOrdersAsync()
    {
        var users = await context.User.Include(u => u.Orders)
            .ThenInclude(o => o.OrderItem).AsNoTracking().ToListAsync();;
        // Eager loading - Для загрузки связывающих елементов.
        return users.Select(u => new RequestUserDTO
        {
            Id = u.Id,
            Name = u.Name,
            SecondName = u.SecondName,
            Orders = u.Orders.Select(o => new RequestOrderDTO
            {
                Id = o.Id, UserId = o.UserId, Name = o.Name, Description = o.Description, OrderDate = o.OrderDate,
                OrderItem = o.OrderItem == null ? null : new RequestOrderItemDTO
                {
                    Id = o.OrderItem.Id, OrderId = o.OrderItem.OrderId, Name = o.OrderItem.Name,
                    Description = o.OrderItem.Description, Price = o.OrderItem.Price
                }
            }).ToList()
        }).ToList();
    }
    
}