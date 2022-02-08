using ParkingSitter.Domain.Model;

namespace ParkingSitter.Business.Interfaces;
public interface ITransactionsBusiness
{
    Task Delete(int id);
    Task<Transactions> Get(int id);
    Task<List<Transactions>> GetAll(int take, int skip);
    Task Insert(Transactions generic);
    Task Update(Transactions generic);
}