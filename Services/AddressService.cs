using db_test.Data;
using db_test.Entities;
using db_test.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace db_test.Services;

public class AddressService : IAddressService
{
    private readonly UserDbContext _userContext;

    public AddressService(UserDbContext userContext)
    {
        _userContext = userContext;
    }

    public async Task<Address> GetAddressById(int id)
    {
        var address = await _userContext.Addresses.FindAsync(id);
        if (address == null)
        {
            throw new AddressNotFoundException($"Address {id} not found!");
        }

        return address;
    }

    public async Task<List<Address>> GetAddresses()
    {
        var addresses = await _userContext.Addresses.ToListAsync();
        return addresses;
    }

    public async Task<List<Address>> GetAddressesByUser(int userId)
    {
        var user = await _userContext.Users
            .Include(user => user.Addresses)
            .FirstOrDefaultAsync(user => userId == user.Id);
        if (user == null)
        {
            throw new UserNotFoundException($"No user with key {userId}");
        }
        return user.Addresses;
    }
}