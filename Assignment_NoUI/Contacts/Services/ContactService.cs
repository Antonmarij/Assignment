using Contacts.Interfaces;
using Contacts.Models;

namespace Contacts.Services;

public class ContactService : IContactService
{
    //jag gör en lista som jag lägger till kontakterna i, instansierar listan.
    private List<IContact> _contacts = new List<IContact>();
    private readonly string _filePath = @"c:\Assignment\Assignment_NoUI\contacts.json";


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