using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebEcommerce.Base
{
    public interface IBaseEntityRepository<T> where T : class,IBaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task CreatAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task SaveChanges();
    }
}
