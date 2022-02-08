using Microsoft.EntityFrameworkCore;
using ParkingSitter.Database.Context;
using ParkingSitter.Database.Repositories.Interfaces;
using ParkingSitter.Domain.Model;

namespace ParkingSitter.Database.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _applicationDbContext;
        private DbSet<T> entities;

        public BaseRepository(AppDbContext appDbContext)
        {
            _applicationDbContext = appDbContext;
            entities = _applicationDbContext.Set<T>();
        }

        public async Task Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<T> GetById(int id) => await entities.SingleOrDefaultAsync(c => c.Id == id);

        public async Task<List<T>> GetAll(int take, int skip)
        {
            return await entities.Take(take).Skip(skip).ToListAsync();
        }

        public async Task Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            await _applicationDbContext.SaveChangesAsync();
        }

        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
        }

        public async Task SaveChanges()
        {
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
