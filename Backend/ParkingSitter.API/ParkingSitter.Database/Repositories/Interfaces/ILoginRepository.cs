using ParkingSitter.Domain.Model;

namespace ParkingSitter.Database.Repositories.Interfaces;

public interface ILoginRepository
{
    Task<Users> SignIn(string username, string password);
}