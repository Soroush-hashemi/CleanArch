using Domain.Entities;

namespace Domain.Repositories
{
    public interface IProductRepository
    {
        void Add(Product product);
        void Update(Product product);
        void Remove(Product product);
        List<Product> GetAll();
        Product GetById(Guid id);
        bool IsProductExist(Guid id);

        // void Save(); در شرایط استفاده از ترانسلکشن ها باید اینو اینجا بسازیم 
    }
}
