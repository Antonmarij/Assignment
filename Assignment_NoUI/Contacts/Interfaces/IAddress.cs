namespace Contacts.Interfaces;

public interface IAddress
{
    string? Street { get; set; }
    string? PostalCode { get; set; }
    string? City { get; set; }
    string? FullAddress { get; }

}
