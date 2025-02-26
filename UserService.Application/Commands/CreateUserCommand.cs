using MediatR;
using ErrorOr;
using UserService.Application.DTOs;
using UserService.Domain.Entities;

namespace UserService.Application.Commands;

public record CreateUserCommand(UserRegisterDto UserRegisterDto) : IRequest<ErrorOr<User>>;