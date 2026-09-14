using NSubstitute;

namespace FirstContact.Tests.ContactServiceTests;

public class AddContactTests
{
  [Fact]
  public void AddContact_Adds_Contact_To_Repository()
  {
    var contactRepo = Substitute.For<IContactRepository>();
    var contact = new CreateContactRequest{Name = "Bob"};

    var service = new ContactService(contactRepo);
    var response = service.AddContact(contact);

    Assert.Equal("Bob", response.Name);
    Assert.Equal(0, response.Id);
  }
}