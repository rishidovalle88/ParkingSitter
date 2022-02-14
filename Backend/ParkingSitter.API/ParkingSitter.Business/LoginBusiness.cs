using ParkingSitter.Business.Interfaces;
using ParkingSitter.Database.Repositories.Interfaces;
using ParkingSitter.Domain.Model;

namespace ParkingSitter.Business;
public class LoginBusiness : ILoginBusiness
{
    private readonly ILoginRepository _repository;

    public LoginBusiness(ILoginRepository repository)
    {
        _repository = repository;
    }

    public async Task<Users> Login(string username, string password)
    {
        var ret = await _repository.SignIn(username, password);
        if (ret is not null) ret.Password = "";
        if(!ret.IsActive) return new Users() { IsActive = false};
        return ret;
    }
}
