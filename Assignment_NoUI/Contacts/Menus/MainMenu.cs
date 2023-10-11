using Contacts.Services;

namespace Contacts.Menus;

public class MainMenu
{
    public async void Show()
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
                    await MenuService.AddContactMenuAsync();
                    break;

                case "2":
                    MenuService.GetSpecificCustomerMenu();
                    break;

                case "3":
                    MenuService.GetAllContactsMenu();
                    break;

                case "4":
                    MenuService.DeleteContactMenu();
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
}

