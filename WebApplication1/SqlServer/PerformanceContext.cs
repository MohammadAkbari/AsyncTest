using Microsoft.EntityFrameworkCore;

namespace WebApplication1.SqlServer
{
    public partial class PerformanceContext : DbContext
    {
        public virtual DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=PerformanceDb;Integrated Security=True");
            }
        }
    }
}