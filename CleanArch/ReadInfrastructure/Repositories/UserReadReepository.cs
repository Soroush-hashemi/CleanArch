using MongoDB.Driver;
using ReadModel.Bases.Repository;
using ReadModel.Entities.UserAgg;
using ReadModel.Repositories;

namespace ReadInfrastructure.Repositories;

public class UserReadReepository : BaseReadRepository<UserReadModel>, IUserReadRepository
{
    public UserReadReepository(IMongoClient client) : base(client)
    {

    }
}