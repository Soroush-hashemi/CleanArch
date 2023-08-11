using Application.DTOs.Orders;

namespace Application.Common.Interfaces
{
    public interface IOrderServices
    {
        void AddOrder(AddOrderDto command);
        void FinallyOrder(FinallyOrderDto command);
        OrderDto GetOrderById(long id);
        List<OrderDto> GetOrders();
    }
}
