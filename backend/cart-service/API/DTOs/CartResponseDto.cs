namespace API.DTOs
{
    public class CartResponseDto
    {
        public Guid DomainId { get; set; }
        public Guid UserId { get; set; }
        public IEnumerable<SelectedProductDto>? SelectedProducts { get; set; }
        public DateTime TimeStamp { get; private set; }
    }
}
