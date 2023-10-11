using Contacts.Interfaces;
using Contacts.Services;

namespace Contacts.Menus;

public class DeleteContactMenu
{
    private static readonly IContactService contactService = new ContactService();

    public void Show()
    {
        Console.Write("Email: ");
        var email = Console.ReadLine();

        contactService.DeleteContact(email!);
    }
}
