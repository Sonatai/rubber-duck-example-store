using BCrypt.Net;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using BC = BCrypt.Net.BCrypt;

namespace Core
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; private set; }
        public string Name { get; private set; }
        public string Password { get; private set; }

        public User(string? id, string name, string password)
        {

            Name = name;
            Password = BC.EnhancedHashPassword(password, hashType: HashType.SHA384);
            Id = id;
        }
    }
}
