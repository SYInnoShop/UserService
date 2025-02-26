using MediatR;
using ErrorOr;
using Mapster;
using UserService.Application.Commands;
using UserService.Domain.Entities;
using UserService.Infrastructure.Interfaces;

namespace UserService.Application.Handlers;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ErrorOr<User>>
{
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<User>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetByEmailAsync(command.UserRegisterDto.Email) != null)
            return Error.Conflict("User with this email already exists");

        var newUser = command.UserRegisterDto.Adapt<User>();
        newUser.Role = "Admin";
        newUser.IsEmailConfirmed = true;

        await _userRepository.AddAsync(newUser);
        await _userRepository.SaveChangesAsync(cancellationToken);
        
        return newUser;
    }
}