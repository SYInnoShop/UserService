using MediatR;
using ErrorOr;

namespace UserService.Application.Commands;

public record DeleteUserCommand(int Id) : IRequest<ErrorOr<bool>>;