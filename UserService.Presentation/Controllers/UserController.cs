using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.Commands;
using UserService.Application.DTOs;
using UserService.Application.Queries;

namespace UserService.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("get-users")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllUsersQuery());
        return result.Match(
            users => Ok(users),
            errors => Problem(errors.First().Description));
    }
    
    [HttpGet("get-user/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetUserByIdQuery(id));
        return result.Match(
            user => Ok(user),
            errors => Problem(errors.First().Description));
    }
   
    [HttpPost("create-admin")]
    public async Task<IActionResult> CreateAdmin(UserRegisterDto userRegisterDto)
    {
        var result = await _mediator.Send(new CreateUserCommand(userRegisterDto));
        return result.Match(
            user => Ok(user),
            errors => Problem(errors.First().Description));
    }
    
    [HttpPut("change-name")]
    public async Task<IActionResult> Update(UserUpdateDto userUpdateDto)
    {
        var result = await _mediator.Send(new UpdateUserCommand(userUpdateDto));
        return result.Match(
            success => Ok(success),
            errors => Problem(errors.First().Description));
    }
    
    [HttpDelete("delete-user/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteUserCommand(id));
        return result.Match(
            success => Ok(success),
            errors => Problem(errors.First().Description));
    }
}