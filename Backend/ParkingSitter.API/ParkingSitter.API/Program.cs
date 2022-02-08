using Microsoft.EntityFrameworkCore;
using ParkingSitter.API.Users;
using ParkingSitter.Business;
using ParkingSitter.Business.Interfaces;
using ParkingSitter.Database.Context;
using ParkingSitter.Database.Repositories;
using ParkingSitter.Database.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("SqlConnectionString");

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
//builder.Services.AddTransient<IUsersBusiness, UserBusiness>();
//builder.Services.AddTransient<IParkingsBusiness, ParkingsBusiness>();
builder.Services.AddTransient<ITransactionsBusiness, TransactionsBusiness>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.ConfigureUsersRoutes();
app.ConfigureParkingsRoutes();
app.ConfigureTransactionsRoutes();

app.Run();