using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Tryitter.Models;

namespace Tryitter.Token;

public static class TokenGenerator
{
  public static string Generate(Student student)
  {
    JwtSecurityTokenHandler tokenHandler = new();

    var tokenDescriptor = new SecurityTokenDescriptor()
    {
      Subject = AddClaims(student),
      SigningCredentials = new SigningCredentials(
        new SymmetricSecurityKey(Encoding.ASCII.GetBytes(TokenConstant.secret)),
        SecurityAlgorithms.HmacSha256Signature
      ),
      Expires = DateTime.Now.AddDays(1),
    };

    var token = tokenHandler.CreateToken(tokenDescriptor);

    return tokenHandler.WriteToken(token);
  }

  private static ClaimsIdentity AddClaims(Student student)
  {
    ClaimsIdentity claims = new();
    claims.AddClaims(
      new List<Claim>()
      {
        new Claim("Name", student.Name),
        new Claim("Email", student.Email),
        new Claim("Role", "Student"),
      }
    );

    return claims;
  }
}
