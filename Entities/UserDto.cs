namespace db_test.Entities;

public class UserDto
{
    public int Id { get; set; }
    public string? Username { get; set; }

    public User ToUser()
    {
        var user = new User();
        user.Id = Id;
        user.Username = Username;
        return user;
    }
}