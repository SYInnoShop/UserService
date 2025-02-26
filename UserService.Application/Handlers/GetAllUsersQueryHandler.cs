using Mapster;
using MediatR;
using ErrorOr;
using UserService.Application.DTOs;
using UserService.Application.Queries;
using UserService.Infrastructure.Interfaces;

namespace UserService.Application.Handlers;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, ErrorOr<List<UserDto>>>
{
    private readonly IUserRepository _repository;

    public GetAllUsersQueryHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<List<UserDto>>> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
    {
        var users = await _repository.GetAllAsync();
        return users.Adapt<List<UserDto>>();
    }
}