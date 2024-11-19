using db_test.Data;
using db_test.Entities;
using db_test.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace db_test.Controllers;

[Route("api/Users")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    
    public UserController(IUserService userService)
    {
        this._userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _userService.GetUsers();
        return Ok(users.Select(user => user.ToDto()).ToList());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
        var user = await _userService.GetUserById(id);
        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult> AddUser(UserDto user)
    {
        var newUser = user.ToUser();
        await _userService.AddUser(newUser);
        return Ok(newUser);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateUser(UserDto user)
    {
        var updated = await _userService.UpdateUser(user.ToUser());
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUser(int id)
    {
        await _userService.DeleteUser(id);
        return Ok();
    }
}