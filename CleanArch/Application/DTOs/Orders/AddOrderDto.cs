namespace Application.DTOs.Orders
{
    public class AddOrderDto
    {
        public long ProductId { get; set; }
        public long UserId { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
    }
}
