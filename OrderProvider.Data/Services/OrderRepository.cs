using OrderProvider.Data.Interfaces;

namespace OrderProvider.Data.Services;

public class OrderRepository<T> : BaseRepository<T>, IOrderRepository<T>    
{
}
