using Microsoft.EntityFrameworkCore;
using Data.Infrastructure;

namespace AxionTech.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();
        builder.Services.AddSwaggerGen();//Proje için

        #region DbContext Configuration 

        builder.Services.AddDbContext<AxionTechDB>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDatabase"));
        });

        #endregion

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
