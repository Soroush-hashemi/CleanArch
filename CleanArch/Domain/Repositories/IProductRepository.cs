using Domain.Entities;

namespace Domain.Repositories
{
    public interface IProductRepository
    {
        void Add(Product product);
        void Update(Product product);
        void Remove(Product product);
        List<Product> GetAll();
        Task<Product> GetById(long id);
        bool IsProductExist(long id);
        Task SaveChanges(); //  در شرایط استفاده از ترانسلکشن ها باید اینو اینجا بسازیم 
    }
}
