using System.Linq.Expressions;

namespace MovieLibraryAPI.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
        Task<T> GetByIdAsync(Expression<Func<T, bool>> filter = null, bool isTracked = true);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
        Task<T> UpdatePartial(T entity);
        Task SaveAync();
    }
}
