using Contacts.Interfaces;

namespace Contacts.Models;

public class Contact : IContact
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public IAddress Address { get; set; }
    public string FullName => $"{FirstName} {LastName}";
}
