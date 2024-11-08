using OrderProvider.Domain.Models;

namespace OrderProvider.Business.Interfaces;

public interface IOrderValidator 
{
    public OrderValidatorResult Validate(OrderRequest orderRequest);
}
