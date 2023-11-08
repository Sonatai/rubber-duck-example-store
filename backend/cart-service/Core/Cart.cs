using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core
{
    public class Cart
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Guid? DomainId { get; private set; }
        public Guid UserId { get; private set; }
        public IEnumerable<SelectedProduct> SelectedProducts { get; private set; } = default!;
        public DateTime TimeStamp { get; private set; }

        public Cart(Guid? domainId, Guid userId, IEnumerable<SelectedProduct> selectedProducts)
        {
            if (domainId != null)
            {
                DomainId = domainId.Value;
            }
            UserId = userId;
            SelectedProducts = selectedProducts;
            TimeStamp = DateTime.UtcNow;
        }
    }
}
