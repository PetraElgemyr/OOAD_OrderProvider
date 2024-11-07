using OrderProvider.Domain.Models;

namespace OrderProvider.Business.Interfaces;

public interface IOrderService
{
    public ResponseResultWithData<Order> Create(OrderRequest orderRequest);
    public ResponseResultWithData<IEnumerable<Order>> GetAll();
    public ResponseResultWithData<Order> GetOne(Func<Order, bool> predicate);
    public ResponseResultWithData<Order> UpdateOne(Func<Order, bool> predicate, OrderRequest updatedProductRequest);
    public ResponseResult DeleteOne(Func<Order, bool> predicate);
}
