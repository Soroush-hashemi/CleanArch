using Application.Query.Users.DTOs;
using MediatR;

namespace Application.Query.Users.GetList;
public record class GetUserListQuery : IRequest<List<UserDto>>;