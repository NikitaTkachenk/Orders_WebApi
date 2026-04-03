using EntityFramework;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Orders_WabApi.DTO.Requests;
using Orders_WabApi.DTO.Response;
using Orders_WabApi.Entity;

namespace Orders_WabApi.Controllers;

[ApiController]
[Route("orders")]
public class OrderController : Controller
{
    private readonly ApplicationRepository _applicationRepository;
    
    public OrderController(ApplicationRepository applicationRepository)
    {
        _applicationRepository = applicationRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsersWithOrders()
    {
        var users = await _applicationRepository.GetAllUsersWithOrdersAsync();
        return Ok(users);
    }

    [HttpGet("byid")]
    public async Task<IActionResult> GetUserById([FromQuery]int id)
    {
        var user = await _applicationRepository.GetUserByIdAsync(id);
        return Ok(user);
    }

    [HttpGet("byidwithorders")]
    public async Task<IActionResult> GetUserByIdWithOrders([FromQuery] int id)
    {
        var user = await _applicationRepository.GetUserByIdWithOrdersAsync(id);
        if(user == null)
            return BadRequest();
        
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> AddUser(RequestOnlyUserDTO user)
    {
        var newUser = await _applicationRepository.AddOnlyUserAsync(user.Name, user.SecondName);
        return Ok(newUser);
    }
    
    

    /*[HttpGet("id")]
    public IActionResult GetOrderById([FromQuery]int orderId)
    {
        if(DataBase.orders is null)
            return BadRequest();
        
        var order = DataBase.orders.FirstOrDefault(o => o.Id == orderId);
        return Ok(order);
    }

    [HttpGet("date")]
    public IActionResult GetOrderByDate([FromQuery]DateTime date)
    {
        if(DataBase.orders is null)
            return BadRequest();
        
        var order = DataBase.orders.FirstOrDefault(o => o.OrderDate == date);
        return Ok(order);
    }
    
    [HttpPost]
    public IActionResult CreateOrder([FromBody] CreateOrderRequest request)
    {
        validator.ValidateAndThrow(request);
        
        if(DataBase.orders is null)
            return BadRequest();
        
        var order = new Order
        {
            Id = DataBase.orders.Count + 1,
            Name = request.Name,
            Description = request.Description,
            OrderDate = DateTime.Now,
        };
        
        DataBase.orders.Add(order);
        
        return Ok(order);
    }*/
}