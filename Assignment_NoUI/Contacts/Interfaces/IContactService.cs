using Contacts.Models;

namespace Contacts.Interfaces;

public interface IContactService
{
    void CreateContact(IContact contact);
    IEnumerable<IContact> GetContacts();
    IContact GetContact(string email);
    void DeleteContact(string email);



}
