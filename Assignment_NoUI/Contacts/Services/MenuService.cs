using Contacts.Interfaces;
using Contacts.Models;
using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace Contacts.Services;
public class MenuService 
{
    private static readonly IContactService contactService = new ContactService();


    public static void MainMenu()
    {
        var exit = false;
        //do while loop i main menyn med switchcase, enkel navigering mellan menyerna med switch.
        try
        {
            do
            {
                Console.Clear();
                Console.WriteLine("1. Create new contact");
                Console.WriteLine("2. Show a contact");
                Console.WriteLine("3. Show all contacts");
                Console.WriteLine("4. Delete a contact");
                Console.WriteLine("0. Exit Menu");
                Console.Write("Choose one of the above options: ");
                var option = Console.ReadLine();

                Console.Clear();

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

                Console.ReadKey();
            }
            while (exit == false);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }

    //menyn där man skapar kontakten, läser och sparar inputen från användaren
    public static void CreateContactMenu()
    {

        IContact contact = new Contact();
        try
        {
            Console.Clear();
            //skapar och sparar uppgfiterna till en kontakt i listan 
            Console.WriteLine("Fill in the contact details");
            Console.WriteLine("---------------------------");
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
            contact.Address.Street = Console.ReadLine();
            Console.Write("Postal Code: ");
            contact.Address.PostalCode = Console.ReadLine();
            Console.Write("City: ");
            contact.Address.City = Console.ReadLine();
            Console.WriteLine("Contact added!");

            contactService.CreateContact(contact);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

    }

    public static void GetAllContactsMenu()
    {
        try
        {
            //simpel foreach loop, listar upp alla kontakter som finns i IEnumerable listan
            Console.Clear();
            Console.WriteLine("All contacts");
            Console.WriteLine("----------------------------------------------------");
            //frågetecken i interface/models så har jag frågetecken här också.
            foreach (var contact in contactService.GetContacts())
            {
                Console.WriteLine(contact.FullName);
                Console.WriteLine(contact.Address?.FullAddress);
                Console.WriteLine("---------------------------");
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

    }

    public static void GetSpecificContactMenu()
    {
        Console.Clear();
        //Listar upp en specifik kontakt om emailen existerar. ligger i trycatch så den inte kraschar om email inte finns.
        Console.WriteLine("Search for a specific contact");
        Console.WriteLine("-----------------------------");
        Console.Write("Email: ");
        var email = Console.ReadLine();
        Console.WriteLine("-----------------------------");
        try
        {
            var contact = contactService.GetContact(email!);

            if (contact == null)
            {
                Console.WriteLine("Contact not found.");
            }
            else
            {
                Console.WriteLine(contact.FullName);
                Console.WriteLine(contact.Email);
                Console.WriteLine(contact.PhoneNumber);
                Console.WriteLine(contact.Address?.FullAddress);
            }
        }
        catch (Exception ex) 
        {
            Debug.WriteLine(ex.Message);
        }

    }

    public static void DeleteContactMenu()
    {
        //Tar bort kontakten om email stämmer överens med en kontakt i listan, funkar oavsett vad utan try catch? fråga hans

        Console.Clear();
        Console.WriteLine("Delete a contact");
        Console.WriteLine("----------------");
        Console.Write("Email: ");
        var email = Console.ReadLine();

        try
        {
            contactService.DeleteContact(email!);

            if (email == null)
            {
                Console.WriteLine("Contact not found.");
            }
            else
            {
                Console.WriteLine("Contact deleted!");
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }


    }
}
