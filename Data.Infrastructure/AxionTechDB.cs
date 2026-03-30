using Data.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Data.Infrastructure
{
    public class AxionTechDB:DbContext
    {

        public AxionTechDB(DbContextOptions<AxionTechDB> options) : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartItem> CartItem { get; set; }
        public DbSet<ProductPicture> ProductPicture { get; set; }
        public DbSet<ProductDocument> ProductDocument { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerType> CustomerType { get; set; }
        public DbSet<ProductPrice> ProductPrice { get; set; }//ProductId=10,active=true  price getir




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Product>();//Product entity sini model e eklemiş olduk. Bu haliyle bütün tablolar için yapılabilir.Ama bunun yerine configuration class ları kullanacağız. Bu Configuration Class'ları hangi EF Interface lerinden implement edildiyse onları arayıp bulur ve model e ekler.

            //Add configurations from the current assembly
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<ProductPicture>().ToTable(k => k.HasTrigger("tgr_Create"));//ProductPicture tablosuna tgr_Create adında bir trigger ekledik. Bu trigger, ProductPicture tablosuna yeni bir kayıt eklendiğinde çalışacak ve belirli işlemleri gerçekleştirecektir. Trigger'lar, veritabanı düzeyinde otomatik olarak tetiklenen özel prosedürlerdir ve genellikle veri bütünlüğünü sağlamak veya belirli iş kurallarını uygulamak için kullanılır.
            base.OnModelCreating(modelBuilder);
        }

       
    }
}
