namespace API.DTOs
{
    public class CartRequestDto
    {
        public Guid? DomainId { get; set; }
        public Guid UserId { get; set; }
        public IEnumerable<SelectedProductDto>? SelectedProducts { get; set; }
    }
}
