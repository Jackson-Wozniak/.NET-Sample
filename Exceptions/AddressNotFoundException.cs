namespace db_test.Exceptions;

public class AddressNotFoundException : Exception
{
    public AddressNotFoundException(string message) : base(message) { }
}