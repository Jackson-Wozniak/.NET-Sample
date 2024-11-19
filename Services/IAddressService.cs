using db_test.Entities;

namespace db_test.Services;

public interface IAddressService
{
    Task<Address> GetAddressById(int id);
    Task<List<Address>> GetAddresses();
    Task<List<Address>> GetAddressesByUser(int userId);
}