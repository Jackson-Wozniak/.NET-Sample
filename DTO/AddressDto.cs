namespace db_test.Entities;

public class AddressDto
{
    public int Id { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public string? ZipCode { get; set; }

    public Address ToAddress()
    {
        var address = new Address();
        address.Id = Id;
        address.Street = Street;
        address.City = City;
        address.State = State;
        address.Country = Country;
        address.ZipCode = ZipCode;
        return address;
    }
}