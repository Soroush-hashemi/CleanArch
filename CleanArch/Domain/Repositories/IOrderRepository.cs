using Domain.Entities;

namespace Domain.Repositories
{
    public interface IOrderRepository
    {
        void Add(Order order);
        void Update(Order order);
        void Remove(Order order);
        List<Order> GetAll();
        Order GetById(long id);
        void Save(); //  در شرایط استفاده از ترانسلکشن ها باید اینو اینجا بسازیم
    } 
}
