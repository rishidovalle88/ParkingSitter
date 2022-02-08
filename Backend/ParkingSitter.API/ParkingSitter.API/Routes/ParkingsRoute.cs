using Microsoft.AspNetCore.Mvc;
using ParkingSitter.Business.Interfaces;

namespace ParkingSitter.API.Users;

public static class ParkingsRoutes
{
    public static void ConfigureParkingsRoutes(this WebApplication app)
    {
        app.MapGet("/estacionamento", Get);
        app.MapGet("/estacionamento/{id}", GetById);
        app.MapPost("/estacionamento", Insert);
        app.MapPut("/estacionamento", Update);
        app.MapDelete("/estacionamento/{id}", Delete);
    }

    private static async Task<IResult> Get([FromServices] HttpContext httpContext, [FromServices] IParkingsBusiness i)
    {
        try
        {
            int.TryParse(httpContext.Request.Query["take"], out var take);
            int.TryParse(httpContext.Request.Query["skip"], out var skip);
            return Results.Ok(await i.GetAll(take, skip));
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetById(int id, [FromServices] IParkingsBusiness i)
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

    private static async Task<IResult> Insert(Domain.Model.Parkings generic, [FromServices] IParkingsBusiness i)
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

    private static async Task<IResult> Update(Domain.Model.Parkings generic, [FromServices] IParkingsBusiness i)
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

    private static async Task<IResult> Delete(int id, [FromServices] IParkingsBusiness i)
    {
        try
        {
            await i.Delete(id);
            return Results.Ok($"Estacionamento - {id}, foi removido com sucesso na base de dados.");
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
