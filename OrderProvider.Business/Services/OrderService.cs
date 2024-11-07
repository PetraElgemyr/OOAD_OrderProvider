using OrderProvider.Business.Interfaces;
using OrderProvider.Data.Interfaces;
using OrderProvider.Domain.Factories;
using OrderProvider.Domain.Models;

namespace OrderProvider.Business.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository<Order> _orderRepository;

    public OrderService(IOrderRepository<Order> orderRepository)
    {
        _orderRepository = orderRepository;
    }
    public ResponseResultWithData<Order> Create(OrderRequest orderRequest)
    {

        try
        {
            var order = OrderFactory.Create(orderRequest);
            var result = _orderRepository.Create(order);
            if (result.Success)
            {
                return ResponseFactory<Order>.Success(result.Data!);
            }

            return ResponseFactory<Order>.NotFound(result.Data!);
        }
        catch
        {
            return ResponseFactory<Order>.Failed(null!);
        }

    }

    public ResponseResultWithData<IEnumerable<Order>> GetAll()
    {
        try
        {
            return _orderRepository.GetAll();

        }
        catch
        {

            return ResponseFactory<IEnumerable<Order>>.Failed(null!);
        }
    }

    public ResponseResultWithData<Order> GetOne(Func<Order, bool> predicate)
    {
        try
        {
            var result = _orderRepository.GetOne(predicate);
            if (result.Success)
            {
                return ResponseFactory<Order>.Success(result.Data!);
            }
            else
            {
                return ResponseFactory<Order>.NotFound(result.Data!);
            }
        }
        catch
        {
            return ResponseFactory<Order>.Failed(null!);
        }
    }

    public ResponseResultWithData<Order> UpdateOne(Func<Order, bool> predicate, OrderRequest updatedProductRequest)
    {
        var updatedOrder = OrderFactory.Create(updatedProductRequest);
        var result = _orderRepository.UpdateOne(predicate, updatedOrder);

        if (result.Success)
        {
            return ResponseFactory<Order>.Success(result.Data!);
        }

        return ResponseFactory<Order>.Failed(result.Data!);
    }


    public ResponseResult DeleteOne(Func<Order, bool> predicate)
    {
        var result = _orderRepository.DeleteOne(predicate);

        if (result.Success)
        {
            return ResponseFactory<Order>.Success(result.Data!);
        }

        return ResponseFactory<Order>.Failed(result.Data!);
    }

}
