using Application.DTOs.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
