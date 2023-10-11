namespace Contacts.Interfaces;

public interface IAddress
{
    //vad är skillnaden på ? och '=null!;'
    string? City { get; set; }
    string? PostalCode { get; set; }
    string? StreetName { get; set; } 
    string? StreetNumber { get; set; }
    string? FullAddress { get; }

}
