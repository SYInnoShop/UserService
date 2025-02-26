using Mapster;
using MediatR;
using ErrorOr;
using UserService.Application.DTOs;
using UserService.Application.Queries;
using UserService.Infrastructure.Interfaces;

namespace UserService.Application.Handlers;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ErrorOr<UserDto>>
{
    private readonly IUserRepository _repository;

    public GetUserByIdQueryHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<UserDto>> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
    {
        var user = await _repository.GetByIdAsync(query.Id);
        if (user == null)
            return Error.NotFound($"User with id {query.Id} not found");

        return user.Adapt<UserDto>();
    }
}