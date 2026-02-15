using Microsoft.EntityFrameworkCore;

namespace ExquisiteCorpseAPI.Data
{
  public class Context(DbContextOptions<Context> options) : DbContext(options)
  {
  }
}