using Application.Query.Products.DTOs;
using Application.Query.Products.GetList;
using Application.Query.Users.DTOs;
using Application.Query.Users.Mapper;
using MediatR;
using ReadModel.Repositories;

namespace Application.Query.Users.GetList;
public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, List<UserDto>>
{
    private readonly IUserReadRepository _readRepository;
    public GetUserListQueryHandler(IUserReadRepository readRepository)
    {
        _readRepository = readRepository;
    }

    public async Task<List<UserDto>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
    {
        var Users = await _readRepository.GetAll();
        var UserDtos = Users.Select(User => UserMapper.MapUserToDto(User)).ToList();
        return UserDtos;
    }
}
