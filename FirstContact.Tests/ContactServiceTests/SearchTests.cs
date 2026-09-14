using NSubstitute;

namespace FirstContact.Tests.ContactServiceTests;

public class SearchTests
{
  [Fact]
  public void Search_Returns_Correct_SearchContactResponse()
  {
    var contactRepo = Substitute.For<IContactRepository>();

    contactRepo.Search("Bob").Returns(new List<Contact> { new("Bob") { Id = 1 } });
    contactRepo.Search("Lara").Returns(new List<Contact> { new("Lara") { Id = 2 } });

    var service = new ContactService(contactRepo);
    var responseBob = service.Search("Bob");
    var responseLara = service.Search("Lara");

    Assert.Equal(1, responseBob[0].Id);
    Assert.Equal("Bob", responseBob[0].Name);

    Assert.Equal(2, responseLara[0].Id);
    Assert.Equal("Lara", responseLara[0].Name);
  }

  [Fact]
  public void If_Search_Is_Empty_Then_Response_Returns_Empty()
  {
    var contactRepo = Substitute.For<IContactRepository>();
    contactRepo.Search("Bob").Returns(new List<Contact>());

    var Service = new ContactService(contactRepo);
    var response = Service.Search("Bob");

    Assert.Empty(response);
  }
}