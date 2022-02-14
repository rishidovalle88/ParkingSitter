using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ParkingSitter.API.Users;
using ParkingSitter.Business;
using ParkingSitter.Business.Interfaces;
using ParkingSitter.Database.Context;
using ParkingSitter.Database.Repositories;
using ParkingSitter.Database.Repositories.Interfaces;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding .UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
builder.Services.AddAuthorization();

var connectionString = builder.Configuration.GetConnectionString("SqlConnectionString");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});

builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped(typeof(ILoginRepository), typeof(LoginRepository));
builder.Services.AddTransient<IUsersBusiness, UserBusiness>();
builder.Services.AddTransient<IParkingsBusiness, ParkingsBusiness>();
builder.Services.AddTransient<ITransactionsBusiness, TransactionsBusiness>();
builder.Services.AddTransient<ITransactionsBusiness, TransactionsBusiness>();
builder.Services.AddTransient<ILoginBusiness, LoginBusiness>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseAuthentication();

app.UseHttpsRedirection();
app.ConfigureLoginRoutes();
app.ConfigureUsersRoutes();
app.ConfigureParkingsRoutes();
app.ConfigureTransactionsRoutes();

app.Run();