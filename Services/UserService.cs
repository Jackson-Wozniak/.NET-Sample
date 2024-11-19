using db_test.Data;
using db_test.Entities;
using db_test.Exceptions;
using db_test.Services;
using Microsoft.EntityFrameworkCore;

namespace db_test.Services;

public class UserService : IUserService
{
    private readonly UserDbContext _userContext;

    public UserService(UserDbContext userContext)
    {
        _userContext = userContext;
    }

    public async Task<List<User>> GetUsers()
    {
        var users = await _userContext.Users
            .Include(user => user.Addresses)
            .ToListAsync();
        return users;
    }

    public async Task<User> GetUserById(int id)
    {
        var user = await _userContext.Users
            .Include(user => user.Addresses)
            .FirstOrDefaultAsync(u => u.Id == id);
        if (user == null)
        {
            throw new UserNotFoundException($"No user with key {id}");
        }
        return user;
    }


    public async Task<User> AddUser(User user)
    {
        var userEntity = _userContext.Users.Add(user).Entity;
        await _userContext.SaveChangesAsync();
        return userEntity;
    }

    public async Task<User> UpdateUser(User user)
    {
        var updated = _userContext.Users.Update(user).Entity;
        await _userContext.SaveChangesAsync();
        return updated;
    }

    public async Task<User> DeleteUser(int id)
    {
        var user = GetUserById(id).Result;
        var deleted = _userContext.Users.Remove(user).Entity;
        await _userContext.SaveChangesAsync();
        return deleted;
    }
}