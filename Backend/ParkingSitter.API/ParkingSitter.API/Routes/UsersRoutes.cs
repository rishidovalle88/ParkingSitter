using Microsoft.AspNetCore.Mvc;
using ParkingSitter.Business.Interfaces;

namespace ParkingSitter.API.Users;

public static class UsersRoutes
{
    public static void ConfigureUsersRoutes(this WebApplication app)
    {
        app.MapGet("/usuario", Get).AllowAnonymous();
        app.MapGet("/usuario/{id}", GetById);
        app.MapPost("/usuario", Insert);
        app.MapPut("/usuario", Update);
        app.MapDelete("/usuario/{id}", Delete);
    }

    private static async Task<IResult> Get(
            [FromServices] IUsersBusiness i,
            [FromQuery(Name = "take")] int take = 10,
            [FromQuery(Name = "skip")] int skip = 1)
    {
        try
        {
            return Results.Ok(await i.GetAll(take, skip));
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetById(int id, [FromServices] IUsersBusiness i)
    {
        try
        {
            var generic = await i.Get(id);
            return generic is null ? Results.NotFound() : Results.Ok(generic);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> Insert(Domain.Model.Users generic, [FromServices] IUsersBusiness i)
    {
        try
        {
            await i.Insert(generic);
            return Results.Created($"/customers/{generic.Id}", generic);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> Update(Domain.Model.Users generic, [FromServices] IUsersBusiness i)
    {
        try
        {
            await i.Update(generic);
            return Results.Ok(generic);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> Delete(int id, [FromServices] IUsersBusiness i)
    {
        try
        {
            await i.Delete(id);
            return Results.Ok($"Usuário - {id}, foi removido com sucesso na base de dados.");
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
