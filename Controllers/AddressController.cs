using db_test.Entities;
using db_test.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace db_test.Controllers;

[Route("api/Addresses")]
[ApiController]
public class AddressController : ControllerBase
{
    private readonly IUserService _userService;
    
    public AddressController(IUserService userService)
    {
        this._userService = userService;
    }
    
    [HttpGet]
    
    [HttpPost]
    public async Task<ActionResult> AddAddress(AddressDto addressDto, [FromQuery] int id)
    {
        var user = _userService.GetUserById(id).Result;
        user.Addresses.Add(addressDto.ToAddress());
        
        await _userService.UpdateUser(user);
        return Ok();
    }
}