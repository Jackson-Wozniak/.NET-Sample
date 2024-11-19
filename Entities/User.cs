namespace db_test.Entities;

public class User
{
    public int Id { get; set; }
    public string? Username { get; set; }
    
    public List<Address> Addresses { get; set; } = new();

    public UserDto ToDto()
    {
        var dto = new UserDto();
        dto.Id = Id;
        dto.Username = Username;
        dto.Addresses = Addresses.Select(a => a.ToDto()).ToList();
        return dto;
    }
}