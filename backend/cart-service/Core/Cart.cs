namespace Core
{
    public class Cart
    {
        public Guid DomainId { get; private set; }
        public Guid UserId { get; private set; }
        public IEnumerable<SelectedProduct> SelectedProducts { get; private set; } = default!;

        public Cart(Guid domainId, Guid userId, IEnumerable<SelectedProduct> selectedProducts)
        {
            DomainId = domainId;
            UserId = userId;
            SelectedProducts = selectedProducts;
        }
    }
}
