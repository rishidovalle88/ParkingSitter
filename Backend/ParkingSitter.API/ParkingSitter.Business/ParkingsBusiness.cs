using ParkingSitter.Business.Interfaces;
using ParkingSitter.Database.Repositories.Interfaces;
using ParkingSitter.Domain.Model;

namespace ParkingSitter.Business;

public class ParkingsBusiness : IParkingsBusiness
{
    private readonly IBaseRepository<Parkings> _repository;

    public ParkingsBusiness(IBaseRepository<Parkings> repository)
    {
        _repository = repository;
    }

    public async Task Delete(int id)
    {
        var generic = await Get(id);
        _repository.Remove(generic);
        await _repository.SaveChanges();
    }

    public async Task<List<Parkings>> GetAll(int take, int skip)
    {
        return await _repository.GetAll(take, skip);
    }

    public async Task<Parkings> Get(int id)
    {
        return await _repository.GetById(id);
    }

    public async Task Insert(Parkings generic)
    {
        await _repository.Insert(generic);
    }

    public async Task Update(Parkings generic)
    {
        await _repository.Update(generic);
    }
}

