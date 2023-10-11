using Contacts.Interfaces;
using Contacts.Models;
using System.Diagnostics.Metrics;

namespace Contacts.Services;
public class MenuService 
{
    private static readonly IContactService contactService = new ContactService();


    public void MainMenu()
    {
        var exit = false;

        do
        {
            Console.Clear();
            Console.WriteLine("1. Create new contact.");
            Console.WriteLine("2. Show a contact");
            Console.WriteLine("3. Show all contacts");
            Console.WriteLine("4. Remove a contact");
            Console.WriteLine("0. Exit Menu");
            Console.Write("Choose one of the above options: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    CreateContactMenu();
                    break;

                case "2":
                    GetSpecificContactMenu();
                    break;

                case "3":
                    GetAllContactsMenu();
                    break;

                case "4":
                    DeleteContactMenu();
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


    public void CreateContactMenu()
    {
        IContact contact = new Contact();

        Console.Write("First Name: ");
            contact.FirstName = Console.ReadLine();
        Console.Write("Last Name: ");
            contact.LastName = Console.ReadLine();
        Console.Write("Email: ");
            contact.Email = Console.ReadLine();
        Console.Write("Phone Number: ");
            contact.PhoneNumber = Console.ReadLine();

        contact.Address = new Address();

        Console.Write("Street Name: ");
            contact.Address.StreetName = Console.ReadLine();
        Console.Write("Street Number: ");
            contact.Address.StreetNumber = Console.ReadLine();
        Console.Write("Postal Code: ");
            contact.Address.PostalCode = Console.ReadLine();
        Console.Write("City");
            contact.Address.City = Console.ReadLine();

        Task.Run(() => contactService.CreateContactAsync(contact));

    }

    public void GetAllContactsMenu()
    {
        //simpel foreach loop, listar upp alla kontakter som finns i IEnumerable listan
        Console.Clear();
        Console.WriteLine("All contacts");
        Console.WriteLine("First Name - Last Name - Email - Address - Phone Number");
        Console.WriteLine("----------------------------------------------------");

        foreach (var contact in contactService.GetContacts())
        {
            Console.WriteLine(contact.FullName);
            Console.WriteLine(contact.Address.FullAddress);
        }

        Console.ReadKey();
    }

    public void GetSpecificContactMenu()
    {
        Console.Write("Email: ");
        var email = Console.ReadLine();

        var contact = contactService.GetContact(email!);

        Console.WriteLine(contact.FullName);
        Console.WriteLine(contact.Email);
        Console.WriteLine(contact.PhoneNumber);
        Console.WriteLine(contact.Address.FullAddress);
    }

    public void DeleteContactMenu()
    {
        Console.Write("Email: ");
        var email = Console.ReadLine();

        contactService.DeleteContact(email!);
    }
}
