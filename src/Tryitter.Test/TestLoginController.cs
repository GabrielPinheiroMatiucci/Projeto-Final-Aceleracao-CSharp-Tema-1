using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Moq;
using Tryitter.Models;
using Tryitter.Controllers;
using Tryitter.Interfaces;

namespace Tryitter.Test;

public class TestLoginController : IClassFixture<WebApplicationFactory<Program>>
{
  [Theory]
  [InlineData("email@email.com", "123")]
  public async Task TestLoginAsyncSuccess(string email, string password)
  {
    Credentials fakeCredentials = new(email, password);
    Student fakeStudent = new ("string", "email", "string", "password") { Id = 1 };

    var mockRepository = new Mock<ITryitterRepository>();
    mockRepository
      .Setup(m => m.GetStudentAsync(It.IsAny<int>()))
      .ReturnsAsync(fakeStudent);

    LoginController _controller = new(mockRepository.Object);
    var result = await _controller.Login(fakeCredentials);
    var noContentResult = result.As<OkObjectResult>();

    noContentResult.StatusCode.Should().Be((int)HttpStatusCode.OK);
    mockRepository.Verify(m => m.GetStudentAsync(It.IsAny<int>()), Times.Once);
  }

  [Theory]
  [InlineData("gabriel@email.com", "123")]
  public async Task TestLoginAsyncFail(string email, string password)
  {
    Credentials fakeCredentials = new(email, password);
    Student fakeStudent = new ("string", "email", "string", "password") { Id = 1 };

    var mockRepository = new Mock<ITryitterRepository>();
    mockRepository
      .Setup(m => m.GetStudentAsync(It.IsAny<int>()))
      .ReturnsAsync(fakeStudent);

    LoginController _controller = new(mockRepository.Object);
    var result = await _controller.Login(fakeCredentials);
    var noContentResult = result.As<NotFoundResult>();

    noContentResult.StatusCode.Should().Be((int)HttpStatusCode.NotFound);
  }
}
