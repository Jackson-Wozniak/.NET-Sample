using db_test.Data;
using db_test.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace db_test.Controllers;

[Route("test")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserDbContext context;
    
    public UserController(UserDbContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public async Task<ActionResult> AddUser()
    {
        var user = new User();
        user.Username = "new name";
        context.Users.Add(user);
        await context.SaveChangesAsync();
        return Ok(user);
    }
}