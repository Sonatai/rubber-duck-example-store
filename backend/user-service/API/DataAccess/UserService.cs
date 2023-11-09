using API.CoreModels;
using MongoDB.Driver;

namespace API.DataAccess
{
    public class UserService
    {
        private readonly IMongoCollection<User> _userCollection;

        public UserService(DatabaseSettings databaseSettings)
        {
            MongoClient mongoClient = new(databaseSettings.ConnectionString);

            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(databaseSettings.DatabaseName);

            _userCollection = mongoDatabase.GetCollection<User>(databaseSettings.CollectionName);
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
