using Domain.Dtos.Order;
using Domain.Dtos;
using Domain.Entiti;
using Infrastructure.Context;

namespace Infrastructure.Service;

public class OrderService
{
    private readonly DataContext datacontext;

    public OrderService(DataContext _datacontext)
    {
        datacontext = _datacontext;
    }
    public List<GetOrder> GetOrders()
    {
        return datacontext.Orders.Select(x => new GetOrder()
        {
            Id = x.Id,
            CustomerId = x.CustomerId,
            CustomerName = x.Customer.FirstName,
            OrderFullFilled = x.OrderFullFilled,
            OrderPlaced = x.OrderPlaced
        }).ToList();
    }
    public Order Add(AddOrder order)
    {
        order.OrderFullFilled = DateTime.SpecifyKind(order.OrderFullFilled, DateTimeKind.Utc);
        order.OrderPlaced = DateTime.SpecifyKind(order.OrderPlaced, DateTimeKind.Utc);
        var _order = new Order()
        {
            Id = order.Id,
            OrderFullFilled = order.OrderFullFilled,
            OrderPlaced = order.OrderPlaced,
            CustomerId = order.CustomerId,

        };
        var getOrder = new GetOrder()
        {
            Id = order.Id,
            OrderFullFilled = order.OrderFullFilled,
            OrderPlaced = order.OrderPlaced,
            CustomerId = order.CustomerId,
        };
        datacontext.Orders.Add(_order);
        datacontext.SaveChanges();
        return _order;
    }
    public bool Delete(int id)
    {
        var find = datacontext.Orders.Find(id);
        datacontext.Orders.Remove(find);
        datacontext.SaveChanges();
        return true;
    }
    public OrderDto Update(AddOrder order)
    {
        order.OrderFullFilled = DateTime.SpecifyKind(order.OrderFullFilled, DateTimeKind.Utc);
        order.OrderPlaced = DateTime.SpecifyKind(order.OrderPlaced, DateTimeKind.Utc);
        var find = datacontext.Orders.Find(order.Id);
        find.CustomerId = order.CustomerId;
        find.OrderFullFilled = order.OrderFullFilled;
        find.OrderPlaced = order.OrderPlaced;
        datacontext.SaveChanges();
        return order;
    }
    public GetOrder GetById(int id)
    {
        var find = datacontext.Orders.Find(id);
        var order = new GetOrder()
        {
            CustomerId = find.CustomerId,
            CustomerName = find.Customer.FirstName,
            OrderFullFilled = find.OrderFullFilled,
            OrderPlaced = find.OrderPlaced
        };
        return order;
    }
}

