using Contacts.Models;
using Contacts.Services;
using Moq;

namespace Tests;

public class ContactTests
{
    [Fact]
    public void CreateContact_ShouldAddContactToList_ReturnTrue()
    {
        //Arrange
        ContactService contactService = new ContactService();
        Contact contact = new Contact();

        //Act
        contactService.CreateContact(contact);

        //Assert
        //Assert.True(result);
    }
}
