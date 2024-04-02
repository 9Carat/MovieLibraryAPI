using Microsoft.EntityFrameworkCore;
using MovieLibraryAPI.Data;
using MovieLibraryAPI.Repository.IRepository;
using System.Linq.Expressions;

namespace MovieLibraryAPI.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        public GenericRepository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            await _db.AddAsync(entity);
            await SaveAync();
        }

        public async Task RemoveAsync(T entity)
        {
            _db.Remove(entity);
            await SaveAync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null) query = query.Where(filter);
            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> filter = null, bool isTracked = true)
        {
            IQueryable<T> query = dbSet;
            if (isTracked) query = query.AsNoTracking();
            if (filter != null) query = query.Where(filter);
            return await query.FirstOrDefaultAsync();
        }

        public async Task SaveAync()
        {
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _db.Update(entity);
            await SaveAync();
        }

        public async Task<T> UpdatePartial(T entity)
        {
            _db.Update(entity);
            await SaveAync();
            return entity;
        }
    }
}
