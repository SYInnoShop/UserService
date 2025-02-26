using MediatR;
using ErrorOr;
using UserService.Application.DTOs;

namespace UserService.Application.Queries;

public record GetAllUsersQuery : IRequest<ErrorOr<List<UserDto>>>;