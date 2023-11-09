namespace Core
{
    public class SelectedProduct
    {
        public Guid DomainId { get; private set; }
        public int Quantity { get; private set; }

        public SelectedProduct(Guid domainId, int quantity)
        {
            DomainId = domainId;
            Quantity = quantity;
        }
    }
}
