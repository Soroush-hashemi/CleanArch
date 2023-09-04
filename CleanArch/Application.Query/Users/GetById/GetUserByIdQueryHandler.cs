using Application.Query.Products.Mapper;
using Application.Query.Users.DTOs;
using Application.Query.Users.Mapper;
using Domain.Entities;
using MediatR;
using ReadModel.Repositories;

namespace Application.Query.Users.GetById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
{
    private readonly IUserReadRepository _readRepository;
    public GetUserByIdQueryHandler(IUserReadRepository readRepository)
    {
        _readRepository = readRepository;
    }

    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var User = await _readRepository.GetById(request.UserId);
        return UserMapper.MapUserToDto(User);
    }
}