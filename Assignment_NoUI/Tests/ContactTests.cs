using Contacts.Models;
using Contacts.Services;
using Moq;
using Contacts.Interfaces;

namespace Tests;

public class ContactTests
{
    //[Fact] gör det till en test metod
    [Fact]
    public void CreateContact_ShouldAddContactToList_ContainContact()
    {
        //Arrange förbered
        ContactService contactService = new ContactService();
        Contact contact = new Contact();

        //Act gör
        contactService.CreateContact(contact);

        //Assert kollar resultat
        Assert.Contains(contact, contactService.GetContacts());
    }
}
