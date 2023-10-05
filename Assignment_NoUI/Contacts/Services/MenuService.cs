using Contacts.Interfaces;
using Contacts.Models;

namespace Contacts.Services;



internal interface IMenuService
{
    public void MainMenu();
    public void CreateMenu();
    public void ListAllMenu();
    public void ListSpecificMenu();

}

internal class MenuService : IMenuService
{
    private readonly IContactService _contactService = new ContactService();


    public void MainMenu()
    {
        var exit = false;

        do
        {
            Console.Clear();
            Console.WriteLine("1. Create new contact.");
            Console.WriteLine("2. Show a contact");
            Console.WriteLine("3. Show all contacts");
            Console.WriteLine("0. Exit Menu");
            Console.Write("Choose one of the above options: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    CreateMenu();
                    break;

                case "2":
                    ListSpecificMenu();
                    break;

                case "3":
                    ListAllMenu();
                    break;

                case "0":
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Choose one of the contact options or exit option!");
                    break;
            }
        }
        while (exit == false);
    }


    public void CreateMenu()
    {
        Console.Clear();
        Console.WriteLine("Create a new contact");
        Console.WriteLine("---------------------");

        var contact = new ContactCreateRequest();

        Console.Write("First name: ");
        contact.FirstName = Console.ReadLine()!.Trim();

        Console.Write("Last name: ");
        contact.LastName = Console.ReadLine()!.Trim();

        Console.Write("Email: ");
        contact.Email = Console.ReadLine()!.Trim().ToLower();

        Console.Write("Address: ");
        contact.Address = Console.ReadLine()!.Trim();

        Console.Write("PhoneNumber: ");
        contact.PhoneNumber = Console.ReadLine()!.Trim();

        Console.Write("Passowrd: ");
        contact.Password = Console.ReadLine()!.Trim();

        _contactService.CreateContact(contact);
        Console.WriteLine("A new contact has been created!");
        Console.ReadKey();

    }

    public void ListAllMenu()
    {
        Console.Clear();
        Console.WriteLine("All contacts");
        Console.WriteLine("----------------------------------------------------");

        foreach (var contact in _contactService.GetContacts())
            Console.WriteLine($"{contact.FirstName} {contact.LastName} <{contact.Email}> {contact.Address} {contact.PhoneNumber}");

        Console.ReadKey();
    }

    public void ListSpecificMenu()
    {
        throw new NotImplementedException();
    }
}
