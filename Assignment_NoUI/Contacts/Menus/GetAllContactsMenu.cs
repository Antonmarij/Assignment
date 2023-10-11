using Contacts.Interfaces;
using Contacts.Services;

namespace Contacts.Menus;

public class GetAllContactsMenu
{
    private static readonly IContactService contactService = new ContactService();

    public void Show()
    {
        foreach (var contact in contactService.GetContacts())
        {
            Console.WriteLine(contact.FullName);
            Console.WriteLine(contact.Address.FullAddress);

        }
    }
}
