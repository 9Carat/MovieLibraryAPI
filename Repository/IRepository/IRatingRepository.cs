using MovieLibraryAPI.Models;
using System.Linq.Expressions;

namespace MovieLibraryAPI.Repository.IRepository
{
    public interface IRatingRepository
    {
        Task<List<Rating>> GetAllAsync(Expression<Func<Rating, bool>> filter = null);
        Task<Rating> GetByIdAsync(Expression<Func<Rating, bool>> filter = null, bool isTracked = true);
        Task CreateAsync(Rating rating);
        Task UpdateAsync(Rating rating);
        Task RemoveAsync(Rating rating);
        Task SaveAsync();
    }
}
