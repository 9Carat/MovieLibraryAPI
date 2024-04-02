using Microsoft.EntityFrameworkCore;
using MovieLibraryAPI.Data;
using MovieLibraryAPI.Models;
using MovieLibraryAPI.Repository.IRepository;
using System.Linq.Expressions;

namespace MovieLibraryAPI.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _db;
        public MovieRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task AddMovieAsync(Movie movie)
        {
            await _db.Movies.AddAsync(movie);
            await SaveAsync();
        }

        public async Task AddRatingAsync(Rating rating)
        {
            await _db.Ratings.AddAsync(rating);
            await SaveAsync();
        }

        public async Task AddStreamingServiceAsync(StreamingService streamingService)
        {
            await _db.StreamingServices.AddAsync(streamingService);
            await SaveAsync();
        }

        public async Task<Movie> GetByMovieIdAsync(Expression<Func<Movie, bool>> filter = null, bool isTracked = true)
        {
            IQueryable<Movie> query = _db.Movies;
            if (!isTracked) query = query.AsNoTracking();
            if (filter != null) query = query.Where(filter);
            return await query
                .Include(r => r.Ratings)
                .Include(s => s.StreamingServices)
                .FirstOrDefaultAsync();
        }
        public async Task<List<Movie>> GetByUserIdAsync(Expression<Func<Movie, bool>> filter = null, bool isTracked = true)
        {
            IQueryable<Movie> query = _db.Movies;
            if (!isTracked) query = query.AsNoTracking();
            if (filter != null) query = query.Where(filter);
            return await query
                .Include(r => r.Ratings)
                .Include(s => s.StreamingServices)
                .Include(u => u.User)
                .ToListAsync();
        }

        public async Task RemoveAsync(Movie movie)
        {
            _db.Remove(movie);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Movie movie)
        {
            _db.Update(movie);
            await SaveAsync();
        }


    }
}
