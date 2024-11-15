namespace db_test.Entities;

public class User
{
    public int Id { get; set; }
    public string? Username { get; set; }

    public UserDto ToDto()
    {
        var dto = new UserDto();
        dto.Id = Id;
        dto.Username = Username;
        return dto;
    }
}