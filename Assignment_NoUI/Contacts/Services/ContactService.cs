using Contacts.Interfaces;
using Contacts.Models;
using System.Diagnostics;
using System.Text.Json;

namespace Contacts.Services;

public class ContactService : IContactService
{
    //jag gör en lista som jag lägger till kontakterna i, instansierar listan.
    //listan kan bara innehålla data som IContact har definierat
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
        var contacts = FileService.ReadFromFile(_filePath);
        if (!string.IsNullOrEmpty(contacts))
        {
            _contacts = JsonSerializer.Deserialize<List<IContact>>(contacts)!;
        }
        
        return _contacts;
    }

    public IContact GetContact(string email)
    {
        //går igenom listan av kontakterna och försöker matcha en existerande email med användarens input
        return _contacts.FirstOrDefault(x => x.Email == email)!;
    }
    //borde matcha email och ta bort kontakten med den emailen men "tar bort" oavsett vad? fråga hans
    public void DeleteContact(string email)
    {
        try
        {
            var contact = GetContact(email);
            if (contact != null)
            {
                _contacts.Remove(contact);
                Console.WriteLine("Contact deleted!");
            }
            else
            {
                    Console.WriteLine("Contact not found.");
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

    }
}