using Application.DTOs.Orders;

namespace Application.Unit.Test.Builder
{
    public class OrderServiceBuilder
    {
        public AddOrderDto CreateAddOrderDto(long productId, long userId, int price, int count)
        {
            return new AddOrderDto() 
            {
                ProductId = productId,
                Price = price,
                UserId = userId,
                Count = count
            };
        }

        public FinallyOrderDto CreateFinallyOrderDto(int OrderId)
        {
            return new FinallyOrderDto()
            {
                Id = OrderId,
            };
        }
    }
}
