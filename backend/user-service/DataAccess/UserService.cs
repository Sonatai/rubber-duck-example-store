using Core;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DataAccess
{
    public class UserService
    {
        private readonly IMongoCollection<User> _userCollection;

        public UserService(
        IOptions<DatabaseSettings> databaseSettings)
        {
            MongoClient mongoClient = new(
                databaseSettings.Value.ConnectionString);

            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _userCollection = mongoDatabase.GetCollection<User>(
                databaseSettings.Value.CollectionName);
        }

        public async Task<User?> GetAsync(string id)
        {
            return await _userCollection.Find(x => x.Name == id).FirstOrDefaultAsync();
        }


        public async Task<User?> CreateAsync(User newCart)
        {
            await _userCollection.InsertOneAsync(newCart);

            return newCart;
        }
    }
}
