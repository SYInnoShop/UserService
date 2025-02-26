using MediatR;
using ErrorOr;
using UserService.Application.DTOs;

namespace UserService.Application.Commands;

public record UpdateUserCommand(UserUpdateDto UserUpdateDto) : IRequest<ErrorOr<bool>>;