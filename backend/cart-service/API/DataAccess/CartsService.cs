using API.CoreModels;
using MongoDB.Driver;

namespace API.DataAccess
{
    public class CartsService
    {
        private readonly IMongoCollection<Cart> _cartsCollection;

        public CartsService(
        DatabaseSettings databaseSettings)
        {
            MongoClient mongoClient = new(databaseSettings.ConnectionString);

            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(databaseSettings.DatabaseName);

            _cartsCollection = mongoDatabase.GetCollection<Cart>(databaseSettings.CollectionName);
        }

        public async Task<Cart?> GetAsync(string id)
        {
            return await _cartsCollection.Find(x => x.DomainId == id).FirstOrDefaultAsync();
        }

        public async Task<Cart?> GetByUserIdAsync(string id)
        {
            return await _cartsCollection.Find(x => x.UserId == id).FirstOrDefaultAsync();
        }

        public async Task<Cart> CreateAsync(Cart newCart)
        {
            await _cartsCollection.InsertOneAsync(newCart);

            return newCart;
        }

        public async Task UpdateAsync(string id, Cart updatedBook)
        {
            await _cartsCollection.ReplaceOneAsync(x => x.DomainId == id, updatedBook);
        }

        public async Task RemoveAsync(string id)
        {
            await _cartsCollection.DeleteOneAsync(x => x.DomainId == id);
        }
    }
}
