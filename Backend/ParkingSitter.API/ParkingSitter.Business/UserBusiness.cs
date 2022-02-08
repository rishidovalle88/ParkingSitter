using ParkingSitter.Business.Interfaces;
using ParkingSitter.Database.Repositories.Interfaces;
using ParkingSitter.Domain.Model;

namespace ParkingSitter.Business;

public class UserBusiness : IUsersBusiness
{
    private readonly IBaseRepository<Users> _repository;

    public UserBusiness(IBaseRepository<Users> repository)
    {
        _repository = repository;
    }

    public async Task Delete(int id)
    {
        var generic = await Get(id);
        _repository.Remove(generic);
        await _repository.SaveChanges();
    }

    public async Task<List<Users>> GetAll(int take, int skip)
    {
        return await _repository.GetAll(take, skip);
    }

    public async Task<Users> Get(int id)
    {
        return await _repository.GetById(id);
    }

    public async Task Insert(Users generic)
    {
        await _repository.Insert(generic);
    }

    public async Task Update(Users generic)
    {
        await _repository.Update(generic);
    }
}

