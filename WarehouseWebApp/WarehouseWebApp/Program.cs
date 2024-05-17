

using WarehouseWebApp.Models;
using WarehouseWebApp.Repository;
using WarehouseWebApp.Services;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddScoped<IWarehouseService, WarehouseService>();
        builder.Services.AddScoped<IRepository, SQLRepository>();
        builder.Services.AddTransient<IProductWarehouseBuilder, ProductWarehouseBuilder>();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();
        
        var app = builder.Build();
        app.UseHttpsRedirection();
        app.MapControllers();
        app.UseSwagger();
        app.UseSwaggerUI();
        
        app.Run();
    }
}