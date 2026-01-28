
using DesafioToLife.Domain.Intrerfaces;
using DesafioToLife.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DesafioToLife.Infrastructure.Repositories
{

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync(int page, int pageSize)
        {
            return await _dbSet.AsNoTracking()
                               .Skip((page - 1) * pageSize)
                               .Take(pageSize)
                               .ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

        public void Update(T entity) => _dbSet.Update(entity);

        public void Delete(T entity) => _dbSet.Remove(entity);
    }
}
