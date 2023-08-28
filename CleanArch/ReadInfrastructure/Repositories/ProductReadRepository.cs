using MongoDB.Driver;
using ReadModel.Bases.Repository;
using ReadModel.Entities.ProductAgg;
using ReadModel.Repositories;

namespace ReadInfrastructure.Repositories
{
    public class ProductReadRepository : BaseReadRepository<ProductReadModel>, IProductReadRepository
    {
        public ProductReadRepository(IMongoClient client) : base(client)
        {

        }
    }
}
