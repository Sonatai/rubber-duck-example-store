namespace Rubber.Duck.Store.Product.Catalog.DTOs
{
    public class ProductsResponseDto
    {
        public IEnumerable<ProductResponseDto> Products { get; set; } = new List<ProductResponseDto>();
    }
}
