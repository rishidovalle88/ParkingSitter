using Microsoft.AspNetCore.Mvc;
using ParkingSitter.Business.Interfaces;

namespace ParkingSitter.API.Users;

public static class TransactionsRoute
{    
    public static void ConfigureTransactionsRoutes(this WebApplication app)
    {
        app.MapGet("/transacao", Get);
        app.MapGet("/transacao/{id}", GetById);
        app.MapPost("/transacao", Insert);
        app.MapPut("/transacao", Update);
        app.MapDelete("/transacao/{id}", Delete);
    }

    private static async Task<IResult> Get(
        [FromQuery(Name = "take")] int take,
        [FromQuery(Name = "skip")] int skip,
        [FromServices] ITransactionsBusiness i)
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

    private static async Task<IResult> GetById(int id, [FromServices] ITransactionsBusiness i)
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

    private static async Task<IResult> Insert(Domain.Model.Transactions generic, [FromServices] ITransactionsBusiness i)
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

    private static async Task<IResult> Update(Domain.Model.Transactions generic, [FromServices] ITransactionsBusiness i)
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

    private static async Task<IResult> Delete(int id, [FromServices] ITransactionsBusiness i)
    {
        try
        {
            await i.Delete(id);
            return Results.Ok($"Transação - {id}, foi removido com sucesso na base de dados.");
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
