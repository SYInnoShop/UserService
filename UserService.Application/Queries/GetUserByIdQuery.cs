using MediatR;
using ErrorOr;
using UserService.Application.DTOs;

namespace UserService.Application.Queries;

public record GetUserByIdQuery(int Id) : IRequest<ErrorOr<UserDto>>;