using System;

namespace WebApplication1.SqlServer
{
    public class ItemRepository : IDisposable
    {
        private readonly PerformanceContext _dbContext = null;

        public ItemRepository()
        {
            _dbContext = new PerformanceContext();
        }

        public void Add(Item item)
        {
            _dbContext.Items.Add(item);
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
