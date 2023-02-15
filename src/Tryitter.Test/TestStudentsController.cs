using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Net;
using System.Net.Http.Json;
using Moq;
using Tryitter.Models;
using Tryitter.Repository;
using Tryitter.Token;
using Tryitter.Controllers;
using Tryitter.Interfaces;

namespace Tryitter.Test;

public class TestStudentsController : IClassFixture<WebApplicationFactory<Program>>
{
  private readonly WebApplicationFactory<Program> _factory;

  public TestStudentsController(WebApplicationFactory<Program> factory)
  {
    _factory = factory;
  }

  [Fact]
  public async Task TestGetAsyncStudents()
  {
    List<Student> fakeStudents = new List<Student>()
    {
      new Student("string", "email", "string", "password") { Id = 1 },
      new Student("string", "email", "string", "password") { Id = 2 },
    };

    var mockGet = new Mock<ITryitterRepository>();
    mockGet
      .Setup(m => m.GetStudentsAsync())
      .ReturnsAsync(fakeStudents);

    StudentsController _controller = new(mockGet.Object);
    var result = await _controller.GetStudentsAsync();
    var okResult = result.As<OkObjectResult>();

    okResult.StatusCode.Should().Be((int)HttpStatusCode.OK);
    mockGet.Verify(m => m.GetStudentsAsync(), Times.Once);
  }

  [Fact]
  public async Task TestGetAsyncStudent()
  {
    Student fakeStudent = new ("string", "email", "string", "password") { Id = 1 };

    var mockGet = new Mock<ITryitterRepository>();
    mockGet
      .Setup(m => m.GetStudentAsync(It.IsAny<int>()))
      .ReturnsAsync(fakeStudent);

    StudentsController _controller = new(mockGet.Object);
    var result = await _controller.GetStudentAsync(1);
    var okResult = result.As<OkObjectResult>();

    okResult.StatusCode.Should().Be((int)HttpStatusCode.OK);
    mockGet.Verify(m => m.GetStudentAsync(It.IsAny<int>()), Times.Once);
  }

  [Theory]
  [InlineData("email@email.com", "123")]
  public void TestCreateSuccess(string email, string password)
  {
    Student fakeStudent = new("string", email, "string", password) { Id = 1 };

    var mockCreate = new Mock<ITryitterRepository>();
    mockCreate
      .Setup(m => m.CreateStudent(It.IsAny<Student>()))
      .Returns(1);

    StudentsController _controller = new(mockCreate.Object);
    var result = _controller.CreateStudent(fakeStudent);
    var createdResult = result.As<CreatedResult>();

    createdResult.StatusCode.Should().Be((int)HttpStatusCode.Created);
    mockCreate.Verify(m => m.CreateStudent(It.IsAny<Student>()), Times.Once);
  }

  [Theory]
  [InlineData("email@email.com", "123")]
  public async Task TestPutSuccess(string email, string password)
  {
    Student fakeStudent = new("string", email, "string", password) { Id = 1 };

    var mockUpdate = new Mock<ITryitterRepository>();
    mockUpdate
      .Setup(m => m.UpdateStudent(It.IsAny<int>(), It.IsAny<Student>()))
      .Returns(true);

    StudentsController _controller = new(mockUpdate.Object);
    var result = _controller.UpdateStudent(1, fakeStudent);
    var noContentResult = result.As<NoContentResult>();

    noContentResult.StatusCode.Should().Be((int)HttpStatusCode.NoContent);
    mockUpdate.Verify(m => m.UpdateStudent(It.IsAny<int>(), It.IsAny<Student>()), Times.Once);
  }

  [Theory]
  [InlineData("email@email.com", "123")]
  public async Task TestPutFail(string email, string password)
  {
    Student fakeStudent = new("string", email, "string", password) { Id = 1 };

    var mockUpdate = new Mock<ITryitterRepository>();
    mockUpdate
      .Setup(m => m.UpdateStudent(It.IsAny<int>(), It.IsAny<Student>()))
      .Returns(false);

    StudentsController _controller = new(mockUpdate.Object);
    var result = _controller.UpdateStudent(1, fakeStudent);
    var badRequestResult = result.As<BadRequestResult>();

    badRequestResult.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
    mockUpdate.Verify(m => m.UpdateStudent(It.IsAny<int>(), It.IsAny<Student>()), Times.Once);
  }

  [Theory]
  [InlineData("email@email.com", "123")]
  public async Task TestDeleteAsyncSuccess(string email, string password)
  {
    Student fakeStudent = new("string", email, "string", password) { Id = 1 };

    var mockDelete = new Mock<ITryitterRepository>();
    mockDelete
      .Setup(m => m.DeleteStudentAsync(It.IsAny<int>()))
      .ReturnsAsync(true);

    StudentsController _controller = new(mockDelete.Object);
    var result = await _controller.DeleteStudentAsync(1);
    var noContentResult = result.As<NoContentResult>();

    noContentResult.StatusCode.Should().Be((int)HttpStatusCode.NoContent);
    mockDelete.Verify(m => m.DeleteStudentAsync(It.IsAny<int>()), Times.Once);
  }

  [Theory]
  [InlineData("email@email.com", "123")]
  public async Task TestDeleteAsyncFail(string email, string password)
  {
    Student fakeStudent = new("string", email, "string", password) { Id = 1 };

    var mockDelete = new Mock<ITryitterRepository>();
    mockDelete
      .Setup(m => m.DeleteStudentAsync(It.IsAny<int>()))
      .ReturnsAsync(false);

    StudentsController _controller = new(mockDelete.Object);
    var result = await _controller.DeleteStudentAsync(1);
    var notFoundResult = result.As<NotFoundResult>();

    notFoundResult.StatusCode.Should().Be((int)HttpStatusCode.NotFound);
    mockDelete.Verify(m => m.DeleteStudentAsync(It.IsAny<int>()), Times.Once);
  }
}
