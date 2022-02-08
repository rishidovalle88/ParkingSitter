using ParkingSitter.Domain.Model;

namespace ParkingSitter.Business.Interfaces;

public interface IUsersBusiness
{
    Task Delete(int id);
    Task<Users> Get(int id);
    Task<List<Users>> GetAll(int take, int skip);
    Task Insert(Users generic);
    Task Update(Users generic);
}
