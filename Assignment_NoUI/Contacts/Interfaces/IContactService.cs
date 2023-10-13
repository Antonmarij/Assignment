using Contacts.Models;

namespace Contacts.Interfaces;

public interface IContactService
{
    Task CreateContactAsync(IContact contact);
    IEnumerable<IContact> GetContacts();
    IContact GetContact(string email);
    void DeleteContact(string email);



}
