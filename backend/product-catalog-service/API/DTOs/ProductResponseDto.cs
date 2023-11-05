namespace Rubber.Duck.Store.Product.Catalog.DTOs
{
    public class ProductResponseDto
    {
        public Guid DomainId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Image { get; set; } = string.Empty;
    }
}
