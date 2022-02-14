using Microsoft.AspNetCore.Mvc;
using ParkingSitter.Business.Interfaces;
using ParkingSitter.API.Services;

namespace ParkingSitter.API.Users;

public static class LoginRoutes
{
    public static void ConfigureLoginRoutes(this WebApplication app)
    {
        app.MapPost("/login", Login);
    }

    private static async Task<IResult> Login(Domain.Model.Users generic, [FromServices] ILoginBusiness i)
    {
        try
        {
            var ret = await i.Login(generic.Username, generic.Password);
            if (ret is null) return Results.NotFound();
            if (ret.IsActive == false) return Results.Unauthorized();
            return Results.Ok(
                new
                {
                    ret,
                    token = new TokenServices().GenerateToken(ret),
                }
                );
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
