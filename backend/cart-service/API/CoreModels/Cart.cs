using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.CoreModels
{
    public class Cart
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? DomainId { get; private set; }
        public string UserId { get; private set; }
        public IEnumerable<SelectedProduct> SelectedProducts { get; private set; } = default!;
        public DateTime TimeStamp { get; private set; }

        public Cart(string? domainId, string userId, IEnumerable<SelectedProduct> selectedProducts)
        {
            if (domainId != null)
            {
                DomainId = domainId;
            }
            UserId = userId;
            SelectedProducts = selectedProducts;
            TimeStamp = DateTime.UtcNow;
        }
    }
}
