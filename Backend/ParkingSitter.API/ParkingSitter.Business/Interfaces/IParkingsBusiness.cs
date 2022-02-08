using ParkingSitter.Domain.Model;

namespace ParkingSitter.Business.Interfaces;

public interface IParkingsBusiness
{
    Task Delete(int id);
    Task<Parkings> Get(int id);
    Task<List<Parkings>> GetAll(int take, int skip);
    Task Insert(Parkings generic);
    Task Update(Parkings generic);
}
