using Domain.Dtos;
using Domain.Entiti;
using Infrastructure.Context;

namespace Infrastructure.Service;

public class CustomerService
{
    private readonly DataContext datacontext;

    public CustomerService(DataContext _datacontext)
    {
        datacontext = _datacontext;
    }
    public List<CustomerDto> GetCustomers()
    {
        return datacontext.Customers.Select(x => new CustomerDto()
        {
            Id = x.Id,
            FirstName = x.FirstName,
            LastName = x.LastName,
            Phone = x.Phone,
            Address = x.Address,
            Email = x.Email
        }).ToList();
    }
    public CustomerDto Add(CustomerDto customer)
    {
        var _customer = new Customer()
        {
            Id = customer.Id,

            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Phone = customer.Phone,
            Address = customer.Address,
            Email = customer.Email
        };
        datacontext.Customers.Add(_customer);
        datacontext.SaveChanges();
        return customer;
    }
    public bool Delete(int id)
    {
        var find = datacontext.Customers.Find(id);
        datacontext.Customers.Remove(find);
        datacontext.SaveChanges();
        return true;
    }
    public CustomerDto Update(CustomerDto customer)
    {
        var find = datacontext.Customers.Find(customer.Id);
        find.Address = customer.Address;
        find.Email = customer.Email;
        find.FirstName = customer.FirstName;
        find.LastName = customer.LastName;
        find.Phone = customer.Phone;
        datacontext.SaveChanges();
        return customer;
    }
    public CustomerDto GetById(int id)
    {
        var find = datacontext.Customers.Find(id);
        var _customer = new CustomerDto()
        {
            Id = find.Id,
            FirstName = find.FirstName,
            LastName = find.LastName,
            Email = find.Email,
            Phone = find.Phone,
            Address = find.Address
        };
        return _customer;
    }
}
