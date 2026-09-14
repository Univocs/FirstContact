using NSubstitute;

namespace FirstContact.Tests.ContactServiceTests;

public class GetAllTests
{
  [Fact]
  public void GetAll_Returns_Contacts_With_Correct_Response()
  {
    var contactRepo = Substitute.For<IContactRepository>();
    var contacts = new List<Contact> { new("Bob") { Id = 1 }, new("Thomas") { Id = 2 } };

    contactRepo.GetAll().Returns(contacts);

    var service = new ContactService(contactRepo);
    var response = service.GetAll();

    Assert.Equal(2, response.Count);

    Assert.Equal("Bob", response[0].Name);
    Assert.Equal(1, response[0].Id);

    Assert.Equal("Thomas", response[1].Name);
    Assert.Equal(2, response[1].Id);
  }

  [Fact]
  public void If_GetAll_Empty_Then_Repo_Returns_Empty_Response()
  {
    var contactRepo = Substitute.For<IContactRepository>();
    contactRepo.GetAll().Returns(new List<Contact>());

    var Service = new ContactService(contactRepo);
    var response = Service.GetAll();

    Assert.Empty(response);
  }
}