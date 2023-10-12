using Contacts.Interfaces;

namespace Contacts.Models;

public class Address : IAddress
{
    public string? Street { get; set; }
    public string? PostalCode { get; set; }
    public string? City { get; set; }

    public string? FullAddress => $"{Street}\n{PostalCode} {City}";
}
