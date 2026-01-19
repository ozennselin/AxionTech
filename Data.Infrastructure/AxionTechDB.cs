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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Product>();//Product entity sini model e eklemiş olduk. Bu haliyle bütün tablolar için yapılabilir.Ama bunun yerine configuration class ları kullanacağız. Bu Configuration Class'ları hangi EF Interface lerinden implement edildiyse onları arayıp bulur ve model e ekler.

            //Add configurations from the current assembly
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

       
    }
}
