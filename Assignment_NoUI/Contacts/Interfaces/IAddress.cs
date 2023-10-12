namespace Contacts.Interfaces;

public interface IAddress
{
    
    string? City { get; set; }
    string? PostalCode { get; set; }
    string? Street { get; set; } 
    string? FullAddress { get; }

}
