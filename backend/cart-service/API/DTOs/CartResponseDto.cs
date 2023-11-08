namespace API.DTOs
{
    public class CartResponseDto
    {
        public string DomainId { get; set; }
        public string UserId { get; set; }
        public IEnumerable<SelectedProductDto>? SelectedProducts { get; set; }
        public DateTime TimeStamp { get; private set; }
    }
}
