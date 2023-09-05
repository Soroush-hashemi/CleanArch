using MongoDB.Driver;
using ReadModel.Bases.Repository;
using ReadModel.Entities.UserAgg;
using ReadModel.Repositories;

namespace ReadInfrastructure.Repositories;

public class UserReadRepository : BaseReadRepository<UserReadModel>, IUserReadRepository
{
    public UserReadRepository(IMongoClient client) : base(client)
    {

    }
}