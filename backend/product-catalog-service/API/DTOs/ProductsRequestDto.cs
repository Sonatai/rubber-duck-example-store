namespace Rubber.Duck.Store.Product.Catalog.DTOs
{
    public class ProductsRequestDto
    {
        public IEnumerable<Guid> ProductIds { get; set; } = new List<Guid>();
    }
}
