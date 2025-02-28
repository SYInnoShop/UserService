using MediatR;
using ErrorOr;
using UserService.Application.Commands;
using UserService.Infrastructure.Interfaces;

namespace UserService.Application.Handlers;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ErrorOr<bool>>
{
    private readonly IUserRepository _repository;

    public DeleteUserCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<bool>> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
    {
        var user = await _repository.GetByIdAsync(command.Id);
        if (user == null)
            return Error.NotFound($"User with id {command.Id} not found");

        await _repository.DeleteAsync(user.Id);
        return true;
    }
}