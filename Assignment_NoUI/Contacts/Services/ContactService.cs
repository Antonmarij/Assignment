using Contacts.Interfaces;
using Contacts.Models;

namespace Contacts.Services;

public class ContactService : IContactService
{
    //jag gör en lista som jag lägger till kontakterna i, instansierar listan.
    private List<IContact> _contacts = new List<IContact>();
    private readonly string _filePath = @"c:\Assignment\Assignment_NoUI\contacts.json";



    ////await/async exempel, mer användbart i större projekt. har kvar ändå. kunde varit void ingen skillnad i detta projekt.
    public async Task CreateContactAsync(IContact contact)
    {
        _contacts.Add(contact);
        await FileService.SaveToFileAsync(_filePath, "");
    }
    //returnerar alla kontakterna från listan
    public IEnumerable<IContact> GetContacts()
    {
        return _contacts;
    }
    //matchar email med en email i listan och returnerar den kontakten
    public IContact GetContact(string email)
    {
        return _contacts.FirstOrDefault(x => x.Email == email)!;
    }
    //borde matcha email och ta bort kontakten med den emailen men "tar bort" oavsett vad? fråga hans
    public void DeleteContact(string email)
    {
        var contact = GetContact(email);
        _contacts.Remove(contact);

    }
}