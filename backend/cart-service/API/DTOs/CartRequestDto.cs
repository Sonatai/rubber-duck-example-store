namespace API.DTOs
{
    public class CartRequestDto
    {
        public string? DomainId { get; set; }
        public string UserId { get; set; }
        public IEnumerable<SelectedProductDto>? SelectedProducts { get; set; }
    }
}
