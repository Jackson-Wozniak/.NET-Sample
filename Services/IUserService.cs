using db_test.Entities;

namespace db_test.Services;

public interface IUserService
{
    Task<List<User>> GetUsers();
    Task<User> GetUserById(int id);
    Task<User> AddUser(User user);
    Task<User> UpdateUser(User user);
    Task<User> DeleteUser(int id);
}