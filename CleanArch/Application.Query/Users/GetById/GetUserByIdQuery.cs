using Application.Query.Users.DTOs;
using MediatR;

namespace Application.Query.Users.GetById;
public record GetUserByIdQuery (long UserId) : IRequest<UserDto>;