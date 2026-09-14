using NSubstitute;

namespace FirstContact.Tests.ContactServiceTests;

public class DeleteContactTests
{
  [Fact]
  public void If_Contact_Deletes_Succesfull_Return_True()
  {
    var contactRepo = Substitute.For<IContactRepository>();
    var contacts = new List<Contact> { new("Bob") { Id = 1 }, new("Thomas") { Id = 2 } };

    contactRepo.Delete(contacts[1].Id).Returns(true);

    var service = new ContactService(contactRepo);
    var response = service.DeleteContact(contacts[1].Id);

    Assert.True(response);
    // confirms Commit() was actually called exactly once on the substitute
    contactRepo.Received(1).Delete(contacts[1].Id);
  }

  [Fact]
  public void If_Contact_Does_Not_Exist_Return_False()
  {
    var contactRepo = Substitute.For<IContactRepository>();
    var contacts = new List<Contact> { new("Bob") { Id = 1 }, new("Thomas") { Id = 2 } };

    contactRepo.Delete(contacts[1].Id).Returns(false);

    var service = new ContactService(contactRepo);
    var response = service.DeleteContact(contacts[1].Id);

    Assert.False(response);
    // confirms Commit() was actually called exactly once on the substitute
    contactRepo.Received(1).Delete(contacts[1].Id);
  }

}