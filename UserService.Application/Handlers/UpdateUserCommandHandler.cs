using MediatR;
using ErrorOr;
using UserService.Application.Commands;
using UserService.Infrastructure.Interfaces;

namespace UserService.Application.Handlers;

public class UpdateUserCommandHandler :  IRequestHandler<UpdateUserCommand, ErrorOr<bool>>
{
    private readonly IUserRepository _repository;

    public UpdateUserCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<bool>> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var user = await _repository.GetByIdAsync(command.UserUpdateDto.Id);
        if (user == null)
            return Error.NotFound($"User with id {command.UserUpdateDto.Id} not found");

        user.Name = command.UserUpdateDto.Name;
        await _repository.UpdateAsync(user);

        return true;
    }
}