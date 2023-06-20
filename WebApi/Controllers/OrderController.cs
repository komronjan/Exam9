using Infrastructure.Service;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using Domain.Dtos.Order;
using Domain.Entiti;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class OrderController : ControllerBase
{
    private readonly OrderService service;

    public OrderController(OrderService _service)
    {
        service = _service;
    }
    [HttpGet("Get")]
    public List<GetOrder> Get()
    {
        return service.GetOrders();
    }
    [HttpPost("Create")]
    public Order Create([FromForm] AddOrder order)
    {
        return service.Add(order);
    }
    [HttpGet("GetById")]
    public OrderDto GetById(int id)
    {
        return service.GetById(id);
    }
    [HttpDelete("Delete")]
    public bool Delete(int id)
    {
        return service.Delete(id);
    }
    [HttpPut("Update")]
    public OrderDto Update([FromForm] AddOrder order)
    {
        return service.Update(order);
    }
}
