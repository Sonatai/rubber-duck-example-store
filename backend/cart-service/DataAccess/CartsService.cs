using Core;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DataAccess
{
    public class CartsService
    {
        private readonly IMongoCollection<Cart> _cartsCollection;

        public CartsService(
        IOptions<DatabaseSettings> bookStoreDatabaseSettings)
        {
            MongoClient mongoClient = new(
                bookStoreDatabaseSettings.Value.ConnectionString);

            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(
                bookStoreDatabaseSettings.Value.DatabaseName);

            _cartsCollection = mongoDatabase.GetCollection<Cart>(
                bookStoreDatabaseSettings.Value.BooksCollectionName);
        }

        public async Task<List<Cart>> GetAsync()
        {
            return await _cartsCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Cart?> GetAsync(Guid id)
        {
            return await _cartsCollection.Find(x => x.DomainId == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Cart newCart)
        {
            await _cartsCollection.InsertOneAsync(newCart);
        }

        public async Task UpdateAsync(Guid id, Cart updatedBook)
        {
            await _cartsCollection.ReplaceOneAsync(x => x.DomainId == id, updatedBook);
        }

        public async Task RemoveAsync(Guid id)
        {
            await _cartsCollection.DeleteOneAsync(x => x.DomainId == id);
        }
    }
}
