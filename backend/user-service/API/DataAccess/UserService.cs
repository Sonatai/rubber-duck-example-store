using API.CoreModels;
using MongoDB.Driver;

namespace API.DataAccess
{
    public class UserService
    {
        private readonly IMongoCollection<User> _userCollection;

        /*@note: 
         * Docker konnte in dieser API die Appsettings nicht lesen 
         * und ich hatte nicht genug Zeit rauszufinden warum er sie nicht finde :)
         */

        public UserService(DatabaseSettings _)
        {
            MongoClient mongoClient = new("mongodb://admin:1234@172.17.0.1:4310/");

            IMongoDatabase mongoDatabase = mongoClient.GetDatabase("userDb");

            _userCollection = mongoDatabase.GetCollection<User>("users");
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
