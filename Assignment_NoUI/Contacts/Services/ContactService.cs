using Contacts.Interfaces;
using Contacts.Models;

namespace Contacts.Services;

public class ContactService : IContactService
{
    private List<IContact> _contacts = new List<IContact>();
    //fixa json later asap
    //private readonly string _filePath = @"c:\Code\contacts.json";


    public async Task CreateContactAsync(IContact contact)
    {
        _contacts.Add(contact);
        await FileService.SaveToFileAsync(_filePath, "");
    }

    public IEnumerable<IContact> GetContacts()
    {
        return _contacts;
    }

    public IContact GetContact(string email)
    {
        return _contacts.FirstOrDefault(x => x.Email == email)!;
    }

    public void DeleteContact(string email)
    {
        var contact = GetContact(email);
        _contacts.Remove(contact);
    }
}