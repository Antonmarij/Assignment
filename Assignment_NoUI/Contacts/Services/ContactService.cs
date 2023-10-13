using Contacts.Interfaces;
using Contacts.Models;
using System.Text.Json;

namespace Contacts.Services;

public class ContactService : IContactService
{
    //jag gör en lista som jag lägger till kontakterna i, instansierar listan.
    private List<IContact> _contacts = new List<IContact>();
    private readonly string _filePath = @"c:\Assignment\Assignment_NoUI\contacts.json";



    ////await/async exempel, mer användbart i större projekt. har kvar ändå. kunde varit void ingen skillnad i detta projekt.
    public void CreateContact(IContact contact)
    {
        try
        {
            _contacts.Add(contact);
            //skriver över alla kontakter som finns, fråga hans
            var jsonData = JsonSerializer.Serialize(_contacts);

            FileService.SaveToFile(_filePath, jsonData);
        }
        catch { }
       
    }
    //returnerar alla kontakterna från listan
    public IEnumerable<IContact> GetContacts()
    {
        //try catch funkar ej här blir rött uppe
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
        try
        {
            var contact = GetContact(email);
            _contacts.Remove(contact);
        }
        catch { }

    }
}