using MediatR;
using ReadModel.Entities.UserAgg;


namespace Application.Query.Users.GetByEmail;
public record GetUserByEmailQuery(string Email) : IRequest<UserReadModel>;