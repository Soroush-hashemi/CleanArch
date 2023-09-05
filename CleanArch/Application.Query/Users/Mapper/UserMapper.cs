using Application.Query.Users.DTOs;
using Domain;
using ReadModel.Entities.UserAgg;

namespace Application.Query.Users.Mapper;
public class UserMapper
{
    public static UserDto MapUserToDto(UserReadModel user)
    {
        if (user == null)
            throw new ArgumentNullException();

        return new UserDto()
        {
            Id = user.Id,
            Name = user.Name,
            Family = user.Family,
            Email = user.Email
        };
    }
}