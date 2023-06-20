using Infrastructure.Service;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class CustomerController : ControllerBase
{
    private readonly CustomerService service;

    public CustomerController(CustomerService _service)
    {
        service = _service;
    }
    [HttpGet("Get")]
    public List<CustomerDto> Get()
    {
        return service.GetCustomers();
    }
    [HttpPost("Create")]
    public CustomerDto Create([FromForm]CustomerDto customer)
    {
        return service.Add(customer);
    }
    [HttpGet("GetById")]
    public CustomerDto GetById(int id)
    {
        return service.GetById(id);
    }
    [HttpDelete("Delete")]
    public bool Delete(int id)
    {
        return service.Delete(id);
    }
    [HttpPut("Update")]
    public CustomerDto Update([FromForm]CustomerDto customer)
    {
        return service.Update(customer);
    }
}
