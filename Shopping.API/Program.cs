using Microsoft.Data.SqlClient;
using System.Data;
using Shopping.API.Infrastructure.Data;
using Shopping.API.Infrastructure.Data.Interfaces;
using Shopping.API.Infrastructure.Repositories;
using Shopping.API.Infrastructure.Repositories.Interfaces;
using Shopping.API.Application.Services;
using Shopping.API.Application.Services.Interfaces;
using Shopping.API.Application.Middleware;

var builder = WebApplication.CreateBuilder(args);

ConfigureService(builder);

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

static void ConfigureService(WebApplicationBuilder builder)
{
    builder.Services.AddTransient<IDbConnection>(provider =>
        new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddSingleton<IDbContext, DbContext>();
    builder.Services.AddStackExchangeRedisCache(options =>
    {
        options.Configuration = builder.Configuration.GetConnectionString("Redis");
    });

   // builder.Services.AddScoped<ICacheService, CacheService>();

    builder.Services.AddScoped<ICarrinhoRepository, CarrinhoRepository>();
  

    builder.Services.AddScoped<ICarrinhoService, CarrinhoService>();
}