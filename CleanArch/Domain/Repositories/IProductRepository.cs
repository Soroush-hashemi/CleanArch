using Domain.Entities;

namespace Domain.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetById(long id);
        void Add(Product product);
        void Update(Product product);
        void Remove(Product product);
        bool IsProductExist(long id);
        Task SaveChanges(); //  در شرایط استفاده از ترانسلکشن ها باید اینو اینجا بسازیم 
    }
}
