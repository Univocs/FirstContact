using NSubstitute;

namespace FirstContact.Tests.ContactServiceTests;

public class UpdateContactTests
{
  [Fact]
  public void If_Contact_Exists_Then_Name_Will_Update()
  {
    var contactRepo = Substitute.For<IContactRepository>();
    var contact = new Contact("Lara") { Id = 1 };

    contactRepo.GetById(1).Returns(contact);

    var updateToBob = new UpdateContactRequest { Name = "Bob" };

    var service = new ContactService(contactRepo);
    var response = service.UpdateContact(1, updateToBob);

    Assert.True(response);
    Assert.Equal("Bob", contact.Name);
    // confirms Commit() was actually called exactly once on the substitute
    contactRepo.Received(1).Commit();
  }

  [Fact]
  public void If_Contact_Does_Not_Exist_Return_False()
  {
    var contactRepo = Substitute.For<IContactRepository>();

    contactRepo.GetById(1).Returns((Contact?)null);

    var updateToBob = new UpdateContactRequest { Name = "Bob" };

    var service = new ContactService(contactRepo);
    var response = service.UpdateContact(1, updateToBob);

    Assert.False(response);
    contactRepo.DidNotReceive().Commit();
  }
}