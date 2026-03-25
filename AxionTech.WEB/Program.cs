using AxionTech.WEB.GetApi;
using System.Net;

namespace AxionTech.WEB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddHttpClient();

            builder.Services.AddHttpClient<ProductApi>(k =>
            {
                k.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
            });
            builder.Services.AddHttpClient<CategoryApi>(k =>
            {
                k.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
            });
            builder.Services.AddHttpClient<CustomerApi>(k =>
            {
                k.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
            });
            builder.Services.AddHttpClient<RoleApi>(c =>
            {
                c.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
            });
            builder.Services.AddHttpClient<UserApi>(c =>
            {
                c.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
            });
            builder.Services.AddHttpClient<ProductPriceApi>(c =>
            {
                c.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
            });
            builder.Services.AddHttpClient<ProductDocumentApi>(c =>
            {
                c.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
            });
            builder.Services.AddHttpClient<ProductPictureApi>(c =>
            {
                c.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
            });
            builder.Services.AddHttpClient<CartApi>(c =>
            {
                c.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
            });
            builder.Services.AddHttpClient<OrderApi>(c =>
            {
                c.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
            });
            builder.Services.AddHttpClient<CartItemApi>(c =>
            {
                c.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapAreaControllerRoute(
            name: "Areas",
            areaName: "AdminPanel",
            pattern: "AdminPanel/{controller=ProductAP}/{action=List}/{id?}"
          );

            app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();


            app.Run();
        }
    }
}
