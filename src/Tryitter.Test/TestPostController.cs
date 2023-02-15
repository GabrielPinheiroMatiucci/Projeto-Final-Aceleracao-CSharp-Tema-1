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
// using Tryitter.Interfaces;

namespace Tryitter.Test;

public class TestPostController : IClassFixture<WebApplicationFactory<Program>>
{
  private readonly WebApplicationFactory<Program> _factory;

  public TestPostController(WebApplicationFactory<Program> factory)
  {
    _factory = factory;
  }


}