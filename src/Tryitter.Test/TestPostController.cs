using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Moq;
using Tryitter.Models;
using Tryitter.Controllers;
using Tryitter.Interfaces;

namespace Tryitter.Test;

public class TestPostController : IClassFixture<WebApplicationFactory<Program>>
{
  [Fact]
  public async Task TestGetAsyncAllPosts() /* Está falhando */
  {
    List<Post> fakePosts = new List<Post>()
    {
      new Post("textString", "imageString", "dateString") { PostId = 1, Id = 1 },

      new Post("textString", "imageString", "dateString") { PostId = 2, Id = 1 },
    };

    var mockGet = new Mock<ITryitterRepository>();
    mockGet
      .Setup(m => m.GetAllPostsAsync(It.IsAny<int>()))
      .ReturnsAsync(fakePosts);

    PostsController _controller = new(mockGet.Object);
    var result = await _controller.GetAllPostsAsync(1);
    var okResult = result.As<OkObjectResult>();

    okResult.StatusCode.Should().Be((int)HttpStatusCode.OK);
    mockGet.Verify(m => m.GetStudentsAsync(), Times.Once);
  }

  [Fact]
  public async Task TestGetPostByIdAsync()
  {
    Post fakePost = new("textString", "imageString", "dateString") { PostId = 1, Id = 1 };

    var mockGet = new Mock<ITryitterRepository>();
    mockGet
      .Setup(m => m.GetPostByIdAsync(It.IsAny<int>()))
      .ReturnsAsync(fakePost);

    PostsController _controller = new(mockGet.Object);
    var result = await _controller.GetPostByIdAsync(1);
    var okResult = result.As<OkObjectResult>();

    okResult.StatusCode.Should().Be((int)HttpStatusCode.OK);
    mockGet.Verify(m => m.GetStudentAsync(It.IsAny<int>()), Times.Once);
  }

  // [Fact] - tá dando erro de build
  // public async Task TestGetPostByIdAsync()
  // {
  //   Post fakePost = new("textString", "imageString", "dateString") { PostId = 1, Id = 1 };

  //   var mockGet = new Mock<ITryitterRepository>();
  //   mockGet
  //     .Setup(m => m.GetPostByIdAsync(It.IsAny<int>()))
  //     .ReturnsAsync(fakePost);

  //   PostsController _controller = new(mockGet.Object);
  //   var result = await _controller.GetPostByIdAsync(1);
  //   var okResult = result.As<OkObjectResult>();

  //   okResult.StatusCode.Should().Be((int)HttpStatusCode.OK);
  //   mockGet.Verify(m => m.GetStudentAsync(It.IsAny<int>()), Times.Once);
  // }

  [Fact]
  public async Task TestGetLastPostAsync() /* Failed */
  {
    Post fakePost = new("textString", "imageString", "dateString") { PostId = 1, Id = 1 };

    var mockGet = new Mock<ITryitterRepository>();
    mockGet
      .Setup(m => m.GetLastPostAsync(It.IsAny<int>()))
      .ReturnsAsync(fakePost);

    PostsController _controller = new(mockGet.Object);
    var result = await _controller.GetLastPostAsync(1);
    var okResult = result.As<OkObjectResult>();

    okResult.StatusCode.Should().Be((int)HttpStatusCode.OK);
    mockGet.Verify(m => m.GetStudentAsync(It.IsAny<int>()), Times.Once);
  }

  [Theory]
  [InlineData("textStringInline")]
  public void TestCreatePostSucess(string post) /* Passed  */
  {
    Post fakePost = new(post, "imageString", "dateString") { PostId = 1, Id = 1 };

    var mockCreate = new Mock<ITryitterRepository>();
    mockCreate
      .Setup(m => m.CreatePost(It.IsAny<Post>()))
      .Returns(1);

    PostsController _controller = new(mockCreate.Object);
    var result = _controller.CreatePost(fakePost);
    var createdResult = result.As<CreatedResult>();

    createdResult.StatusCode.Should().Be((int)HttpStatusCode.Created);
    mockCreate.Verify(m => m.CreatePost(It.IsAny<Post>()), Times.Once);
  }

  [Theory]
  [InlineData(1, "textNewPost")]
  public void TestUpdatePostSucess(int postId, string newPost) /* Failed */
  {
    Post fakePost = new(newPost, "imageString", "dateString") { PostId = postId, Id = 1 };

    var mockUpdate = new Mock<ITryitterRepository>();
    mockUpdate
      .Setup(m => m.UpdatePost(It.IsAny<int>(), It.IsAny<Post>()))
      .Returns(true);

    PostsController _controller = new(mockUpdate.Object);
    var result = _controller.UpdatePost(1, fakePost);
    var createdResult = result.As<CreatedResult>();

    createdResult.StatusCode.Should().Be((int)HttpStatusCode.Created);
    mockUpdate.Verify(m => m.UpdatePost(It.IsAny<int>(), It.IsAny<Post>()), Times.Once);
  }

  [Theory]
  [InlineData(1, "textNewPost")]
  public void TestUpdatePostFail(int postId, string newPost) /* passed */
  {
    Post fakePost = new(newPost, "imageString", "dateString") { PostId = postId, Id = 1 };

    var mockUpdate = new Mock<ITryitterRepository>();
    mockUpdate
      .Setup(m => m.UpdatePost(It.IsAny<int>(), It.IsAny<Post>()))
      .Returns(false);

    PostsController _controller = new(mockUpdate.Object);
    var result = _controller.UpdatePost(1, fakePost);
    var badRequestResult = result.As<BadRequestResult>();

    badRequestResult.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
    mockUpdate.Verify(m => m.UpdatePost(It.IsAny<int>(), It.IsAny<Post>()), Times.Once);
  }

  [Theory]
  [InlineData(1)]
  public async Task TestDeletePostSucess(int postId) /* passed */
  {
    Post fakePost = new("textString", "imageString", "dateString") { PostId = postId, Id = 1 };

    var mockDelete = new Mock<ITryitterRepository>();
    mockDelete
      .Setup(m => m.DeletePostAsync(It.IsAny<int>()))
      .ReturnsAsync(true);

    PostsController _controller = new(mockDelete.Object);
    var result = await _controller.DeletePostAsync(1);
    var noContentResult = result.As<NoContentResult>();

    noContentResult.StatusCode.Should().Be((int)HttpStatusCode.NoContent);
    mockDelete.Verify(m => m.DeletePostAsync(It.IsAny<int>()), Times.Once);
  }

  [Theory]
  [InlineData(1)]
  public async Task TestDeletePostFail(int postId) /* passed */
  {
    Post fakePost = new("textString", "imageString", "dateString") { PostId = postId, Id = 1 };

    var mockDelete = new Mock<ITryitterRepository>();
    mockDelete
      .Setup(m => m.DeletePostAsync(It.IsAny<int>()))
      .ReturnsAsync(false);

    PostsController _controller = new(mockDelete.Object);
    var result = await _controller.DeletePostAsync(1);
    var notFoundResult = result.As<NotFoundResult>();

    notFoundResult.StatusCode.Should().Be((int)HttpStatusCode.NotFound);
    mockDelete.Verify(m => m.DeletePostAsync(It.IsAny<int>()), Times.Once);
  }
}