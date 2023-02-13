using Microsoft.EntityFrameworkCore;
using Tryitter.Models;

namespace Tryitter.Repository;

public class TryitterContext : DbContext
{
  public TryitterContext(DbContextOptions<TryitterContext> options) : base(options) { }

  public DbSet<Student> Students { get; set; }

  public DbSet<Post> Posts { get; set; }

}
