using MovieLibraryAPI.Models;
using System.Linq.Expressions;

namespace MovieLibraryAPI.Repository.IRepository
{
    public interface IMovieRepository
    {
        Task<Movie> GetByMovieIdAsync(Expression<Func<Movie, bool>> filter = null, bool isTracked = true);
        Task<List<Movie>> GetByUserIdAsync(Expression<Func<Movie, bool>> filter = null, bool isTracked = true);
        Task AddMovieAsync(Movie movie);
        Task AddRatingAsync(Rating rating);
        Task AddStreamingServiceAsync(StreamingService streamingService);
        Task UpdateAsync(Movie movie);
        Task RemoveAsync(Movie movie);
        Task SaveAsync();
    }
}
