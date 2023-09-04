using ReadModel.Bases;
using ReadModel.Exception;

namespace ReadModel.Entities.UserAgg;
public class UserReadModel : BaseReadModel
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Family { get; set; }

    public UserReadModel()
    {
        
    }
}