namespace db_test.Entities;

public class UserDto
{
    public int Id { get; set; }
    public string? Username { get; set; }

    public List<AddressDto> Addresses { get; set; } = new();

    public User ToUser()
    {
        var user = new User();
        user.Id = Id;
        user.Username = Username;
        user.Addresses.AddRange(Addresses.Select(x => x.ToAddress()));
        return user;
    }
}