using API.CoreModels;
using MongoDB.Driver;

namespace API.DataAccess
{
    public class CartsService
    {
        private readonly IMongoCollection<Cart> _cartsCollection;

        /*@note: 
         * Docker konnte in dieser API die Appsettings nicht lesen 
         * und ich hatte nicht genug Zeit rauszufinden warum er sie nicht finde :)
         */

        public CartsService(
        DatabaseSettings _)
        {
            MongoClient mongoClient = new("mongodb://admin:1234@172.17.0.1:4300/");

            IMongoDatabase mongoDatabase = mongoClient.GetDatabase("cart");

            _cartsCollection = mongoDatabase.GetCollection<Cart>("carts");
        }

        public async Task<Cart?> GetAsync(string id)
        {
            return await _cartsCollection.Find(x => x.DomainId == id).FirstOrDefaultAsync();
        }

        public async Task<Cart?> GetByUserIdAsync(string id)
        {
            return await _cartsCollection.Find(x => x.UserId == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Cart newCart)
        {
            await _cartsCollection.InsertOneAsync(newCart);
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
