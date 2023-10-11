using Contacts.Interfaces;
using Contacts.Services;

namespace Contacts.Menus;

public class GetSpecificContactMenu
{
    private static readonly IContactService contactService = new ContactService();

    public void Show()
    {
        Console.Write("Email: ");
        var email = Console.ReadLine();

        var contact = contactService.GetContact(email!);

        Console.WriteLine(contact.FullName);
        Console.WriteLine(contact.Email);
        Console.WriteLine(contact.PhoneNumber);
        Console.WriteLine(contact.Address.FullAddress);
    }
}
