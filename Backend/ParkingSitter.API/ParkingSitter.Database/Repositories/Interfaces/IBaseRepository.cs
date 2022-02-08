using ParkingSitter.Domain.Model;

namespace ParkingSitter.Database.Repositories.Interfaces;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<List<T>> GetAll(int take, int skip);
    Task<T> GetById(int id);
    Task Insert(T entity);
    Task Update(T entity);
    Task Delete(T entity);
    void Remove(T entity);
    Task SaveChanges();

}
