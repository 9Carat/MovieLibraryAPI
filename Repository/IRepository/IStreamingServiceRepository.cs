using MovieLibraryAPI.Models;
using System.Linq.Expressions;

namespace MovieLibraryAPI.Repository.IRepository
{
    public interface IStreamingServiceRepository
    {
        Task<List<StreamingService>> GetAllAsync(Expression<Func<StreamingService, bool>> filter = null);
        Task<StreamingService> GetByIdAsync(Expression<Func<StreamingService, bool>> filter = null, bool isTracked = true);
        Task CreateAsync(StreamingService streamingService);
        Task UpdateAsync(StreamingService streamingService);
        Task RemoveAsync(StreamingService streamingService);
        Task SaveAsync();
    }
}
