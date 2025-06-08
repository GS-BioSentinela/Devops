using Microsoft.EntityFrameworkCore;
using NET___BioSentinela.Infrastructure.Context;

namespace NET___BioSentinela.Infrastructure.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly BioContext _context;
        private readonly DbSet<T> _dbSet;



        public Repository(BioContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAssync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Update(T entity)
        {
            _dbSet.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
