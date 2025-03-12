using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.Model;
using UserService.Application.Users.CreateUser;
using UserService.Application.Users.DeleteUser;
using UserService.Application.Users.GetAllUsers;
using UserService.Application.Users.GetUserById;
using UserService.Application.Users.UpdateUser;

namespace UserService.Presentation.Controllers;

public class UserController(IMediator mediator) : ApiControllerBase(mediator)
{
    [HttpGet]
    [Authorize(Policy = "Admin")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetAllUsersQuery(), cancellationToken);
        return result.Match(
            users => Ok(users),
            errors => Problem(errors.First().Description));
    }
    
    [HttpGet("{id}")]
    [Authorize(Policy = "Admin")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetUserByIdQuery(id), cancellationToken);
        return result.Match(
            user => Ok(user),
            errors => Problem(errors.First().Description));
    }
   
    [HttpPost]
    [Authorize(Policy = "Admin")]
    public async Task<IActionResult> CreateAdmin([FromBody] CreateUser model, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreateUserCommand(model.Name, model.Email, model.Password), cancellationToken);
        return result.Match(
            user => Ok(user),
            errors => Problem(errors.First().Description));
    }
    
    [HttpPut ("{id}")]
    [Authorize(Policy = "AdminOrUser")]
    public async Task<IActionResult> Update([FromBody] UpdateUser model, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new UpdateUserCommand(model.Id,model.Name), cancellationToken);
        return result.Match(
            success => Ok(success),
            errors => Problem(errors.First().Description));
    }
    
    [HttpDelete ("{id}")]
    [Authorize(Policy = "Admin")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new DeleteUserCommand(id), cancellationToken);
        return result.Match(
            success => Ok(success),
            errors => Problem(errors.First().Description));
    }
}