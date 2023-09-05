using Domain;

namespace Application.Query.Users.DTOs;
public class UserDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Family { get; set; }
}