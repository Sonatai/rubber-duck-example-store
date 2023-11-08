using Core;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DataAccess
{
    public class CartsService
    {
        private readonly IMongoCollection<Cart> _cartsCollection;

        public CartsService(
        IOptions<DatabaseSettings> databaseSettings)
        {
            MongoClient mongoClient = new(
                databaseSettings.Value.ConnectionString);

            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _cartsCollection = mongoDatabase.GetCollection<Cart>(
                databaseSettings.Value.BooksCollectionName);
        }

        //public async Task<List<Cart>> GetAsync()
        //{
        //    return await _cartsCollection.Find(_ => true).ToListAsync();
        //}

        //public async Task<Cart?> GetAsync(string id)
        //{
        //    return await _cartsCollection.Find(x => x.DomainId == id).FirstOrDefaultAsync();
        //}

        public async Task<Cart?> GetByUserIdAsync(string id)
        {
            return await _cartsCollection.Find(x => x.UserId == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Cart newCart)
        {
            await _cartsCollection.InsertOneAsync(newCart);
        }

        //public async Task UpdateAsync(string id, Cart updatedBook)
        //{
        //    await _cartsCollection.ReplaceOneAsync(x => x.DomainId == id, updatedBook);
        //}

        //public async Task RemoveAsync(string id)
        //{
        //    await _cartsCollection.DeleteOneAsync(x => x.DomainId == id);
        //}
    }
}
