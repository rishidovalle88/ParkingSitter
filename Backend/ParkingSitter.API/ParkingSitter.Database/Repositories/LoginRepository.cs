using Microsoft.EntityFrameworkCore;
using ParkingSitter.Database.Context;
using ParkingSitter.Database.Repositories.Interfaces;
using ParkingSitter.Domain.Model;

namespace ParkingSitter.Database.Repositories;
public class LoginRepository : ILoginRepository
{
    private readonly AppDbContext _applicationDbContext;
    public LoginRepository(AppDbContext appDbContext)
    {
        _applicationDbContext = appDbContext;
    }

    public async Task<Users> SignIn(string username, string password)
    {
        var ret = await _applicationDbContext.Users.FirstOrDefaultAsync(o => o.Username.Equals(username) && o.Password.Equals(password));
        return ret;
    }
}
