﻿using MediatR;
using ReadModel.Entities.UserAgg;
using ReadModel.Repositories;

namespace Application.Query.Users.GetByEmail;
public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, UserReadModel>
{
    private readonly IUserReadRepository _readRepository;

    public GetUserByEmailQueryHandler(IUserReadRepository readRepository)
    {
        _readRepository = readRepository;
    }

    public async Task<UserReadModel> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        return await _readRepository.GetByEmail(request.Email);
    }
}