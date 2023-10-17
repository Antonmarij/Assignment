using Contacts.Interfaces;
using Contacts.Models;
using System.Diagnostics;
using System.Text.Json;

namespace Contacts.Services;

public class ContactService : IContactService
{
    //jag gör en lista som jag lägger till kontakterna i, instansierar listan.
    private List<IContact> _contacts = new List<IContact>();
    private readonly string _filePath = @"c:\Assignment\Assignment_NoUI\contacts.json";



    
    public void CreateContact(IContact contact)
    {
        try
        {
            _contacts.Add(contact);
            var jsonData = JsonSerializer.Serialize(_contacts);

            FileService.SaveToFile(_filePath, jsonData);
        }
        catch(Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
       
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
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

    }
}