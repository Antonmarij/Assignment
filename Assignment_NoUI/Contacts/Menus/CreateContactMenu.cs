using Contacts.Interfaces;
using Contacts.Models;
using Contacts.Services;

namespace Contacts.Menus;

public class CreateContactMenu
{
    private static readonly IContactService contactService = new ContactService();
    
    public void Show()
    {
        //skapar och sparar en kontakt med värdena som användaren skriver in i konsolen.
        Console.Clear();
        Console.WriteLine("Create a new contact");
        Console.WriteLine("---------------------");

        IContact contact = new Contact();

        Console.Write("First name: ");
            contact.FirstName = Console.ReadLine()!.Trim();

        Console.Write("Last name: ");
            contact.LastName = Console.ReadLine()!.Trim();

        Console.Write("Email: ");
            contact.Email = Console.ReadLine()!.Trim().ToLower();

        contact.Address = new Address();

        Console.Write("Street Name: ");
            contact.Address.StreetName = Console.ReadLine()!.Trim();

        Console.Write("Street Number: ");
            contact.Address.StreetNumber = Console.ReadLine()!.Trim();

        Console.Write("Postal Code: ");
            contact.Address.PostalCode = Console.ReadLine()!.Trim();

        Console.Write("City: ");
            contact.Address.City = Console.ReadLine()!.Trim();

        contactService.CreateContact(contact);

    }
}
