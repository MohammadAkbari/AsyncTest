namespace WebApplication1.MongoDb
{
    public class ItemRepository
    {
        private readonly MongoContext _dbContext = null;

        public ItemRepository()
        {
            _dbContext = new MongoContext();
        }

        public void Add(Item item)
        {
            _dbContext.Items.InsertOne(item);
        }
    }
}
