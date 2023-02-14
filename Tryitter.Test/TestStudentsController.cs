using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Headers;
using System.Net;
using System.Net.Http.Json;
using Moq;
using Tryitter.Models;
using Tryitter.Token;
using Tryitter.Repository;

namespace Tryitter.Test;

public class TestStudentsController : IClassFixture<WebApplicationFactory<Program>>
{   
  private readonly WebApplicationFactory<Program> _factory;

  public TestStudentsController(WebApplicationFactory<Program> factory)
  {
    _factory = factory;
  }

  [Theory]
  [InlineData("email@email.com", "123")]
  public async Task TestPutSuccess(string email, string password)
  {
    HttpClient _client = _factory.CreateClient();
    Student mockStudent = new("string", email, "string", password) { Id = 1 };
    Credentials credentials = new(email, password);

    var mockGet = new Mock<TryitterRepository>();
    mockGet
      .Setup(m => m.GetStudent(It.IsAny<int>()))
      .Returns(mockStudent);

    var mockUpdate = new Mock<TryitterRepository>();
    mockUpdate
      .Setup(m => m.UpdateStudent(It.IsAny<int>(), It.IsAny<Student>()))
      .Returns(true);

    HttpResponseMessage loginResponse = await _client
      .PostAsJsonAsync("/login", credentials);
    string token = await loginResponse.Content.ReadAsStringAsync();

    token.Should().NotBeNull();

    _client
      .DefaultRequestHeaders
      .Authorization = new AuthenticationHeaderValue("Bearer", token);
    HttpResponseMessage response = await _client.PutAsJsonAsync("/students/1", mockStudent);

    response.StatusCode.Should().Be(HttpStatusCode.NoContent);
  }

  [Theory]
  [InlineData("123456789")]
  public async Task TestPutFail(string invalidToken)
  {
    HttpClient _client = _factory.CreateClient();
    Student mockStudent = new("string", "email", "string", "password") { Id = 1 };

    _client
      .DefaultRequestHeaders
      .Authorization = new AuthenticationHeaderValue("Bearer", invalidToken);

    HttpResponseMessage response = await _client.PutAsJsonAsync("/students/1", mockStudent);

    response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
  }
}
