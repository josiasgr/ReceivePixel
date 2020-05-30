using System.Collections.Generic;
using System.Threading.Tasks;

namespace receivePixel.Services
{
    public interface IStorageService<T>
    {
        Task<IEnumerable<T>> ReadTopAsync(int top, string orderBy, OrderByDirection ascendingOrDescending);

        Task SaveAsync(T data);
    }
}