using ParkingSitter.Domain.Model;

namespace ParkingSitter.Business.Interfaces;
public interface ILoginBusiness
{
    Task<Users> Login(string username, string password);
}