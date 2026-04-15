using Microsoft.EntityFrameworkCore;
using Data.Infrastructure;
using Business.Service.Interfaces;
using Business.Service;
using Data.Access.Repositories.Interfaces;
using Data.Access.Repositories;

namespace AxionTech.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        //builder.Services.AddSingleton<ICategoryService, CategoryService>();//tek defa service aç
        //builder.Services.AddTransient<ICategoryService, CategoryService>();//her istekte
        builder.Services.AddScoped<ICategoryService, CategoryService>();//yaþam döngüsü boyunca
        builder.Services.AddScoped<IProductService, ProductService>();
        builder.Services.AddScoped<IUserService, UserService>(); 
        builder.Services.AddScoped<ICustomerService, CustomerService>();
        builder.Services.AddScoped<IRoleService, RoleService>();
        builder.Services.AddScoped<IProductPriceService, ProductPriceService>();
        builder.Services.AddScoped<ICartService, CartService>();
        builder.Services.AddScoped<ICartItemService, CartItemService>();
        builder.Services.AddScoped<IOrderService, OrderService>();
        builder.Services.AddScoped<IOrderItemService, OrderItemService>();
        builder.Services.AddScoped<IProductPictureService, ProductPictureService>();
        builder.Services.AddScoped<IProductDocumentService, ProductDocumentService>();
        builder.Services.AddScoped<IUserRoleService, UserRoleService>();


        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();//yaþam döngüsü boyunca
        builder.Services.AddScoped<IProductRepository, ProductRepository>();//yaþam döngüsü boyunca
        builder.Services.AddScoped<IUserRepository, UserRepository>();//yaþam döngüsü boyunca
        builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
        builder.Services.AddScoped<IRoleRepository, RoleRepository>();
        builder.Services.AddScoped<IProductPictureRepository, ProductPictureRepository>();
        builder.Services.AddScoped<IProductDocumentRepository, ProductDocumentRepository>();
        builder.Services.AddScoped<IProductPriceRepository, ProductPriceRepository>();
        builder.Services.AddScoped<ICartRepository, CartRepository>();
        builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();
        builder.Services.AddScoped<IOrderRepository, OrderRepository>();
        builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
        builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();





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
        app.UseStaticFiles();
        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
