using ParkingSitter.Database.Repositories.Interfaces;
using ParkingSitter.Domain.Model;

namespace ParkingSitter.Business.Interfaces;

public class TransactionsBusiness : ITransactionsBusiness
{
    private readonly IBaseRepository<Transactions> _repository;

    public TransactionsBusiness(IBaseRepository<Transactions> repository)
    {
        _repository = repository;
    }

    public async Task Delete(int id)
    {
        var generic = await Get(id);
        _repository.Remove(generic);
        await _repository.SaveChanges();
    }

    public async Task<List<Transactions>> GetAll(int take, int skip)
    {
        return await _repository.GetAll(take, skip);
    }

    public async Task<Transactions> Get(int id)
    {
        return await _repository.GetById(id);
    }

    public async Task Insert(Transactions generic)
    {
        await _repository.Insert(generic);
    }

    public async Task Update(Transactions generic)
    {
        await _repository.Update(generic);
    }
}

