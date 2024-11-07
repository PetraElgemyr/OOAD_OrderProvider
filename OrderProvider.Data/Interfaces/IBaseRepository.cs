using OrderProvider.Domain.Models;

namespace OrderProvider.Data.Interfaces;

public interface IBaseRepository<T>
{
    ResponseResultWithData<T> Create(T entity);
    ResponseResultWithData<IEnumerable<T>> GetAll();
    ResponseResultWithData<T> GetOne(Func<T, bool> predicate);
    ResponseResultWithData<T> UpdateOne(Func<T, bool> predicate, T updatedOrder);
    ResponseResultWithData<T> DeleteOne(Func<T, bool> predicate);
}
