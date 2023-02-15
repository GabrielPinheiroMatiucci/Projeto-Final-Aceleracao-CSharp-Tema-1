// só comentei p parar de da 'Problems' no vsc


// using Microsoft.AspNetCore.Mvc.Testing;
// using System.Net.Http.Headers;
// using System.Net;
// using System.Net.Http.Json;
// using Moq;
// using Tryitter.Models;
// using Tryitter.Repository;

// namespace Tryitter.Test;

// public class TestStudentsController : IClassFixture<WebApplicationFactory<Program>>
// {
//   private readonly WebApplicationFactory<Program> _factory;

//   public TestStudentsController(WebApplicationFactory<Program> factory)
//   {
//     _factory = factory;
//   }

//   /*  [Fact]
//   public async Task TestGetStudents()
//   {
//     HttpClient _client = _factory.CreateClient();
//     List<Student> mockStudents = new List<Student>()
//     {
//       new Student("string", "email", "string", "password") { Id = 1 },
//       new Student("string", "email", "string", "password") { Id = 2 },
//     };
//     var mockGet = new Mock<TryitterRepository>();
//     mockGet
//       .Setup(m => m.GetStudents())
//       .Returns(mockStudents);
//     HttpResponseMessage response = await _client.GetAsync("/students");
//     List<Student> content = await response.Content.ReadFromJsonAsync<List<Student>>();

//     response.StatusCode.Should().Be(HttpStatusCode.OK);
//     content.Should().NotBeNullOrEmpty();
//   }
//   [Fact]
//   public async Task TestGetStudent()
//   {
//     HttpClient _client = _factory.CreateClient();
//     Student mockStudent = new("string", "email", "string", "password") { Id = 1 };
//     var mockGet = new Mock<TryitterRepository>();
//     mockGet
//       .Setup(m => m.GetStudent(It.IsAny<int>()))
//       .Returns(mockStudent);
//     HttpResponseMessage response = await _client.GetAsync("/students/1");
//     Student content = await response.Content.ReadFromJsonAsync<Student>();

//     response.StatusCode.Should().Be(HttpStatusCode.OK);
//     content.Should().NotBeNull();
//   }
//   [Theory]
//   [InlineData("email@email.com", "123")]
//   public async Task TestCreateSuccess(string email, string password)
//   {
//     HttpClient _client = _factory.CreateClient();
//     Student mockStudent = new("string", email, "string", password);
//     Credentials credentials = new(email, password);
//     var mockGet = new Mock<TryitterRepository>();
//     mockGet
//       .Setup(m => m.GetStudent(It.IsAny<int>()))
//       .Returns(mockStudent);
//     var mockUpdate = new Mock<TryitterRepository>();
//     mockUpdate
//       .Setup(m => m.CreateStudent(It.IsAny<Student>()))
//       .Returns(1);
//     HttpResponseMessage loginResponse = await _client
//       .PostAsJsonAsync("/login", mockStudent);
//     string token = await loginResponse.Content.ReadAsStringAsync();
//     token.Should().NotBeNull();
//     _client
//       .DefaultRequestHeaders
//       .Authorization = new AuthenticationHeaderValue("Bearer", token);
//     HttpResponseMessage response = await _client.PostAsJsonAsync("/students", mockStudent);
//     response.StatusCode.Should().Be(HttpStatusCode.Created);
//     mockUpdate.Verify(m => m.CreateStudent(It.IsAny<Student>()), Times.Once);
//   }
//   [Theory]
//   [InlineData("email@email.com", "123")]
//   public async Task TestPutSuccess(string email, string password)
//   {
//     HttpClient _client = _factory.CreateClient();
//     Student mockStudent = new("string", email, "string", password) { Id = 99 };
//     Credentials credentials = new(email, password);
//     var mockGet = new Mock<TryitterRepository>();
//     mockGet
//       .Setup(m => m.GetStudent(It.IsAny<int>()))
//       .Returns(mockStudent);
//     var mockUpdate = new Mock<TryitterRepository>();
//     mockUpdate
//       .Setup(m => m.UpdateStudent(It.IsAny<int>(), It.IsAny<Student>()))
//       .Returns(true);
//     HttpResponseMessage loginResponse = await _client
//       .PostAsJsonAsync("/login", mockStudent);
//     string token = await loginResponse.Content.ReadAsStringAsync();
//     token.Should().NotBeNull();
//     _client
//       .DefaultRequestHeaders
//       .Authorization = new AuthenticationHeaderValue("Bearer", token);
//     HttpResponseMessage response = await _client.PutAsJsonAsync("/students/99", mockStudent);
//     response.StatusCode.Should().Be(HttpStatusCode.NoContent);
//   }
//   [Theory]
//   [InlineData("123456789")]
//   public async Task TestPutFail(string invalidToken)
//   {
//     HttpClient _client = _factory.CreateClient();
//     Student mockStudent = new("string", "email", "string", "password") { Id = 1 };
//     _client
//       .DefaultRequestHeaders
//       .Authorization = new AuthenticationHeaderValue("Bearer", invalidToken);
//     HttpResponseMessage response = await _client.PutAsJsonAsync("/students/1", mockStudent);
//     response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
//   }
//   [Theory]
//   [InlineData("email@email.com", "123")]
//   public async Task TestDeleteSuccess(string email, string password)
//   {
//     HttpClient _client = _factory.CreateClient();
//     Student mockStudent = new("string", email, "string", password) { Id = 1 };
//     Credentials credentials = new(email, password);
//     var mockGet = new Mock<TryitterRepository>();
//     mockGet
//       .Setup(m => m.GetStudent(It.IsAny<int>()))
//       .Returns(mockStudent);
//     var mockUpdate = new Mock<TryitterRepository>();
//     mockUpdate
//       .Setup(m => m.DeleteStudent(It.IsAny<int>()))
//       .Returns(true);
//     HttpResponseMessage loginResponse = await _client
//       .PostAsJsonAsync("/login", mockStudent);
//     string token = await loginResponse.Content.ReadAsStringAsync();
//     token.Should().NotBeNull();
//     _client
//       .DefaultRequestHeaders
//       .Authorization = new AuthenticationHeaderValue("Bearer", token);
//     HttpResponseMessage response = await _client.DeleteAsync("/students/1");
//     response.StatusCode.Should().Be(HttpStatusCode.NoContent);
//   } */
// }