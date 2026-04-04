using EntityFramework;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Orders_WabApi.DTO.Requests;
using Orders_WabApi.DTO.Response;
using Orders_WabApi.Entity;

namespace Orders_WabApi.Controllers;

[ApiController]
[Route("users")]
public class OrderController : Controller
{
    private readonly UserRepository _userRepository;
    
    public OrderController(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsersWithOrders()
    {
        var users = await _userRepository.GetAllUsersWithOrdersAsync();
        return Ok(users);
    }

    [HttpGet("byid")]
    public async Task<IActionResult> GetUserById([FromQuery]int id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);
        return Ok(user);
    }

    [HttpGet("byidwithorders")]
    public async Task<IActionResult> GetUserByIdWithOrders([FromQuery] int id)
    {
        var user = await _userRepository.GetUserByIdWithOrdersAsync(id);
        if(user == null)
            return BadRequest();
        
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> AddUser(RequestOnlyUserDTO user)
    {
        var newUser = await _userRepository.AddOnlyUserAsync(user.Name, user.SecondName);
        return Ok(newUser);
    }

    [HttpPost("addAll")]
    public async Task<IActionResult> AddUserWithOrders(RequestUserDTO userDto)
    {
        var user = await _userRepository.AddUserAsync(userDto);
        return Ok(user);
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