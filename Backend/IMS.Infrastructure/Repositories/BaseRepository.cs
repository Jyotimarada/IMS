using IMS.Application.Repositories;
using IMS.Domain.Entities;
using IMS.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace IMS.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly IMSDbContext _context;

        public BaseRepository(IMSDbContext context)
        {
            _context = context;                
        }
        public async Task Create(T entity)
        {
            entity.DateCreated = DateTime.UtcNow;
            await _context.AddAsync<T>(entity);
        }
        public void Update(T entity)
        {
             entity.DateUpdated = DateTime.UtcNow;
            _context.Update<T>(entity);
        }

        public void Delete(T entity)
        {
            entity.DateDeleted = DateTime.UtcNow;
            _context.Update<T>(entity);
        }

        public async Task<T?> Get(int id, CancellationToken cancellationToken)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public IQueryable<T> GetAll(CancellationToken cancellationToken)
        {
            return _context.Set<T>().AsNoTracking<T>();
        }

    }
}
