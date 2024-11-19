namespace db_test.Entities;

public class Address
{
    public int Id { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public string? ZipCode { get; set; }
    
    public int UserId { get; set; }
    public User? User { get; set; }

    public AddressDto ToDto()
    {
        var dto = new AddressDto();
        dto.Id = Id;
        dto.Street = Street;
        dto.City = City;
        dto.State = State;
        dto.Country = Country;
        dto.ZipCode = ZipCode;
        return dto;
    }
}