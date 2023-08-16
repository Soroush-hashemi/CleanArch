using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence.Ef;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    // ریپازیتوری های داخل دامین اینجا ایمپلیمنت میشن 
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Product product)
        {
            _context.Add(product);
        }

        public async Task<Product> GetById(long id)
        {
            return await _context.Products.FirstOrDefaultAsync(f => f.Id == id);
        }

        public bool IsProductExist(long id)
        {
            return _context.Products.Any(f => f.Id == id);
        }

        public void Remove(Product product)
        {
            _context.Remove(product);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Product product)
        {
            _context.Update(product);
        }
    }
}